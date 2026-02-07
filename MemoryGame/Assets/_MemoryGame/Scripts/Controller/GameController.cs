using System;
using UnityEngine;

namespace MG
{
    public class GameController : MonoBehaviour
    {
        private static GameController s_instance;

        private void Awake()
        {
            s_instance = this;
        }
        void Start()
        {
            Init();
            GameEvent.OnGameWon += OnGamewin;
            GameEvent.OnGameLost += OnGameLose;
        }
        void OnDisable()
        {
            GameEvent.OnGameWon -= OnGamewin;
            GameEvent.OnGameLost -= OnGameLose;
        }
        private void Init()
        {
            CardSpawner.S_Init(); //Card generation
            GameStateController.S_Init();
            IMatchRule l_matchRule = new PairMatchRule();
            MatchController.S_Init(l_matchRule, CardSpawner.CardModels);
            ScoreController.S_Init();
        }

        private void OnGameLose()
        {
            Debug.Log("OnGameLost!");
        }

        private void OnGamewin()
        {
            Debug.Log("OnGameWin!");
        }


    }
}