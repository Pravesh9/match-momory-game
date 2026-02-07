using UnityEngine;

namespace MG
{
    public class GameController : MonoBehaviour
    {
        private static GameController s_instance;

        private void Awake()
        {
            s_instance = this;
        }
        void Start()
        {
            Init();
        }
        private void Init()
        {
            CardSpawner.S_Init(); //Card generation
        }

    }
}