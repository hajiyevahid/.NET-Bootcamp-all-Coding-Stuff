using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Activity.Profile;
using CSharp.Activity.Datastore;//.Faculty;

namespace Activity2.Test
{
    [TestClass]
    public class ArrayStackTest
    {
        private PlayerProfile[] data;
        private ArrayStack<string> stack;

        [TestInitialize]
        public void Init()
        {
            data = new PlayerProfile[4];
            data[0] = new PlayerProfile("Eugene", PlayerProfile.MALE, new DateTime(1977, 9, 13));
            data[1] = new PlayerProfile("Nadja", PlayerProfile.FEMALE, new DateTime(1981, 8, 11));
            data[2] = new PlayerProfile("Toby", PlayerProfile.MALE, new DateTime(1980, 5, 19));
            data[3] = new PlayerProfile("The OW", PlayerProfile.MALE, DateTime.Now);

            stack = new ArrayStack<string>(3);
        }

        [TestMethod]
        public void TestCapacity()
        {
            Assert.AreEqual(3, stack.Capacity);
            Assert.IsFalse(stack.IsFull());
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopEmpty()
        {
            string tmp = stack.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPeekEmpty()
        {
            string tmp = stack.Peek();
        }

        [TestMethod]
        public void TestPushDublicate()
        {
            stack.Push(data[0].PlayerName);
            stack.Push(data[1].PlayerName);

            try
            {
                stack.Push(data[1].PlayerName);
                Assert.Fail("Does not throw an exception");
            }
            catch (Exception)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void TestPushFull()
        {
            stack.Push(data[0].PlayerName);
            stack.Push(data[1].PlayerName);
            stack.Push(data[2].PlayerName);

            try
            {
                stack.Push(data[3].PlayerName);
            }
            catch (InvalidOperationException)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void TestStackFull()
        {
            stack.Push(data[0].PlayerName);
            stack.Push(data[1].PlayerName);
            stack.Push(data[2].PlayerName);

            Assert.AreEqual(3, stack.Count);

            Assert.IsTrue(stack.IsFull());

        }

        [TestMethod]
        public void TestIndexOfSucceed()
        {
            stack.Add(data[0].PlayerName);
            stack.Add(data[1].PlayerName);
            stack.Add(data[2].PlayerName);

            Assert.AreEqual(2, stack.IndexOf(data[2].PlayerName));
        }

        [TestMethod]
        public void TestIndexOfNotInStructure()
        {
            stack.Add(data[0].PlayerName);
            stack.Add(data[1].PlayerName);
            stack.Add(data[2].PlayerName);

            Assert.AreEqual(ArrayBase<string>.NOT_IN_STRUCTURE, stack.IndexOf(data[3].PlayerName));
            Assert.AreEqual(data[2].PlayerName, stack[2]);

        }

        [TestMethod]
        public void TestArrayInvalidIndexNegative()
        {
            try
            {
                object o = stack[-5];
                Assert.Fail("Does not throw an exception");
            }
            catch (IndexOutOfRangeException)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void TestArrayInvalidIndexPositive()
        {
            try
            {
                object o = stack[5];
                Assert.Fail("Does not throw an exception");
            }
            catch (IndexOutOfRangeException)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        public void TestPeekAndPop()
        {
            stack.Push(data[0].PlayerName);
            stack.Push(data[1].PlayerName);
            stack.Push(data[2].PlayerName);

            Assert.IsTrue(stack[2] == data[2].PlayerName);

            Assert.AreEqual(data[2].PlayerName, stack.Peek());
            Assert.AreEqual(data[2].PlayerName, stack.Pop());

            Assert.AreEqual(data[1].PlayerName, stack.Peek());
            Assert.AreEqual(data[1].PlayerName, stack.Pop());

            Assert.AreEqual(data[0].PlayerName, stack.Peek());
            Assert.AreEqual(data[0].PlayerName, stack.Pop());

            Assert.IsTrue(stack.IsEmpty());

            Assert.AreEqual(0, stack.Count);

        }

        [TestMethod]
        public void TestPeekAndPopForValueTypeElements()
        {
            var intStack = new ArrayStack<int>(3);

            intStack.Push(0);
            intStack.Push(1);
            intStack.Push(2);

            Assert.IsTrue(intStack[2] == 2);

            Assert.AreEqual(2, intStack.Peek());
            Assert.AreEqual(2, intStack.Pop());

            Assert.AreEqual(1, intStack.Peek());
            Assert.AreEqual(1, intStack.Pop());

            Assert.AreEqual(0, intStack.Peek());
            Assert.AreEqual(0, intStack.Pop());

            Assert.IsTrue(intStack.IsEmpty());

            Assert.AreEqual(0, intStack.Count);
        }

        [TestMethod]
        public void TestEmptyStack()
        {
            Assert.IsTrue(stack.IsEmpty());

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void TestDefaultSize()
        {
            stack = new ArrayStack<string>();
            Assert.AreEqual(5, stack.Capacity);
        }

        [TestMethod]
        public void TestNegativeSize()
        {
            stack = new ArrayStack<string>(-6);
            Assert.AreEqual(5, stack.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemoveAtException()
        {
            stack.Add(data[0].PlayerName);
            stack.Add(data[1].PlayerName);
            stack.Add(data[2].PlayerName);

            stack.RemoveAt(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRemoveEmptyException()
        {
            stack.RemoveAt(0);
        }

        [TestMethod]
        public void TestRemoveLast()
        {
            stack.Add(data[0].PlayerName);
            stack.Add(data[1].PlayerName);
            stack.Add(data[2].PlayerName);

            stack.RemoveAt(2);
        }

        [TestMethod]
        public void TestRemoveFirst()
        {
            stack.Add(data[0].PlayerName);
            stack.Add(data[1].PlayerName);
            stack.Add(data[2].PlayerName);

            stack.RemoveAt(0);

            Assert.AreEqual(data[1].PlayerName, stack[0]);
        }

    }
}
