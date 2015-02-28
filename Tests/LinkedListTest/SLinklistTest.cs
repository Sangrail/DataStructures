using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BasicDataStructures.LinkedLists.Single;

namespace LinkedListTest
{
    [TestClass]
    public class SLinklistTest
    {
        SLinkedList<int> linklist = new SLinkedList<int>();

        [TestMethod]
        public void TestVowelList()
        {
            SLinkedList<string> vowels = new SLinkedList<string>();

            vowels.Append("a");
            vowels.Append("e");
            vowels.Append("i");
            vowels.Append("o");
            vowels.Append("u");

            SNode<string> head = vowels.Head;

            var it = vowels.GetIterator();

            Assert.AreEqual("a", it.GetData()); it.MoveNext();
            Assert.AreEqual("e", it.GetData()); it.MoveNext();
            Assert.AreEqual("i", it.GetData()); it.MoveNext();
            Assert.AreEqual("o", it.GetData()); it.MoveNext();
            Assert.AreEqual("u", it.GetData()); it.MoveNext();

            //foreach (var vowel in vowels)
            //{
            //    Console.WriteLine(vowel);
            //}
        }
        [TestMethod]
        public void TestRemoveTailSingleElement()
        {
            linklist.Clear();

            linklist.Append(10);
            linklist.RemoveTail();

            Assert.AreEqual(null, linklist.Head);
            Assert.AreEqual(null, linklist.Tail);
            Assert.AreEqual(0, linklist.Count);
        }

        [TestMethod]
        public void TestRemoveTailTwoElement()
        {
            linklist.Clear();

            linklist.Append(10);
            linklist.Append(20);
            linklist.RemoveTail();

            Assert.AreEqual(10, linklist.Head.Data);
            Assert.AreEqual(10, linklist.Tail.Data);
            Assert.AreEqual(1, linklist.Count);
        }

        [TestMethod]
        public void TestInsertAfter()
        {
            SNode<int> first = new SNode<int>(0);
            SNode<int> second = first.InsertAfter(1);
            SNode<int> third  = second.InsertAfter(2);

            ValidateListCount(first, 3);
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

            linklist.Append(0);
            linklist.Append(1);
            linklist.Append(2);
            linklist.Append(3);

            ValidateListCount(linklist.Head, 4);

            linklist.RemoveTail();
            linklist.RemoveTail();
            linklist.RemoveTail();
            linklist.RemoveTail();

            ValidateListCount(linklist.Head, 0);

            Assert.AreEqual(null, linklist.Head);
            Assert.AreEqual(null, linklist.Tail);
            Assert.AreEqual(0, linklist.Count);

            ValidateListContents(linklist);            
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

            

            SNode<int> find3 = linklist.Find(3);

            Assert.AreEqual(3, find3.Data);

            int count = ValidateListContents(linklist);
            ValidateListCount(linklist.Head, 5);

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

            ValidateListCount(linklist.Head, 5);

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

            ValidateListCount(linklist.Head, 2);

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

            ValidateListCount(linklist.Head, 4);

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
        public void TestRemoveHeadEmptyList()
        {
            linklist.Clear();
            linklist.RemoveHead();

            Assert.AreEqual(0, linklist.Count);
            Assert.AreEqual(null, linklist.Tail);
            Assert.AreEqual(null, linklist.Head);
        }

        [TestMethod]
        public void TestPrependOneElementToEmptyList()
        {
            linklist.Clear();

            linklist.Prepend(0);

            Assert.AreEqual(1, linklist.Count);
            Assert.AreEqual(linklist.Head, linklist.Tail);
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
        [TestMethod]
        public void TestEnumerator()
        {
            linklist.Clear();

            for (int i = 0; i < 100; i++)
            {
                linklist.Append(i);
            }

            int expectedVal = 0;

            foreach (var integer in linklist)
            {
                Assert.AreEqual(expectedVal++, integer);
            }
        }

        private static void ValidateListCount(SNode<int> head, int expectedCount)
        {
            int count = 0;
            SNode<int> n = head;

            while (n != null)
            {
                Assert.AreEqual(n.Data, count++);

                n = n.Next;
            }

            Assert.AreEqual(expectedCount, count);
        }

        /// <summary>
        /// This simple validation function assumes that data exists in the list 
        /// in sequential, ascending order e.g. {0,1,2,3,4,5, etc...}
        /// </summary>
        /// <param name="linklist"></param>
        /// <returns></returns>
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
