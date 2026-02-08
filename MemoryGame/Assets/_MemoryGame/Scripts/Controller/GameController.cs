using System;
using System.Collections.Generic;
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
            SaveController.S_Init();
            SoundController.S_Init();
            if (SaveController.GameData != null)//It means already a progress match there
            {
                LoadLastGame();
            }
            else
            {
                PlayNewGame();
            }

        }

        private static void LoadLastGame()
        {
            //Reset all game board as per saved data\
            GameSaveData l_data = SaveController.GameData;
            List<CardModel> l_cardModels = new List<CardModel>();
            for (int i = 0; i < l_data.cardIds.Count; i++)
            {
                CardModel l_cardmodel = new CardModel(l_data.cardIds[i]);
                l_cardmodel.IsMatched = l_data.cardOpened[i];
                l_cardModels.Add(l_cardmodel);
            }
            CardSpawner.S_Init(l_cardModels, l_data.rows, l_data.cols); //Card generation
            GameStateController.S_Init();
            IMatchRule l_matchRule = new PairMatchRule();
            MatchController.S_Init(l_matchRule, CardSpawner.CardModels);
            ScoreController.S_Init();
            UITimer.S_Init();

            ScoreController.SetScoreCombo(l_data.score, l_data.combo);
            UITimer.SetTimeRemaing(l_data.timeRemaining);
        }

        private static void PlayNewGame()
        {
            CardSpawner.S_Init(); //Card generation
            GameStateController.S_Init();
            IMatchRule l_matchRule = new PairMatchRule();
            MatchController.S_Init(l_matchRule, CardSpawner.CardModels);
            ScoreController.S_Init();
            UITimer.S_Init();
        }

        private void OnGameLose()
        {
            Debug.Log("OnGameLost!");
            UIGame.S_ShowLosePanel();
        }

        private void OnGamewin()
        {
            Debug.Log("OnGameWin!");
            UIGame.S_ShowWinPanel();
        }

        void OnApplicationPause(bool pause)
        {
            if (pause)
                SaveGame();
        }

        void OnApplicationQuit()
        {
            SaveGame();
        }
        private void SaveGame()
        {
            if (GameStateController.GetCurrentState() != GameState.PLAYING) return;
            int l_rows = CardSpawner.Row;
            int l_cols = CardSpawner.Col;
            List<CardTile> l_tiles = UIBoard.CardTiles;
            int l_score = ScoreController.GetSCore();
            int l_combo = ScoreController.GetCombo();
            float l_timeRemaining = UITimer.GetTime();

            SaveController.S_CreateSave(l_rows, l_cols, l_tiles, l_score, l_combo, l_timeRemaining);
        }
    }
}