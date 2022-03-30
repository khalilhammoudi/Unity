using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2D
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Current { get; private set; }

        [SerializeField] private PlayerBehaviour _player;
        [SerializeField] private Transform _coinContainer;
        [SerializeField] private TextPopup _textPopup;
        [SerializeField] private float _deadZone;

        private int _totalCoinToWin;
        private int _currentCoin;

        public int CurrentCoin { get => _currentCoin; }

        private void Awake()
        {
            if (Current != null)
            {
                Debug.LogWarning("There's more than one game manager exist in the scene");
                Destroy(gameObject);
                return;
            }

            Current = this;
        }

        private void Start()
        {
            _totalCoinToWin = _coinContainer.childCount;
        }

        private void Update()
        {
            if (_player == null) return;
            if (_player.transform.position.y < _deadZone)
            {
                StartCoroutine(EndGame("GameOver!"));   
            }
        }

        public void AddCoin()
        {
            _currentCoin++;

            if (_currentCoin >= _totalCoinToWin)
            {
                StartCoroutine(EndGame("You Win!"));   
            }
        }

        private IEnumerator EndGame(string message)
        {
            Destroy(_player.gameObject);
            _textPopup.Show(message);
            
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene("MenuScene");        
        }
    
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(new Vector2(-100, _deadZone), new Vector2(100, _deadZone));
        }
    }
}
