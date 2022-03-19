using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using ArrayStore;//.Faculty;
using CSharp.Activity.Datastore;//.Faculty;

namespace Activity4.Test
{
    [TestClass]
    public class ArrayStoreTest
    {
        [TestMethod]
        public void TestEmptyArray()
        {
            var testArray = new ArrayStore<string>(4);

            Assert.IsTrue(testArray.Capacity == 4, String.Format("Maximum size of ArrayStore is not 4 as expected, returned: {0}", testArray.Capacity.ToString()));
            Assert.IsTrue(testArray.Count == 0, String.Format("Member count of ArrayStore is not 0 as expected, returned: {0}", testArray.Capacity.ToString()));
        }

        [TestMethod]
        [Ignore]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void TestInvalidGetValueOperation()
        {
            var testArray = new ArrayStore<string>(2);
            Assert.IsNull(testArray[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestInvalidNullAdd()
        {
            var testArray = new ArrayStore<string>(2);
            testArray.Add(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestInvalidNullInsert()
        {
            var testArray = new ArrayStore<string>(2);
            testArray.Insert(null, 1);
        }

        [TestMethod]
        //[ExpectedException(typeof(System.ArgumentNullException))]
        public void TestInvalidNullInsert2()
        {
            var testArray = new ArrayStore<string>(3);
            testArray.Add("Jelgava");
            testArray.Add("Jelgava2");
            testArray.Insert("Talsi", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void TestInvalidNullRemove()
        {
            var testArray = new ArrayStore<string>(2);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            testArray.Remove(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestInvalidInsertIndex0()
        {
            var testArray = new ArrayStore<string>(2);
            testArray.Insert("Something", -1);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestInvalidInsertIndexOverIndex()
        {
            var testArray = new ArrayStore<string>(2);
            testArray.Insert("Something", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void TestGetValueIndexOutOfRangeException0()
        {
            var testArray = new ArrayStore<string>(3);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            var t = testArray[-1];
        }


        [TestMethod]
        [Ignore]
        [ExpectedException(typeof(System.IndexOutOfRangeException))]
        public void TestGetValueIndexOutOfRangeException1()
        {
            var testArray = new ArrayStore<string>(3);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            var t = testArray[1];
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
        public void TestInvalidRemoveIndex()
        {
            var testArray = new ArrayStore<string>(4);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            Assert.IsTrue(testArray.Add("Balvi") > -1);
            Assert.IsTrue(testArray.Add("Ventspils") > -1);

            testArray.RemoveAt(6);
        }

        [TestMethod]
        //[Ignore]
        public void TestAddOperation()
        {
            var testArray = new ArrayStore<string>(4);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            Assert.IsTrue(testArray.Count == 2, String.Format("Member count of ArrayStore<string> is not 2 as expected, returned: {0}", testArray.Count.ToString()));

            Assert.IsTrue(testArray[0] == "Jelgava");
            Assert.IsTrue(testArray[1] == "Talsi");
        }

        [TestMethod]
        public void TestAddOperationWhenFull_DoNotAdd()
        {
            var testArray = new ArrayStore<string>(2);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            Assert.IsFalse(testArray.Add("Tallinn") > -1, "Should not be allowing to add Tallinn");
            Assert.IsTrue(testArray.Count == 2, String.Format("Member count of ArrayStore<string> is not 2 as expected, returned: {0}", testArray.Count.ToString()));

            Assert.IsTrue(testArray[0] == "Jelgava");
            Assert.IsTrue(testArray[1] == "Talsi");
        }

        [TestMethod]
        public void TestInsertOperationWhenFull_DoNotInsert()
        {
            var testArray = new ArrayStore<string>(2);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            Assert.IsFalse(testArray.Insert("Tallinn", 1) > -1, "Should not be allowing to add Tallinn");
            Assert.IsTrue(testArray.Count == 2, String.Format("Member count of ArrayStore<string> is not 2 as expected, returned: {0}", testArray.Count.ToString()));

            Assert.IsTrue(testArray[0] == "Jelgava");
            Assert.IsTrue(testArray[1] == "Talsi");
        }

        [TestMethod]
        public void TestInsert()
        {
            var testArray = new ArrayStore<string>(4);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            Assert.IsTrue(testArray.Add("Balvi") > -1);
            Assert.IsTrue(testArray.Count == 3, String.Format("Member count of ArrayStore<string> is not 3 as expected, returned: {0}", testArray.Count.ToString()));
            Assert.IsTrue(testArray.Insert("Ventspils", 1) > -1);
            Assert.IsTrue(testArray.Count == 4, String.Format("Member count of ArrayStore<string> is not 4 as expected, returned: {0}", testArray.Count.ToString()));

            Assert.IsTrue(testArray[0] == "Jelgava");
            Assert.IsTrue(testArray[1] == "Ventspils");
            Assert.IsTrue(testArray[2] == "Talsi");
            Assert.IsTrue(testArray[3] == "Balvi");
        }

        [TestMethod]
        public void TestRemoveByIndex()
        {
            var testArray = new ArrayStore<string>(4);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            Assert.IsTrue(testArray.Add("Balvi") > -1);
            Assert.IsTrue(testArray.Add("Ventspils") > -1);
            testArray.RemoveAt(1);
            Assert.IsTrue(testArray.Count == 3, String.Format("Member count of ArrayStore<string> is not 3 as expected, returned: {0}", testArray.Count.ToString()));

            Assert.IsTrue(testArray[0] == "Jelgava");
            Assert.IsTrue(testArray[1] == "Balvi");
            Assert.IsTrue(testArray[2] == "Ventspils");
        }

        [TestMethod]
        public void TestRemoveByObject()
        {
            var testArray = new ArrayStore<string>(4);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            Assert.IsTrue(testArray.Add("Balvi") > -1);
            Assert.IsTrue(testArray.Add("Ventspils") > -1);
            testArray.Remove("Balvi");
            Assert.IsTrue(testArray.Count == 3, String.Format("Member count of ArrayStore<string> is not 3 as expected, returned: {0}", testArray.Count.ToString()));

            Assert.IsTrue(testArray[0] == "Jelgava");
            Assert.IsTrue(testArray[1] == "Talsi");
            Assert.IsTrue(testArray[2] == "Ventspils");
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void TestRemoveNotInStructure()
        {
            var testArray = new ArrayStore<string>(4);
            Assert.IsTrue(testArray.Add("Jelgava") > -1);
            Assert.IsTrue(testArray.Add("Talsi") > -1);
            Assert.IsTrue(testArray.Add("Balvi") > -1);
            Assert.IsTrue(testArray.Add("Ventspils") > -1);
            testArray.Remove("Tallinn");
            Assert.IsTrue(testArray.Count == 4, String.Format("Member count of ArrayStore<string> is not 4 as expected, returned: {0}", testArray.Count.ToString()));

            Assert.IsTrue(testArray[0] == "Jelgava");
            Assert.IsTrue(testArray[1] == "Talsi");
            Assert.IsTrue(testArray[2] == "Balvi");
            Assert.IsTrue(testArray[3] == "Ventspils");
        }
    }
}
