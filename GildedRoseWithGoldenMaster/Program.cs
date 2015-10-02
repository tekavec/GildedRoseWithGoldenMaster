using System.Collections.Generic;

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
            foreach (var item in items)
            {
                item.IncreaseQualityOfAgedBrie();
                item.IncreaseQualityOfTickes();
                item.DecreaseQualityOfDefaultItem();

                if (!item.IsSulfuras())
                {
                    item.DecreaseSellIn();
                }
                
                if (item.ItemIsExpired())
                {
                    item.IncreaseQualityOfAgedBrie();
                    item.ResetQualityOfTicket();
                    item.DecreaseQualityOfDefaultItem();
                }
            }
        }
    }

    public static class ItemExtensions
    {
        public static void DecreaseQuality(this Item item)
        {
            if (item.Quality > 0)
                item.Quality += -1;
        }

        public static void IncreaseQuality(this Item item)
        {
            if (item.Quality < MaxQuality)
                item.Quality += 1;
        }

        public static void ResetQuality(this Item item)
        {
            item.Quality = 0;
        }

        public static bool IsATicket(this Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public static bool IsSulfuras(this Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }

        public static bool IsAgedBrie(this Item item)
        {
            return item.Name == "Aged Brie";
        }

        public const int MaxQuality = 50;

        public static bool ItemIsExpired(this Item item)
        {
            return item.SellIn < 0;
        }

        public static void DecreaseSellIn(this Item item)
        {
            item.SellIn = item.SellIn - 1;
        }

        public static void IncreaseQualityOfTickes(this Item item)
        {
            if (item.IsATicket())
            {
                item.IncreaseQuality();

                if (item.SellIn < 11)
                {
                    item.IncreaseQuality();
                }
                if (item.SellIn < 6)
                {
                    item.IncreaseQuality();
                }
            }
        }

        public static void DecreaseQualityOfDefaultItem(this Item item)
        {
            if (IsDefaultItem(item))
            {   
                item.DecreaseQuality();
            }
        }

        private static bool IsDefaultItem(Item item)
        {
            return !item.IsAgedBrie() &&
                   !item.IsATicket() &&
                   !item.IsSulfuras();
        }

        public static void ResetQualityOfTicket(this Item item)
        {
            if (item.IsATicket())
            {
                item.ResetQuality();
            }
        }

        public static void IncreaseQualityOfAgedBrie(this Item item)
        {
            if (item.IsAgedBrie())
            {
                item.IncreaseQuality();
            }
        }
    }
}