#pragma warning disable 0649
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private GameObject levelCompletePanel;

        public void GameOver()
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(1);
        }

        public void LevelComplete()
        {
            Time.timeScale = 0f;
            levelCompletePanel.SetActive(true);
        }

        public void Menu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
