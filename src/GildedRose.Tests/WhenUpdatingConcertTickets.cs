using GildedRose.Console;
using GildedRose.Console.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class WhenUpdatingConcertTickets
    {
        [TestMethod]
        public void UpdateTicketsBeforeSellIn()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(14, item.SellIn);
            Assert.AreEqual(21, item.Quality);
        }

        [TestMethod]
        public void UpdateTicketsTenDaysBeforeSellIn()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 25 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(9, item.SellIn);
            Assert.AreEqual(27, item.Quality);
        }

        [TestMethod]
        public void UpdateTicketsFiveDaysBeforeSellIn()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 35 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(4, item.SellIn);
            Assert.AreEqual(38, item.Quality);
        }

        [TestMethod]
        public void UpdateTicketsAfterSellIn()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(-1, item.SellIn);
            Assert.AreEqual(0, item.Quality);
        }
    }
}