using UnityEngine;
using System.Collections.Generic;
namespace MG
{
    public class CardSpawner : MonoBehaviour
    {
        [SerializeField] private CardTile cardPrefab;
        private IBoardService boardService;
        private static CardSpawner s_intsance;
        private void Awake()
        {
            s_intsance = this;
            boardService = new BoardService(); // Here we can change board service as required
        }
        void Start()
        {
            Spawn(4, 4);
        }

        public void Spawn(int a_rows, int a_cols)
        {
            List<CardModel> l_models = boardService.GenerateBoard(a_rows, a_cols);
            foreach (var item in l_models)
            {
                Debug.Log(item.Id);
            }
        }
    }
}