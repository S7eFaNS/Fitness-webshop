using ClassLibrary.Classes.Item;
using ClassLibrary.Classes.User;
using InterfaceLibrary.IRepositories;
using ManagerLibrary.ManagerClasses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.TestData;

namespace UnitTest
{
    [TestClass]
    public class ItemTests
    {
        [TestMethod]
        public void TestGetItems()
        {
            ItemManager itemManager = new(new FakeDataItem());

            List<Item> returnedItems = itemManager.GetItems();

            Assert.AreEqual(returnedItems.Count, 4);
        }

        [TestMethod]
        public void TestGetItems_DomainLogic()
        {
            List<Item> items = new List<Item>
        {
            new Item { ItemId = 1, ItemName ="testTren1",ItemPrice = 10, ItemDescription = "testDataTren1", ItemQuantity = 10, ItemType = ItemType.Supplement },
            new Item { ItemId = 2, ItemName ="testTren2",ItemPrice = 15, ItemDescription = "testDataTren2", ItemQuantity = 20, ItemType = ItemType.Supplement },
            new Item { ItemId = 3, ItemName ="testTren3",ItemPrice = 25, ItemDescription = "testDataTren3", ItemQuantity = 30, ItemType = ItemType.Supplement }
        };

            Mock<IItemRepository> mockRepository = new Mock<IItemRepository>();
            mockRepository.Setup(r => r.GetItems()).Returns(items);

            ItemManager itemManager = new ItemManager(mockRepository.Object);

            List<Item> returnedItems = itemManager.GetItems();

            Assert.AreEqual(items.Count, returnedItems.Count);
            Assert.AreEqual(items[0].ItemId, returnedItems[0].ItemId);
            Assert.AreEqual(items[1].ItemName, returnedItems[1].ItemName);
            Assert.AreEqual(items[2].ItemPrice, returnedItems[2].ItemPrice);
            Assert.AreEqual(items[0].ItemDescription, returnedItems[0].ItemDescription);
        }

        [TestMethod]
        public void TestGetItemById()
        {
            ItemManager itemManager = new(new FakeDataItem());

            int returnedItemId = itemManager.GetItemsById(1).ItemId;

            Assert.AreEqual(returnedItemId, 1);
        }

        [TestMethod, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetItemByIdFail()
        {
            ItemManager itemManager = new ItemManager(new FakeDataItem());

            Item item1 = itemManager.GetItemsById(12);
            Item item2 = itemManager.GetItems()[12];

            Assert.AreEqual(item1, item2);
        }

        [TestMethod]
        public void TestCreateItem()
        {
            var fakeDataItem = new FakeDataItem();
            var item = new Item(5, "testTren5", 50, "testDataTren5", 50, ItemType.Supplement);

            var result = fakeDataItem.CreateItem(item);

            Assert.IsTrue(result);
            CollectionAssert.Contains(fakeDataItem.GetItems(), item);
        }

        [TestMethod]
        public void TestUpdateItem()
        {
            var fakeDataItem = new FakeDataItem();
            var updatedItem = new Item(4, "testTren", 1, "testDataTren", 1, ItemType.Supplement);

            var result = fakeDataItem.UpdateItem(updatedItem);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestDeleteItem()
        {
            var fakeDataItem = new FakeDataItem();
            var item = new Item(3, "testTren3", 30, "testDataTren3", 30, ItemType.Supplement);

            var result = fakeDataItem.DeleteItem(item);

            Assert.IsTrue(result);
            CollectionAssert.DoesNotContain(fakeDataItem.GetItems(), item);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDeleteItemFail()
        {
            var fakeDataItem = new FakeDataItem();
            var item = new Item(8, "testItem8", 80, "testDataItem8", 80, ItemType.Supplement);
            var itemList = fakeDataItem.GetItems()[1];

            fakeDataItem.DeleteItem(item);

            Assert.AreNotEqual(itemList, fakeDataItem.GetItems()[3]);
        }

        [TestMethod]
        public void SearchItems()
        {
            var fakeDataItem = new FakeDataItem();
            var item1 = new Item(1, "testTren1", 10, "testDataTren1", 10, ItemType.Supplement);
            var item2 = new Item(2, "testTren2", 20, "testDataTren2", 20, ItemType.Supplement);
            var item3 = new Item(3, "testTren3", 30, "testDataTren3", 30, ItemType.Supplement);
            var item4 = new Item(4, "testTren4", 40, "testDataTren4", 40, ItemType.Supplement);

            var result = fakeDataItem.SearchItems("testTren2");

            bool isItem2Found = result.Any(i => i.ItemName == item2.ItemName);
            Assert.IsTrue(isItem2Found);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestSearchItemsFail()
        {
            var fakeDataItem = new FakeDataItem();

            var result = fakeDataItem.SearchItems("nonexistentItem");

            Assert.AreEqual(0, result.Count);
        }
    }
}
