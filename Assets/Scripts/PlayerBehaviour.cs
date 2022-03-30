using UnityEngine;

namespace Platformer2D
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private const string STATE_IDLE = "Idle";
        private const string STATE_RUN = "Run";
        private const string STATE_JUMP = "Jump";

        public enum PlayerState { Jumping, Grounded }

        [SerializeField] private float _moveSpeed = 2;
        [SerializeField] private float _jumpSpeed = 4;
        [SerializeField] private int _jumpCount;
        
        private Rigidbody2D _rigidbody;
        private SpriteRenderer _spriteRenderer;
        private Animator _animator;
        private PlayerState _currentState;
        private int _currentJumpCount;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            float x = 0;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                _spriteRenderer.flipX = false;
                x += 1;
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                _spriteRenderer.flipX = true;
                x -= 1;
            }

            if (Input.GetKeyDown(KeyCode.Space) && (_currentState == PlayerState.Grounded || _currentJumpCount > 0))
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpSpeed);
                _currentState = PlayerState.Jumping;
                _currentJumpCount--;
            }

            _rigidbody.velocity = new Vector2(x * _moveSpeed, _rigidbody.velocity.y);

            HandleCharacterAnimations(x);
        }

        private void HandleCharacterAnimations(float x)
        {
            switch (_currentState)
            {
                case PlayerState.Grounded:
                    if (Mathf.Abs(x) > 0) _animator.Play(STATE_RUN, 0);
                    else _animator.Play(STATE_IDLE, 0);
                    break;
                case PlayerState.Jumping:
                    _animator.Play(STATE_JUMP, 0);
                    break;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.position.y < transform.position.y)
            {
                _currentState = PlayerState.Grounded;
                _currentJumpCount = _jumpCount;
            }
        }
    }
}
