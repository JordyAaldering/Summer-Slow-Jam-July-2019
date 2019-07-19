using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public void Start()
        {
            SceneManager.LoadScene(1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
