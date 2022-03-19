namespace CSharp.Activity.CardGame
{
    public class SimpleDeck : CardDeck
    {
        public List<ICard> Cards = new List<ICard>();
        public override void InitializeDeck()
        {
            for (int i = 0; i < MaxCount; i++)
            {
                PutCard(new SimpleCard());
            }

            foreach (var item in cardBunch)
            {
                Cards.Add(item);
            }
        }
    }
}
