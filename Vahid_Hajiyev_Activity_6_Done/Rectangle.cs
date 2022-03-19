namespace CSharp.Activity.Polymorphism
{
    public class Rectangle : Shape, IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Rectangle is printed!");
        }

        public double Length { get; protected set; }
        public double Width { get; protected set; }

        public Rectangle(double length, double width)
        {
            if (length < 0 || width < 0)
            {
                throw new ArgumentOutOfRangeException("Please add valid parameters !");
            }
            Length = length;
            Width = width;
        }

        public override void CalculateArea()
        {
            Area = Width * Length;
        }
    }
}
