using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using csInterviewRevision.BasicDataStructures.LinkedLists.Single;

namespace LinkedListTest
{
    [TestClass]
    public class SLinklistTest
    {
        SLinkedList<int> linklist = new SLinkedList<int>();

        [TestMethod]
        public void TestInsertAfter()
        {
            SNode<int> first = new SNode<int>(0);

            SNode<int> second = first.InsertAfter(1);
            second.InsertAfter(2);

            Assert.AreEqual(first.Data, 0);
            Assert.AreEqual(first.Next.Data, 1);
            Assert.AreEqual(first.Next.Next.Data, 2);
            Assert.AreEqual(first.Next.Next.Next, null);
        }

        [TestMethod]
        public void TestCreateEmptySLinkList()
        {
            linklist.Clear();

            Assert.AreEqual(null, linklist.Head);
            Assert.AreEqual(null, linklist.Tail);
            Assert.AreEqual(0, linklist.Count);
        }

        [TestMethod]
        public void TestCreateEmptyPopulateAndClearSLinkList()
        {
            linklist.Clear();

            linklist.Append(1);
            linklist.Append(2);
            linklist.Append(3);

            linklist.RemoveTail();
            linklist.RemoveTail();
            linklist.RemoveTail();

            Assert.AreEqual(null, linklist.Head);
            Assert.AreEqual(null, linklist.Tail);
            Assert.AreEqual(0, linklist.Count);

            int count = ValidateListContents(linklist);

            Assert.AreEqual(count, linklist.Count);
        }

        [TestMethod]
        public void TestFindnodeExists()
        {
            linklist.Clear();

            linklist.Append(0);
            linklist.Append(1);
            linklist.Append(2);
            linklist.Append(3);
            linklist.Append(4);

            SNode<int> find11 = linklist.Find(3);

            Assert.AreEqual(3, find11.Data);

            int count = ValidateListContents(linklist);

            Assert.AreEqual(count, linklist.Count);
        }

        [TestMethod]
        public void TestFindnodeDoesntExist()
        {
            linklist.Clear();

            linklist.Append(0);
            linklist.Append(1);
            linklist.Append(2);
            linklist.Append(3);
            linklist.Append(4);

            SNode<int> find11 = linklist.Find(5);

            Assert.AreEqual(null, find11);
        }

        [TestMethod]
        public void TestGetIterator()
        {
            linklist.Clear();

            for (int i = 0; i < 10;i++ )
            {
                linklist.Append(i);
            }

            int count = ValidateListContents(linklist);

            Assert.AreEqual(count, linklist.Count);
        }

        [TestMethod]
        public void TestPrependEmptyList()
        {
            linklist.Clear();

            linklist.Prepend(1);
            linklist.Prepend(0);

            int count = ValidateListContents(linklist);

            Assert.AreEqual(count, linklist.Count);
        }

        [TestMethod]
        public void TestPrependNonEmptyList()
        {
            linklist.Clear();

            linklist.Append(2);
            linklist.Append(3);

            linklist.Prepend(1);
            linklist.Prepend(0);

            int count = ValidateListContents(linklist);

            Assert.AreEqual(count, linklist.Count);
        }

        [TestMethod]
        public void TestReverse()
        {
            linklist.Clear();

            for (int i = 0; i < 100; i++)
                linklist.Append(i);

            int count = ValidateListContents(linklist);

            Assert.AreEqual(count, linklist.Count);

            linklist.Reverse();

            var iter = linklist.GetIterator();

            count = linklist.Count;

            while (iter.IsValid())
            {
                Assert.AreEqual(--count, iter.GetData());
                iter.MoveNext();
            }
        }

        [TestMethod]
        public void TestClear()
        {
            linklist.Clear();

            for (int i = 0; i < 100;i++ )
                linklist.Append(i);

            Assert.AreEqual(100, linklist.Count);

            linklist.Clear();

            Assert.AreEqual(0, linklist.Count);
            Assert.AreEqual(null, linklist.Head);
            Assert.AreEqual(null, linklist.Tail);
        }

        private static int ValidateListContents(SLinkedList<int> linklist)
        {
            int count = 0;

            var iter = linklist.GetIterator();

            while (iter.IsValid())
            {
                Assert.AreEqual(count++, iter.GetData());
                iter.MoveNext();
            }
            return count;
        }
    }
}
