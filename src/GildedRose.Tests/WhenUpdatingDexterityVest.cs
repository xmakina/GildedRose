using GildedRose.Console;
using GildedRose.Console.Handlers;
using Xunit;

namespace GildedRose.Tests
{
    public class WhenUpdatingDexterityVest
    {
        [Fact]
        public void UpdateVestBeforeSellIn()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(9, item.SellIn);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void UpdateVestAfterSellIn()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void UpdateVestAfterNoQuality()
        {
            var item = new Item { Name = "+5 Dexterity Vest", SellIn = -5, Quality = 0 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(-6, item.SellIn);
            Assert.Equal(0, item.Quality);
        }
    }
}