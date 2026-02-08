using UnityEngine;
using TMPro;
using Unity.Mathematics;
namespace MG
{
    public class UITimer : MonoBehaviour
    {
        private static UITimer s_instance;
        [SerializeField] private float timeLimit = 60f;
        [SerializeField] private TextMeshProUGUI timerText;
        public float TimeRemaining { get; private set; }
        private bool running;

        const string TIME_LEFT = "Time Left: ";
        #region --------------------------------------------MONO METHODS-----------------------------------
        void Awake()
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
            GameEvent.OnGameWon += OnGamWon;
            StartTimer();
        }
        void OnDisable()
        {
            GameEvent.OnGameWon -= OnGamWon;
        }

        private void OnGamWon()
        {
            StopTimer();
        }

        private void StartTimer()
        {
            TimeRemaining = timeLimit;
            running = true;
        }

        private void Update()
        {
            if (!running) return;

            TimeRemaining -= Time.deltaTime;
            timerText.SetText($"{TIME_LEFT} {math.round(TimeRemaining)}");
            if (TimeRemaining <= 0)
            {
                StopTimer();
                GameStateController.S_Lose();
            }
        }
        private void StopTimer()
        {
            running = false;
        }
        #endregion

        #region --------------------------------------------PUBLIC METHODS-----------------------------------
        public static float GetTime() => s_instance.TimeRemaining;
        public static void SetTimeRemaing(float a_timeRemaining)
        {
            s_instance.TimeRemaining = a_timeRemaining;
        }
        #endregion
    }
}
