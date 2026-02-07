using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    private static SceneHandler s_instance;

    const string GAME = "Game";
    const string HOME = "Home";
    void Awake()
    {
        s_instance = this;
    }
    public static void S_Init()
    {
        s_instance.Init();
    }
    private void Init()
    {

    }
    public static void S_LoadGameScene()
    {
        SceneManager.LoadScene(GAME);
    }
}
