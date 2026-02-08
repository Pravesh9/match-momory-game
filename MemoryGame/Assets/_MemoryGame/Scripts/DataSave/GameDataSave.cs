using System;
using System.Collections.Generic;

[Serializable]
public class GameSaveData
{
    public int rows;
    public int cols;

    public List<int> cardIds;
    public List<bool> cardOpened;

    public int score;
    public int combo;

    public float timeRemaining;
}