using UnityEngine;

namespace Platformer2D
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Current { get; private set; }

        [SerializeField] private AudioSource _source;

        private void Awake()
        {
            if (Current != null)
            {
                Destroy(gameObject);
                return;
            }

            Current = this;
            DontDestroyOnLoad(gameObject);
        }

        public void Play(AudioClip clip)
        {
            _source.PlayOneShot(clip, 1.0f);
        }
    }
}
