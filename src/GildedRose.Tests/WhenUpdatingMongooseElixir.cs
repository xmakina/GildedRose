using GildedRose.Console;
using GildedRose.Console.Handlers;
using Xunit;

namespace GildedRose.Tests
{
    public class WhenUpdatingMongooseElixir
    {
        [Fact]
        public void UpdateElixirBeforeSellIn()
        {
            var item = new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(6, item.Quality);
        }
    }
}