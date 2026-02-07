using TMPro;
using UnityEngine;

namespace MG
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        const string SCORE = "Score: ";
        void Start()
        {
            UpdateScore(0);
        }
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