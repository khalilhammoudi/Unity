using UnityEngine;

namespace Platformer2D
{
    public class CoinBehaviour : MonoBehaviour
    {
        [SerializeField] private AudioClip _sfx;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Coin collected");

            if (AudioManager.Current != null)
                AudioManager.Current.Play(_sfx);
                
            GameManager.Current.AddCoin();
            CoinText.Current.UpdateText();
            
            Destroy(gameObject);
        }
    }
}
