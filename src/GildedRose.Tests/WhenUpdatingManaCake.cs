using GildedRose.Console;
using GildedRose.Console.Handlers;
using Xunit;

namespace GildedRose.Tests
{
    public class WhenUpdatingManaCake
    {
        [Fact]
        public void UpdateManaCakeBeforeSellIn()
        {
            var item = new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(2, item.SellIn);
            Assert.Equal(4, item.Quality);
        }
    }
}