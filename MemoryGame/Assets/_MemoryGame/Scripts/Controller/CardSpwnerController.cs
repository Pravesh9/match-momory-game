using UnityEngine;
using System.Collections.Generic;
namespace MG
{
    public class CardSpawner : MonoBehaviour
    {
        private static CardSpawner s_intsance;
        [SerializeField] private CardTile cardPrefab;
        [SerializeField] private int row;
        [SerializeField] private int col;
        private IBoardService boardService;
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
            IEnumerable<CardModel> l_models = boardService.GenerateBoard(a_rows, a_cols);
            //Here we can pass this data to UI Views
            UIBoard.S_Init(l_models, a_rows, a_cols);
        }
    }
}