namespace CSharp.Activity.CardGame
{
    public class SimpleCard : ICard
    {
        public byte CardAttribute { get; set; }

        public string GetCardAttribute()
        {
            return "Card " + CardAttribute;
        }
    }
}
