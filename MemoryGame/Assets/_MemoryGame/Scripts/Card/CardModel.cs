namespace MG
{
    public class CardModel
    {
        public int Id;
        public bool IsMatched;

        public CardModel(int a_id)
        {
            Id = a_id;
            IsMatched = false;
        }
    }
}