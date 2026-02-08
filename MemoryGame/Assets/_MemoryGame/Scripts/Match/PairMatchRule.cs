using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG
{
    public class PairMatchRule : IMatchRule
    {
        public int RequiredCount => 2; //How Many matches should be there 

        public bool IsMatch(List<CardTile> a_cards)
        {
            if (a_cards.Count != 2)
                return false;

            return a_cards[0].GetModel().Id ==
                   a_cards[1].GetModel().Id;
        }
    }

}