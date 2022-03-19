namespace CSharp.Activity.CardGame
{
    public class SimpleCard : ICard
    {
        public static int CardAttribute { get; set; }
        public string GetCardAttribute()
        {
            return "Card " + CardAttribute;
        }
    }
}
