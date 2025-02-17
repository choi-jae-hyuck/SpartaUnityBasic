using TMPro;
using UnityEngine.UI;

namespace Stack
{
    public class ScoreUI : BaseUI
    {
        TextMeshProUGUI scoreText;
        TextMeshProUGUI comboText;
        TextMeshProUGUI bestScoreText;
        TextMeshProUGUI bestComboText;
    
        Button startButton;
        Button exitButton;
    
        public override void Init(UIManager uiManager)
        {
            base.Init(uiManager);
            scoreText = transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            comboText = transform.Find("ComboText").GetComponent<TextMeshProUGUI>();
            bestScoreText = transform.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
            bestComboText = transform.Find("BestComboText").GetComponent<TextMeshProUGUI>();
            startButton = transform.Find("StartButton").GetComponent<Button>();
            exitButton = transform.Find("ExitButton").GetComponent<Button>();
        
            startButton.onClick.AddListener(OnClickStartButton);
            exitButton.onClick.AddListener(OnClickExitButton);
        }

        protected override UIState GetUIState()
        {
            return UIState.Score;
        }

        public void SetUI(int score, int combo, int bestScore, int bestCombo)
        {
            scoreText.text = score.ToString();
            comboText.text = combo.ToString();
            bestScoreText.text = bestScore.ToString();
            bestComboText.text = bestCombo.ToString();
        }

        void OnClickStartButton()
        {
            uiManager.OnClickStart();
        }

        void OnClickExitButton()
        {
            uiManager.OnClickExit();
        }
    
    }
}