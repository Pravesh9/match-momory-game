using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace MG
{
    public class CardTile : MonoBehaviour
    {
        private Image cardImage;
        [SerializeField] private TextMeshProUGUI idText;
        [SerializeField] private Button openButton;
        [SerializeField] private CardModel model;
        [SerializeField] private GameObject openCard;
        [SerializeField] private GameObject closeCard;

        private bool isOpen;
        private bool isAnimating;
        private bool isMatched;


        #region --------------------------------------------PRIVATE METHODS-----------------------------------
        private void UpdateVisual()
        {
            idText.SetText(model.Id.ToString());
        }

        private void OnClick_OpenBtn()
        {
            if (isAnimating || isOpen)
                return;

            // StartCoroutine(Flip(true));
            GameEvent.OnCardOpen?.Invoke(this);
        }

        private IEnumerator Flip(bool a_open)
        {
            isAnimating = true;

            float l_duration = 0.1f;
            float t = 0;

            Vector3 l_start = transform.localScale;
            Vector3 l_mid = new Vector3(0, l_start.y, l_start.z);

            // shrink
            while (t < l_duration)
            {
                t += Time.deltaTime;
                transform.localScale = Vector3.Lerp(l_start, l_mid, t / l_duration);
                yield return null;
            }

            // swap visuals at midpoint
            openCard.SetActive(a_open);
            closeCard.SetActive(!a_open);
            isOpen = a_open;

            // expand
            t = 0;
            while (t < l_duration)
            {
                t += Time.deltaTime;
                transform.localScale = Vector3.Lerp(l_mid, l_start, t / l_duration);
                yield return null;
            }

            transform.localScale = l_start;
            isAnimating = false;
        }

        private void SetClosedInstant()
        {
            isOpen = false;
            openCard.SetActive(false);
            closeCard.SetActive(true);
        }

        #endregion

        #region --------------------------------------------PUBLIC METHODS-----------------------------------
        public void Init(CardModel a_model)
        {
            model = a_model;
            UpdateVisual();
            openButton.onClick.AddListener(OnClick_OpenBtn);
            SetClosedInstant();
            if (a_model.IsMatched)
            {
                ForceSetOpen(true);
                isMatched = true;
            }
        }
        public CardModel GetModel() => model;
        public bool IsOpen() => isOpen;

        public void ForceSetOpen(bool open)
        {
            isOpen = open;
            openCard.SetActive(open);
            closeCard.SetActive(!open);
        }

        public void SetMatch(bool a_isMatch)
        {
            isMatched = a_isMatch;
        }
        public bool HasMatched() => isMatched;
        public void CloseCard()
        {
            if (isAnimating || !isOpen)
                return;

            StartCoroutine(Flip(false));
        }
        public void OpenCard()
        {
            if (isAnimating || isOpen)
                return;

            StartCoroutine(Flip(true));
        }

        #endregion
    }
}