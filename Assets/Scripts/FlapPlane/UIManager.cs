using TMPro;
using UnityEngine;

namespace FlapPlane
{
    public class UIManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI restartText;
        public GameObject Title;

        public void Start()
        {
            if (restartText == null)
            {
                Debug.LogError("restart text is null");
            }
        
            if (scoreText == null)
            {
                Debug.LogError("scoreText is null");
                return;
            }
        
            restartText.gameObject.SetActive(false);
        }

        public void GameStart()
        {
            Title.SetActive(false);
            Time.timeScale = 1;
        }

        public void SetRestart()
        {
            restartText.gameObject.SetActive(true);
        }

        public void UpdateScore(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}