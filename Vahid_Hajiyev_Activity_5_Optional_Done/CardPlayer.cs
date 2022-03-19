using CSharp.Activity.Profile;
namespace CSharp.Activity.CardGame
{
    public class CardPlayer : PlayerProfile
    {
        public byte currentCount { get; set; }

        public List<ICard> HoldedCards { get; set; }

        public CardPlayer(string name, char gender, DateTime birthDate, byte maximum) : base(name, gender, birthDate, maximum)
        {
            HoldedCards = new List<ICard>(maximum);
            currentCount = 0;
            MaxCardCount = maximum;
        }

        public bool AddCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("This operation is not allowed !");
            }
            if (currentCount == MaxCardCount)
            {
                return false;
            }
            HoldedCards.Add(card);
            currentCount++;

            return true;
        }

        public bool RemoveCard(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentNullException("This operation is not allowed !");
            }
            if (!HoldedCards.Contains(card))
            {
                return false;
            }
            HoldedCards.Remove(card);
            currentCount--;

            return true;
        }

        public bool IsFull()
        {
            if (currentCount == MaxCardCount)
            {
                return true;
            }

            return false;
        }
    }
}
