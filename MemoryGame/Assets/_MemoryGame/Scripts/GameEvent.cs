using System;
using MG;

public static class GameEvent
{
    public static Action<CardTile> OnCardOpen;
    public static Action OnMatchSuccess;
    public static Action OnMatchFailed;
    public static Action<int> OnScoreChanged;
    public static Action<int> OnComboChanged;
}