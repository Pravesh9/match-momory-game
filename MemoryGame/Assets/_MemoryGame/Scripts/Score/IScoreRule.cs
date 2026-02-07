public interface IScoreRule
{
    int Score { get; }
    int Combo { get; }

    void AddMatchScore();
    void Reset();
}