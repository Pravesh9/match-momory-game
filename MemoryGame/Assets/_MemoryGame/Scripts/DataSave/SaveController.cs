using System.Collections.Generic;
using UnityEngine;
using MG;
public class SaveController : MonoBehaviour
{
    private static SaveController s_instance;
    SaveService saveService;
    GameSaveData gameData;

    public GameSaveData GameData { get => gameData; }

    private void Awake()
    {
        s_instance = this;
    }
    public static void S_Init()
    {
        s_instance.Init();
    }
    public static void S_CreateSave(int a_rows, int a_cols, List<CardTile> a_tiles, int a_score, int a_combo, float a_timeRemaining)
    {
        var l_data = s_instance.CreateSave(a_rows, a_cols, a_tiles, a_score, a_combo, a_timeRemaining);
        s_instance.saveService.Save(l_data);
    }
    private void Init()
    {
        saveService = new SaveService();
        // if (saveService.HasSave())
        // {
        //     gameData = saveService.Load();
        //     LoadFromSave(gameData);
        // }
    }

    public GameSaveData CreateSave(
           int a_rows,
           int a_cols,
           List<CardTile> a_tiles,
           int a_score,
           int a_combo,
           float a_timeRemaining)
    {
        GameSaveData l_data = new GameSaveData();

        l_data.rows = a_rows;
        l_data.cols = a_cols;

        l_data.cardIds = new List<int>();
        l_data.cardOpened = new List<bool>();

        foreach (var t in a_tiles)
        {
            l_data.cardIds.Add(t.GetModel().Id);
            l_data.cardOpened.Add(t.IsOpen());
        }

        l_data.score = a_score;
        l_data.combo = a_combo;
        l_data.timeRemaining = a_timeRemaining;

        return l_data;
    }
    public void LoadFromSave(GameSaveData data)
    {
        List<CardModel> models = new();

        foreach (var id in data.cardIds)
            models.Add(new CardModel(id));

        UIBoard.S_Init(models, data.rows, data.cols);

        var tiles = FindObjectsOfType<CardTile>();

        for (int i = 0; i < tiles.Length; i++)
        {
            tiles[i].ForceSetOpen(data.cardOpened[i]);
        }
    }
}
