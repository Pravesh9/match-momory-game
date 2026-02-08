using UnityEngine;
using System.Collections.Generic;
using System.Collections;
namespace MG
{
    public class CardSpawner : MonoBehaviour
    {
        private static CardSpawner s_intsance;
        [SerializeField] private GameSetting gameSetting;
        private int row;
        private int col;
        private IBoardService boardService;
        private IEnumerable<CardModel> cardModels;

        static public IEnumerable<CardModel> CardModels { get => s_intsance.cardModels; }
        public static int Row { get => s_intsance.row; }
        public static int Col { get => s_intsance.col; }

        private void Awake()
        {
            s_intsance = this;
            boardService = new BoardService(); // Here we can change board service as required
        }
        public static void S_Init()
        {
            s_intsance.Init();
        }
        public static void S_Init(List<CardModel> a_cardModels, int a_rows, int a_cols)
        {
            s_intsance.cardModels = a_cardModels;
            s_intsance.row = a_rows;
            s_intsance.col = a_cols;
            UIBoard.S_Init(s_intsance.cardModels, a_rows, a_cols);
        }
        private void Init()
        {
            row = gameSetting.Row;
            col = gameSetting.Col;
            Spawn(row, col);
        }

        private void Spawn(int a_rows, int a_cols)
        {
            cardModels = boardService.GenerateBoard(a_rows, a_cols);
            //Here we can pass this data to UI Views
            UIBoard.S_Init(cardModels, a_rows, a_cols);
        }
    }
}