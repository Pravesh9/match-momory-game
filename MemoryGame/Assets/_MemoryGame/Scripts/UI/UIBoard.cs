using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MG
{
    public class UIBoard : MonoBehaviour
    {
        private static UIBoard s_instance;
        [SerializeField] private RectTransform container;
        [SerializeField] private GridLayoutGroup grid;
        [SerializeField] private GameObject cardTilePrefab;
        IEnumerable<CardModel> cardModels;
        void Awake()
        {
            s_instance = this;
        }
        public static void S_Init(IEnumerable<CardModel> a_cardModels, int a_rows, int a_cols)
        {
            s_instance.Init(a_cardModels, a_rows, a_cols);
        }
        private void Init(IEnumerable<CardModel> a_cardModels, int a_rows, int a_cols)
        {
            cardModels = a_cardModels;
            foreach (var item in a_cardModels)
            {
                GameObject l_obj = Instantiate(cardTilePrefab, grid.transform);
            }
            ResizeGrid(a_rows, a_cols);

            // Create a Card grid 
        }
        private void ResizeGrid(int rows, int cols)
        {
            float spacing = 50f;

            float containerWidth = container.rect.width;
            float containerHeight = container.rect.height;

            float horizontalSpacing = (cols - 1) * spacing;
            float verticalSpacing = (rows - 1) * spacing;

            float usableWidth = containerWidth - horizontalSpacing;
            float usableHeight = containerHeight - verticalSpacing;

            float cellWidth = usableWidth / cols;
            float cellHeight = usableHeight / rows;

            float cellSize = Mathf.Min(cellWidth, cellHeight);

            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = cols;
            grid.cellSize = new Vector2(cellSize, cellSize);
            grid.spacing = new Vector2(spacing, spacing);
        }
    }

}