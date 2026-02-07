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
        [SerializeField] private CardTile cardTilePrefab;
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
                CardTile l_Tile = Instantiate(cardTilePrefab, grid.transform);
                l_Tile.Init(item);
            }
            ResizeGrid(a_rows, a_cols);

            // Create a Card grid 
        }
        private void ResizeGrid(int a_rows, int a_cols)
        {
            float l_spacing = 50f;

            float l_containerWidth = container.rect.width;
            float l_containerHeight = container.rect.height;

            float l_horizontalSpacing = (a_cols - 1) * l_spacing;
            float l_verticalSpacing = (a_rows - 1) * l_spacing;

            float l_usableWidth = l_containerWidth - l_horizontalSpacing;
            float l_usableHeight = l_containerHeight - l_verticalSpacing;

            float l_cellWidth = l_usableWidth / a_cols;
            float l_cellHeight = l_usableHeight / a_rows;

            float l_cellSize = Mathf.Min(l_cellWidth, l_cellHeight);

            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = a_cols;
            grid.cellSize = new Vector2(l_cellSize, l_cellSize);
            grid.spacing = new Vector2(l_spacing, l_spacing);
        }
    }

}