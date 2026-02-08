using UnityEngine;
using UnityEngine.UI;

namespace MG
{
    public class UIGame : MonoBehaviour
    {
        private static UIGame s_instance;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;

        #region --------------------------------------------MONO METHODS-----------------------------------
        void Awake()
        {
            s_instance = this;
        }
        #endregion

        #region --------------------------------------------STATIC METHODS-----------------------------------
        public static void S_Init()
        {
            s_instance.Init();
        }
        public static void S_ShowWinPanel()
        {
            s_instance.ShowWinPanel();
        }
        public static void S_ShowLosePanel()
        {
            s_instance.ShowLosePanel();
        }
        #endregion

        #region --------------------------------------------PRIVATE METHODS-----------------------------------
        private void Init()
        {

        }
        private void ShowWinPanel()
        {
            ShowPanel(winPanel);
        }
        private void ShowLosePanel()
        {
            ShowPanel(losePanel);
        }
        private void ShowPanel(GameObject a_panel)
        {
            a_panel.GetComponent<Canvas>().enabled = true;
            a_panel.GetComponent<GraphicRaycaster>().enabled = true;
        }
        #endregion

        #region --------------------------------------------PUBLIC METHODS-----------------------------------
        public void OnClick_PlayButton()
        {
            SceneHandler.S_LoadGameScene();
        }
        #endregion
    }
}
