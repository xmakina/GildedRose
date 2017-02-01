using GildedRose.Console;
using GildedRose.Console.Handlers;
using Xunit;

namespace GildedRose.Tests
{
    public class WhenUpdatingConcertTickets
    {
        [Fact]
        public void UpdateTicketsBeforeSellIn()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(14, item.SellIn);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void UpdateTicketsTenDaysBeforeSellIn()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 25 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(9, item.SellIn);
            Assert.Equal(27, item.Quality);
        }

        [Fact]
        public void UpdateTicketsFiveDaysBeforeSellIn()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 35 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(4, item.SellIn);
            Assert.Equal(38, item.Quality);
        }

        [Fact]
        public void UpdateTicketsAfterSellIn()
        {
            var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 };
            var command = new UpdateItemCommand { Item = item };
            var handler = new UpdateItemCommandHandler();
            item = handler.Handle(command);

            Assert.Equal(-1, item.SellIn);
            Assert.Equal(0, item.Quality);
        }
    }
}