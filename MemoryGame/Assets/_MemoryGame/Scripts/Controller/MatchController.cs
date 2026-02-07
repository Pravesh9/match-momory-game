using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MG
{
    public class MatchController : MonoBehaviour
    {
        private static MatchController s_instance;
        private IMatchRule matchRule;
        private readonly List<CardTile> selected = new();
        private bool resolving;

        private void Awake()
        {
            s_instance = this;
        }
        public static void S_Init(IMatchRule a_rule)
        {
            s_instance.Init(a_rule);
        }
        private void Init(IMatchRule a_rule)
        {
            matchRule = a_rule;
            GameEvent.OnCardOpen += OnCardOpen;
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
            }

            selected.Clear();

            resolving = false;
        }
    }
}
