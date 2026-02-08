using System;
using System.Collections.Generic;
namespace MG
{
    public class BoardService : IBoardService
    {
        private readonly Random rng = new Random();

        #region --------------------------------------------PRIVATE METHODS-----------------------------------
        private void Shuffle(List<CardModel> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
        }
        #endregion

        #region --------------------------------------------PUBLIC METHODS-----------------------------------
        public List<CardModel> GenerateBoard(int a_rows, int a_cols)
        {
            int l_total = a_rows * a_cols;

            if (l_total % 2 != 0)
                throw new ArgumentException("Grid must contain an even number of cards.");

            List<CardModel> l_cards = new List<CardModel>(l_total);

            int l_pairCount = l_total / 2;

            for (int i = 0; i < l_pairCount; i++)
            {
                l_cards.Add(new CardModel(i + 1));
                l_cards.Add(new CardModel(i + 1));
            }

            Shuffle(l_cards);

            return l_cards;
        }

        #endregion
    }
}