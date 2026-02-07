using System.Collections.Generic;

namespace MG
{
    public interface IMatchRule
    {
        bool IsMatch(List<CardTile> tiles);
        int RequiredCount { get; }
    }
}