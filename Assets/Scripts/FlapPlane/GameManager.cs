using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlapPlane
{
    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;

        public static GameManager Instance
        {
            get { return gameManager; }
        }
    
        private int currentScore = 0;
        UIManager uiManager;

        public UIManager UIManager
        {
            get { return uiManager; }
        }
        private void Awake()
        {
            gameManager = this;
            SetScreen();
            uiManager = FindObjectOfType<UIManager>();
        }
    
        private void Start()
        {
            uiManager.UpdateScore(0);
        }
    
        public void GameOver()
        {
            Debug.Log("Game Over");
            uiManager.SetRestart();
        }
    
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void GameOut()
        {
            
            SceneManager.LoadScene("MainGameScene");
        }

        public void AddScore(int score)
        {
            currentScore += score;
            uiManager.UpdateScore(currentScore);
            Debug.Log("Score: " + currentScore);
        }

        public void SetScreen()
        {
            Screen.SetResolution(1920, 1080, false);
        }
    }
}