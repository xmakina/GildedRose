using System;

namespace GildedRose.Console.Handlers
{
    public class UpdateItemCommand
    {
        public Item Item;
    }

    public class UpdateItemCommandHandler
    {
        public Item Handle(UpdateItemCommand command)
        {
            var item = command.Item;

            if (item.Name == "Aged Brie")
            {
                item.Quality++;
                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality++;
                }

                if (item.Quality > 50)
                {
                    item.Quality = 50;
                }
            }

            if (item.Name == "+5 Dexterity Vest" || item.Name == "Elixir of the Mongoose" || item.Name == "Conjured Mana Cake")
            {
                item.Quality--;
                item.SellIn--;

                if (item.SellIn < 0)
                {
                    item.Quality--;
                }

                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }

            if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                item.Quality++;
                item.SellIn--;

                if (item.SellIn < 10)
                {
                    item.Quality++;
                }

                if (item.SellIn < 5)
                {
                    item.Quality++;
                }

                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
            }

            return item;
        }
    }
}