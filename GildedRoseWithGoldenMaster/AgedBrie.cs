namespace GildedRoseWithGoldenMaster
{
    public class AgedBrie : ItemBase
    {

        public AgedBrie(Item item) : base(item) { }

        public override void UpdateQualityBeforeExpired()
        {
            IncreaseQuality();
        }

        public override void UpdateQualityAfterExpired()
        {
            if (ItemIsExpired())
            {
                IncreaseQuality();
            }
        }
    }
}