using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CSharp.Activity.Polymorphism
{
    [TestClass]
    public class AreaCalculationsTest
    {
        private Circle testCircle;
        private Rectangle testRectangle;

        [TestInitialize]
        public void Initialize()
        {
            testCircle = new Circle(4);
            testRectangle = new Rectangle(5.1, 6.1);
        }

        [TestMethod]
        public void TestCircleArea()
        {
            testCircle.CalculateArea();
            Assert.AreEqual(50.27, Math.Round(testCircle.Area, 2));
            testCircle.Print();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestCircleRadiusWithInvalidParameters()
        {
            testCircle = new Circle(-2);
        }

        [TestMethod]
        public void TestRectangleArea()
        {
            testRectangle.CalculateArea();
            Assert.AreEqual(31.11, Math.Round(testRectangle.Area, 2));
            testRectangle.Print();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestRectangleDimensionsWithInvalidParameters()
        {
            testRectangle = new Rectangle(-8, 6);
            testRectangle = new Rectangle(-9, -11);
            testRectangle = new Rectangle(9, 11);
        }
    }
}