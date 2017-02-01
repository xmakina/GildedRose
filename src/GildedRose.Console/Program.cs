using System.Collections.Generic;
using System.IO;
using System.Text;
using GildedRose.Console.Handlers;

namespace GildedRose.Console
{
    internal class ReportableItem : Item
    {
        public override string ToString()
        {
            return string.Format("Name: {0}, SellIn: {1}, Quality: {2}", Name, SellIn, Quality);
        }
    }

    internal class Program
    {
        // do not alter the Item class or Items property as those belong to the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code ownership
        private IList<Item> items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
                          {
                              items = new List<Item>
                                          {
                                              new ReportableItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new ReportableItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new ReportableItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new ReportableItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new ReportableItem
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new ReportableItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }

                          };

            var items = new StringBuilder();

            using (var file = new StreamWriter(@"\hereIam.txt"))
            {
                for (var i = 0; i < 50; i++)
                {
                    foreach (var appItem in app.items)
                    {
                        items.AppendLine(appItem.ToString());
                    }

                    app.UpdateQuality();
                }

                file.WriteLine(items.ToString());
            }
        }

        public void UpdateQuality()
        {
            var handler = new UpdateItemCommandHandler();

            for (var i = 0; i < items.Count; i++)
            {
                var command = new UpdateItemCommand {Item = items[i]};
                items[i] = handler.Handle(command);
            }
        }
    }
}
