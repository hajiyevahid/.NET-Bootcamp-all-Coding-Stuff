namespace CSharp.Activity.CardGame
{
    public abstract class CardDeck
    {
        public int MaxCount { get; set; }

        public int CardCount { get { return cardBunch.Count; } }

        public List<ICard> cardBunch = new List<ICard>();

        public CardDeck(int number = 10)
        {
            MaxCount = number;
            cardBunch = new List<ICard>(MaxCount);
            InitializeDeck();
        }

        public abstract void InitializeDeck();

        public ICard GetCard()
        {
            if (CardCount == 0)
            {
                return null;
            }

            Random random = new Random();
            int randomNumber = random.Next(0, cardBunch.Count);
            var deletedCard = cardBunch[randomNumber];
            cardBunch.RemoveAt(randomNumber);/////

            return deletedCard;
        }

        public ICard GetCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("Object can not be null !");
            }

            if (cardBunch.Count == 0 || !cardBunch.Contains(card))
            {
                return null;
            }

            cardBunch.Remove(card);

            return card;
        }

        public bool PutCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("It is impossible to add null object!");
            }

            cardBunch.Add(card);

            return true;
        }
    }
}