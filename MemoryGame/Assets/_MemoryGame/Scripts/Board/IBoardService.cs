using System.Collections.Generic;
namespace MG
{
    public interface IBoardService
    {
        List<CardModel> GenerateBoard(int a_rows, int a_cols);
    }
}