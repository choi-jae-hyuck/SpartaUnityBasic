using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainGame
{
    public class HighScoreUI : MonoBehaviour
    {
        [SerializeField] private GameObject text1;
        [SerializeField] private GameObject text2;
        private TextMeshProUGUI miniText1;
        private TextMeshProUGUI miniText2;

        private void Awake()
        {
            miniText1 = text1.GetComponent<TextMeshProUGUI>();
            miniText2 = text2.GetComponent<TextMeshProUGUI>();
        }

        private void LoadHighScore()
        {
            miniText1.text = PlayerPrefs.GetInt("MiniFlap_BestScore", 0).ToString();
            miniText2.text = PlayerPrefs.GetInt("MiniStack_BestScore", 0).ToString();
        }

        private void OnEnable()
        {
            LoadHighScore();
        }

        public void Exit()
        {
            gameObject.SetActive(false);
        }
    }
}
