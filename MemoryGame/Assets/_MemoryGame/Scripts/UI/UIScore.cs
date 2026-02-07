using TMPro;
using UnityEngine;

namespace MG
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        const string SCORE = "Score: ";
        private void OnEnable()
        {
            GameEvent.OnScoreChanged += UpdateScore;
        }
        void OnDisable()
        {
            GameEvent.OnScoreChanged -= UpdateScore;
        }

        private void UpdateScore(int a_value)
        {
            scoreText.SetText($"{SCORE}{a_value}");
        }
    }
}