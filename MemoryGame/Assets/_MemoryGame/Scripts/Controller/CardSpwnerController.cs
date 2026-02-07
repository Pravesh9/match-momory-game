using UnityEngine;
using System.Collections.Generic;
namespace MG
{
    public class CardSpawner : MonoBehaviour
    {
        private static CardSpawner s_intsance;
        [SerializeField] private CardTile cardPrefab;
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
            Spawn(4, 4);
        }

        private void Spawn(int a_rows, int a_cols)
        {
            List<CardModel> l_models = boardService.GenerateBoard(a_rows, a_cols);
            foreach (var item in l_models)
            {
                Debug.Log(item.Id);
            }
            //Here we can pass this data to UI Views
        }
    }
}