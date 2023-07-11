using ClassLibrary.Classes.Item;
using ManagerLibrary.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.TestData;

namespace UnitTest
{
    [TestClass]
    public class ItemAlgorithmTest
    {
        [TestMethod]
        public void TestSortByPriceAsc()
        {
            var sortItems = new SortItems();
            var fakeDataItem = new FakeDataItem();
            var items = fakeDataItem.GetItems();

            sortItems.SortByPriceAsc(items);

            Assert.AreEqual(1, items[0].ItemId);
            Assert.AreEqual(2, items[1].ItemId);
            Assert.AreEqual(3, items[2].ItemId);
            Assert.AreEqual(4, items[3].ItemId);
        }
        [TestMethod]
        public void TestSortByPriceDesc()
        {
            var sortItems = new SortItems();
            var fakeDataItem = new FakeDataItem();
            var items = fakeDataItem.GetItems();

            sortItems.SortByPriceDesc(items);

            Assert.AreEqual(4, items[0].ItemId);
            Assert.AreEqual(3, items[1].ItemId);
            Assert.AreEqual(2, items[2].ItemId);
            Assert.AreEqual(1, items[3].ItemId);
        }

        [TestMethod]
        public void TestSortByQuantityAsc()
        {
            var sortItems = new SortItems();
            var fakeDataItem = new FakeDataItem();
            var items = fakeDataItem.GetItems();

            sortItems.SortByQuantityAsc(items);

            Assert.AreEqual(1, items[0].ItemId);
            Assert.AreEqual(2, items[1].ItemId);
            Assert.AreEqual(3, items[2].ItemId);
            Assert.AreEqual(4, items[3].ItemId);
        }

        [TestMethod]
        public void TestSortByQuantityDesc()
        {
            var sortItems = new SortItems();
            var fakeDataItem = new FakeDataItem();
            var items = fakeDataItem.GetItems();

            sortItems.SortByQuantityDesc(items);

            Assert.AreEqual(4, items[0].ItemId);
            Assert.AreEqual(3, items[1].ItemId);
            Assert.AreEqual(2, items[2].ItemId);
            Assert.AreEqual(1, items[3].ItemId);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestSortByPriceAsc_Exception_NullItems()
        {
            var sortItems = new SortItems();

            sortItems.SortByPriceAsc(null);

        }
    }
}
