using UnityEngine;

namespace MG
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "MG/Game Settings")]
    public class GameSetting : ScriptableObject
    {
        [Header("Scoring")]
        [SerializeField] private int scoreIncrement = 1;

        [Header("Timer")]
        [SerializeField] private float totalTimer = 30f;

        [Header("Board Size")]
        [SerializeField] private int row = 4;
        [SerializeField] private int col = 4;

        public int ScoreIncrement { get => scoreIncrement; private set => scoreIncrement = value; }
        public float TotalTimer { get => totalTimer; private set => totalTimer = value; }
        public int Row { get => row; private set => row = value; }
        public int Col { get => col; private set => col = value; }
    }
}