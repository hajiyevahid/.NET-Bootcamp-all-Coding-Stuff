namespace CSharp.Activity.CardGame
{
    /// <summary>
    /// Summary description for Card.
    /// </summary>
    public interface ICard
    {
        /// <summary>
        ///      Method to return the card for the given attribute.
        /// </summary>
        /// <param name="attribute">The index of the required card</param>
        /// <returns>An object</returns>
        /// 
        string GetCardAttribute();
    }
}
