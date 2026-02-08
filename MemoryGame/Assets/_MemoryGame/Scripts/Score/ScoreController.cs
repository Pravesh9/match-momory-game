using UnityEngine;
namespace MG
{
    public class ScoreController : MonoBehaviour, IScoreRule
    {
        private static ScoreController s_instance;
        [SerializeField] private int baseScore = 1;

        public int Score { get; private set; }
        public int Combo { get; private set; }

        #region --------------------------------------------MONO METHODS-----------------------------------
        private void Awake()
        {
            s_instance = this;
        }
        #endregion

        #region --------------------------------------------STATIC METHODS-----------------------------------
        public static void S_Init()
        {
            s_instance.Init();
        }
        #endregion

        #region --------------------------------------------PRIVATE METHODS-----------------------------------
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
        #endregion

        #region --------------------------------------------PUBLIC METHODS-----------------------------------
        public void AddMatchScore()
        {
            Combo++;

            int l_gained = Mathf.RoundToInt(baseScore + Combo);
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
        public static int GetSCore() => s_instance.Score;
        public static int GetCombo() => s_instance.Combo;
        public static void SetScoreCombo(int a_score, int a_combo)
        {
            s_instance.Score = a_score;
            s_instance.Combo = a_combo;
            GameEvent.OnScoreChanged?.Invoke(s_instance.Score);
            GameEvent.OnComboChanged?.Invoke(s_instance.Combo);
        }
        #endregion
    }
}
