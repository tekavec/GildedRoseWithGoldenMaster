namespace GildedRoseWithGoldenMaster
{
    public static class ItemFactory
    {
        private static bool IsABackStagePass(this Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static bool IsAgedBrie(this Item item)
        {
            return item.Name == "Aged Brie";
        }

        internal static ItemBase CreateItem(Item item)
        {
            if (item.IsAgedBrie())
            {
                return new AgedBrie(item);
            }
            if (item.IsABackStagePass())
            {
                return new BackStagePass(item);
            }
            return new NormalItem(item);
        }
    }
}