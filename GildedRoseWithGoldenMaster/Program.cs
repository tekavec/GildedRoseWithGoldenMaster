using System.Collections.Generic;
using System.Linq;

namespace GildedRoseWithGoldenMaster
{
    internal class Program
    {
        private IList<Item> Items;

        private static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = CreateItems()
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        private static List<Item> CreateItems()
        {
            return new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        public void UpdateQuality()
        {
            TestableUpdateQuality(Items);
        }

        internal static void TestableUpdateQuality(IList<Item> items)
        {
            foreach (var item in items.Select(ItemFactory.CreateItem))
            {
                item.UpdateQualityBeforeExpired();
                item.DecreaseSellIn();
                item.UpdateQualityAfterExpired();
            }
        }
    }
}