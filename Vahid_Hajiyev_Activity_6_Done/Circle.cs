namespace CSharp.Activity.Polymorphism
{
    public class Circle : Shape, IPrintable
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            if (radius < 0)
            {
                throw new ArgumentOutOfRangeException("Please add valid parameter !");
            }
            Radius = radius;
        }

        public void Print()
        {
            Console.WriteLine("Circle is printed!");
        }

        public override void CalculateArea()
        {
            Area = Math.PI * Radius * Radius;
        }
    }
}
