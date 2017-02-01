using GildedRose.Console;
using GildedRose.Console.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class WhenUpdatingDexterityVest
    {
        [TestMethod]
        public void UpdateVestBeforeSellIn()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(9, item.SellIn);
            Assert.AreEqual(19, item.Quality);
        }

        [TestMethod]
        public void UpdateVestAfterSellIn()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(-1, item.SellIn);
            Assert.AreEqual(8, item.Quality);
        }

        [TestMethod]
        public void UpdateVestAfterNoQuality()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = -5, Quality = 0 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(-6, item.SellIn);
            Assert.AreEqual(0, item.Quality);
        }
    }
}