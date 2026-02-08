using UnityEngine;

namespace MG
{
    public class GameStateController : MonoBehaviour
    {
        private static GameStateController s_instance;
        public GameState State { get; private set; }

        void Awake()
        {
            s_instance = this;
        }
        public static void S_Init()
        {
            s_instance.Init();
        }
        public static void S_Win()
        {
            s_instance.Win();
        }
        public static void S_Lose()
        {
            s_instance.Lose();
        }
        private void Init()
        {
            State = GameState.PLAYING;
        }

        private void Win()
        {
            if (State != GameState.PLAYING) return;

            State = GameState.WON;
            GameEvent.OnGameWon?.Invoke();
        }

        private void Lose()
        {
            if (State != GameState.PLAYING) return;

            State = GameState.LOST;
            GameEvent.OnGameLost?.Invoke();
        }
        public static GameState GetCurrentState() => s_instance.State;
    }
}
