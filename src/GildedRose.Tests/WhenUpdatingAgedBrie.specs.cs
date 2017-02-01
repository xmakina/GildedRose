using GildedRose.Console;
using GildedRose.Console.Handlers;
using Xunit;

namespace GildedRose.Tests
{
    public class WhenUpdatingAgedBrie
    {
        [Fact]
        public void UpdateAgedBrieBeforeSellIn()
        {
            var agedBrie = new Item {Name = "Aged Brie", SellIn = 2, Quality = 0};
            var command = new UpdateItemCommand {Item = agedBrie};
            var handler = new UpdateItemCommandHandler();
            agedBrie = handler.Handle(command);

            Assert.Equal(1, agedBrie.Quality);
            Assert.Equal(1, agedBrie.SellIn);
        }

        [Fact]
        public void UpdateAgedBrieAfterSellIn()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = 0, Quality = 2 };
            var command = new UpdateItemCommand { Item = agedBrie };
            var handler = new UpdateItemCommandHandler();
            agedBrie = handler.Handle(command);

            Assert.Equal(4, agedBrie.Quality);
            Assert.Equal(-1, agedBrie.SellIn);
        }

        [Fact]
        public void UpdateAgedBrieAtMaxQuality()
        {
            var agedBrie = new Item { Name = "Aged Brie", SellIn = -24, Quality = 50 };
            var command = new UpdateItemCommand { Item = agedBrie };
            var handler = new UpdateItemCommandHandler();
            agedBrie = handler.Handle(command);

            Assert.Equal(50, agedBrie.Quality);
            Assert.Equal(-25, agedBrie.SellIn);
        }
    }
}
