using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MG
{
    public class MatchController : MonoBehaviour
    {
        private static MatchController s_instance;
        private IMatchRule matchRule;
        private readonly List<CardTile> selected = new();
        private bool resolving;
        private int totalPairs;
        private int matchedPairs;

        private void Awake()
        {
            s_instance = this;
        }
        public static void S_Init(IMatchRule a_rule, IEnumerable<CardModel> a_cardModels)
        {
            s_instance.Init(a_rule, a_cardModels);
        }
        private void Init(IMatchRule a_rule, IEnumerable<CardModel> a_cardModels)
        {
            matchRule = a_rule;
            GameEvent.OnCardOpen += OnCardOpen;
            totalPairs = a_cardModels.Count() / 2;
            matchedPairs = 0;
        }
        private void OnCardOpen(CardTile a_tile)
        {
            if (resolving)
                return;

            selected.Add(a_tile);

            if (selected.Count >= matchRule.RequiredCount)
            {
                StartCoroutine(Resolve());
            }
        }

        private IEnumerator Resolve()
        {
            resolving = true;

            yield return new WaitForSeconds(0.5f);

            bool l_match = matchRule.IsMatch(selected);

            if (!l_match)
            {
                foreach (var tile in selected)
                    tile.CloseCard();

                GameEvent.OnMatchFailed?.Invoke();
            }
            else
            {
                GameEvent.OnMatchSuccess?.Invoke();

                matchedPairs++;

                if (matchedPairs >= totalPairs)
                {
                    GameStateController.S_Win();
                }
            }

            selected.Clear();

            resolving = false;
        }
    }
}
