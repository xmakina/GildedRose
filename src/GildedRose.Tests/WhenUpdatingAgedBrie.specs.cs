using System;
using GildedRose.Console;
using GildedRose.Console.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class WhenUpdatingAgedBrie
    {
        [TestMethod]
        public void UpdateAgedBrieBeforeSellIn()
        {
            var agedBrie = new Item {Name = "Aged Brie", SellIn = 2, Quality = 0};
            var command = new UpdateItemCommand {Item = agedBrie};
            var handler = new UpdateItemCommandHandler();
            agedBrie = handler.Handle(command);

            Assert.AreEqual(1, agedBrie.Quality);
            Assert.AreEqual(1, agedBrie.SellIn);
        }

        [TestMethod]
        public void UpdateAgedBrieAfterSellIn()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = 0, Quality = 2 };
            var command = new UpdateItemCommand { Item = agedBrie };
            var handler = new UpdateItemCommandHandler();
            agedBrie = handler.Handle(command);

            Assert.AreEqual(4, agedBrie.Quality);
            Assert.AreEqual(-1, agedBrie.SellIn);
        }

        [TestMethod]
        public void UpdateAgedBrieAtMaxQuality()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = -24, Quality = 50 };
            var command = new UpdateItemCommand { Item = agedBrie };
            var handler = new UpdateItemCommandHandler();
            agedBrie = handler.Handle(command);

            Assert.AreEqual(50, agedBrie.Quality);
            Assert.AreEqual(-25, agedBrie.SellIn);
        }
    }
}
