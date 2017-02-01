using GildedRose.Console;
using GildedRose.Console.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class WhenUpdatingManaCake
    {
        [TestMethod]
        public void UpdateManaCakeBeforeSellIn()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(2, item.SellIn);
            Assert.AreEqual(5, item.Quality);
        }
    }
}