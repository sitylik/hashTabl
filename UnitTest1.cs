using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestHashTable
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestThreeElements()
        {
            string[] value = new string[] { "Компьютер", "Чайник", "Микроволновка" };
            var table = new HashTable.HashTable(3);
            for (int i = 0; i < value.Length; i++)
                table.PutPair(i + 1, value[i]);
            for (int i = 0; i < value.Length; i++)
                Assert.AreEqual(table.GetValueByKey(i + 1), value[i]);
        }
        [TestMethod]
        public void TestEqualElements()
        {
            string[] value = new string[] { "Чайник", "Микроволновка" };
            var table = new HashTable.HashTable(3);
            table.PutPair(1, value[0]);
            table.PutPair(1, value[1]);
            Assert.AreEqual(table.GetValueByKey(1), value[0]);
            Assert.AreEqual(table.GetValueByKey(1), value[1]);
        }
        [TestMethod]
        public void TestManyElements()
        {
            int size = 100000;
            var table = new HashTable.HashTable(size);
            for (int i = 0; i < size; i++)
                table.PutPair(i, i++);
            Assert.AreEqual(table.GetValueByKey(920), 921);
        }
        [TestMethod]
        public void TestManySearchElements()
        {
            int size = 100000;
            var table = new HashTable.HashTable(size);
            for (int i = 0; i < size; i++)
                table.PutPair(i, i++);
            for (int i = 0; i < size; i++)
                Assert.AreEqual(table.GetValueByKey(1), i + 1);
        }
    }
}
