using GildedRose.Console;
using GildedRose.Console.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Tests
{
    [TestClass]
    public class WhenUpdatingMongooseElixir
    {
        [TestMethod]
        public void UpdateElixirBeforeSellIn()
        {
            var item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.AreEqual(4, item.SellIn);
            Assert.AreEqual(6, item.Quality);
        }
    }
}