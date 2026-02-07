using UnityEngine;
using UnityEngine.UI;
namespace MG
{
    public class CardTile : MonoBehaviour
    {
        private Image cardImage;
        private CardModel model;

        public void Init(CardModel a_model)
        {
            model = a_model;

            // Example visual setup
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            // change sprite based on model.Id
        }

        public CardModel GetModel() => model;
    }
}