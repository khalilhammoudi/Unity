using UnityEngine;
using TMPro;

namespace Platformer2D
{
    public class TextPopup : MonoBehaviour
    {
        private TMP_Text _textComponent;

        private void Awake()
        {
            _textComponent = GetComponent<TMP_Text>();
            gameObject.SetActive(false);
        }

        public void Show(string message)
        {
            _textComponent.text = message;
            gameObject.SetActive(true);
        }
    }
}
