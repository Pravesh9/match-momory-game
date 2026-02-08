using System;
using System.Collections;
using System.Collections.Generic;
using MG;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController s_instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoundSetting soundSetting;
    private AudioClip winClip;
    private AudioClip loseClip;
    private AudioClip flipClip;

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
    #endregion

    #region --------------------------------------------PRIVATE METHODS-----------------------------------
    private void Init()
    {
        winClip = soundSetting.WinClip;
        loseClip = soundSetting.LoseClip;
        flipClip = soundSetting.FlipClip;

        GameEvent.OnCardOpen += OnCardOpen;
        GameEvent.OnMatchSuccess += OnMatchSuccess;
        GameEvent.OnMatchFailed += OnMatchFailed;
        GameEvent.OnGameWon += OnGameWon;
        GameEvent.OnGameLost += OnGameLost;
    }
    void OnDestroy()
    {
        GameEvent.OnCardOpen -= OnCardOpen;
        GameEvent.OnMatchSuccess -= OnMatchSuccess;
        GameEvent.OnMatchFailed -= OnMatchFailed;
        GameEvent.OnGameWon -= OnGameWon;
        GameEvent.OnGameLost -= OnGameLost;
    }

    private static void OnGameLost()
    {
        Debug.Log("OnGameLost");
    }

    private static void OnGameWon()
    {
        Debug.Log("OnGameWon");
    }

    private static void OnMatchFailed()
    {
        Debug.Log("OnMatchFailed");
    }

    private static void OnMatchSuccess()
    {
        Debug.Log("OnMatchSuccess");
    }

    private static void OnCardOpen(CardTile tile)
    {
        Debug.Log("OnCardOpen");
    }
    #endregion   
}
