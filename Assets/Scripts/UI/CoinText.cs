using UnityEngine;
using TMPro;

namespace Platformer2D
{
    public class CoinText : MonoBehaviour
    {
        public static CoinText Current { get; private set; }

        private TMP_Text _textComponent;

        private void Awake()
        {
            if (Current != null)
            {
                Destroy(gameObject);
                return;
            }

            Current = this;
            _textComponent = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            _textComponent.text = string.Format("COIN: {0}", GameManager.Current.CurrentCoin);
        }
    }
}
