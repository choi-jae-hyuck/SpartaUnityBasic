using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlapPlane
{
    public class GameManager : MonoBehaviour
    {
        static GameManager gameManager;
        
        private const string BestScoreKey = "MiniFlap_BestScore";
        private int bestScore = 0;

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
            bestScore = PlayerPrefs.GetInt(BestScoreKey, bestScore);
            uiManager = FindObjectOfType<UIManager>();
            Time.timeScale = 0;
        }
    
        private void Start()
        {
            uiManager.UpdateScore(0);
        }
    
        public void GameOver()
        {
            Debug.Log("Game Over");
            PlayerPrefs.SetInt(BestScoreKey, bestScore);
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
            if(currentScore > bestScore)
                bestScore = currentScore;
            uiManager.UpdateScore(currentScore);
            Debug.Log("Score: " + currentScore);
        }

        public void SetScreen()
        {
            Screen.SetResolution(1920, 1080, false);
        }
    }
}