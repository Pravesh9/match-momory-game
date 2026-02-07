using UnityEngine;

namespace MG
{
    public class ScoreController : MonoBehaviour, IScoreRule
    {
        private static ScoreController s_instance;
        [SerializeField] private int baseScore = 100;
        [SerializeField] private float comboMultiplier = 0.5f;

        public int Score { get; private set; }
        public int Combo { get; private set; }

        private void Awake()
        {
            s_instance = this;
        }
        public static void S_AddMatchScore()
        {
            s_instance.AddMatchScore();
        }
        public static void S_BreakCombo()
        {
            s_instance.BreakCombo();
        }
        public static void S_Init()
        {

        }
        private void Init()
        {
            GameEvent.OnMatchSuccess += AddMatchScore;
            GameEvent.OnMatchFailed += BreakCombo;
        }
        private void OnDisable()
        {
            GameEvent.OnMatchSuccess -= AddMatchScore;
            GameEvent.OnMatchFailed -= BreakCombo;
        }
        public void AddMatchScore()
        {
            Combo++;

            int l_gained = Mathf.RoundToInt(
                baseScore * (1 + Combo * comboMultiplier)
            );

            Score += l_gained;

            GameEvent.OnScoreChanged?.Invoke(Score);
            GameEvent.OnComboChanged?.Invoke(Combo);
        }

        public void BreakCombo()
        {
            Combo = 0;
            GameEvent.OnComboChanged?.Invoke(Combo);
        }

        public void Reset()
        {
            Score = 0;
            Combo = 0;

            GameEvent.OnScoreChanged?.Invoke(Score);
            GameEvent.OnComboChanged?.Invoke(Combo);
        }
    }
}
