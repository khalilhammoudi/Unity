using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer2D
{
    public class ActionsMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("SampleScene");
        }

        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quiting");
        }
    }
}
