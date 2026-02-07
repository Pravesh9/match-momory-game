using UnityEngine;
using UnityEngine.UI;

namespace MG
{
    public class UIGame : MonoBehaviour
    {
        private static UIGame s_instance;
        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;
        void Awake()
        {
            s_instance = this;
        }
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
        public void OnClick_PlayButton()
        {
            SceneHandler.S_LoadGameScene();
        }

    }
}
