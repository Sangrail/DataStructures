using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicDataStructures.LinkedLists.Double;

namespace LinkedListTest
{
    [TestClass]
    public class DLinklistTest
    {
        DLinkedList<int> linklist = new DLinkedList<int>();

        [TestMethod]
        public void EmptyAtStart()
        {
            linklist.Clear();

            Assert.AreEqual(0, linklist.Count);
        }

        [TestMethod]
        public void AddOne()
        {
            linklist.Clear();

            linklist.Append(1);

            Assert.AreEqual(1, linklist.Count);
        }

        [TestMethod]
        public void AddOneRemoveOne()
        {
            linklist.Clear();

            linklist.Append(1);

            Assert.AreEqual(1, linklist.Count);

            linklist.RemoveTail();

            Assert.AreEqual(true, linklist.IsEmpty());
        }

        [TestMethod]
        public void AddHundredAndClear()
        {
            linklist.Clear();

            for (int i = 0; i < 100; i++ ) linklist.Append(i);

            Assert.AreEqual(100, linklist.Count);

            linklist.Clear();

            Assert.AreEqual(0, linklist.Count);
        }

        [TestMethod]
        public void RemoveTailEmptyList()
        {
            linklist.Clear();

            linklist.RemoveTail();

            Assert.AreEqual(0, linklist.Count);
        }

        [TestMethod]
        public void RemoveTailEmptyListAddThree()
        {
            linklist.Clear();

            linklist.RemoveTail();

            Assert.AreEqual(0, linklist.Count);

            for (int i = 0; i < 3; i++) linklist.Append(i);

            Assert.AreEqual(3, linklist.Count);
        }

        [TestMethod]
        public void RemoveHeadEmpty()
        {
            linklist.Clear();
            linklist.RemoveHead();
            Assert.AreEqual(0, linklist.Count);
        }
    }
}
