using UnityEngine;

namespace MG
{
    public class GameStateController : MonoBehaviour
    {
        private static GameStateController s_instance;
        public GameState State { get; private set; }

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
        public static void S_Win()
        {
            s_instance.Win();
        }
        public static void S_Lose()
        {
            s_instance.Lose();
        }
        public static GameState GetCurrentState() => s_instance.State;
        #endregion

        #region --------------------------------------------PRIVATE METHODS-----------------------------------
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

        #endregion
    }
}
