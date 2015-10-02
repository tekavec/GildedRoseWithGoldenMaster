namespace GildedRoseWithGoldenMaster
{
    public class NormalItem : ItemBase
    {
        public NormalItem(Item item) : base(item) { }

        public override void UpdateQualityBeforeExpired()
        {
            DecreaseQuality();
        }

        public override void UpdateQualityAfterExpired()
        {
            if (ItemIsExpired())
            {
                DecreaseQuality();
            }
        }
    }
}