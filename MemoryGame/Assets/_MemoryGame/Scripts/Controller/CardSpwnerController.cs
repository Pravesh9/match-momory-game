using UnityEngine;
using System.Collections.Generic;
using System.Collections;
namespace MG
{
    public class CardSpawner : MonoBehaviour
    {
        private static CardSpawner s_intsance;
        [SerializeField] private CardTile cardPrefab;
        [SerializeField] private int row;
        [SerializeField] private int col;
        private IBoardService boardService;
        private IEnumerable<CardModel> cardModels;

        static public IEnumerable<CardModel> CardModels { get => s_intsance.cardModels; }

        private void Awake()
        {
            s_intsance = this;
            boardService = new BoardService(); // Here we can change board service as required
        }
        public static void S_Init()
        {
            s_intsance.Init();
        }
        private void Init()
        {
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