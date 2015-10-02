namespace GildedRoseWithGoldenMaster
{
    public class BackStagePass : ItemBase
    {
        public BackStagePass(Item item) :base(item) {}

        public override void UpdateQualityBeforeExpired()
        {
            if (IsNDaysBeforeExpiration(5))
            {
                IncreaseQuality();
            }
            if (IsNDaysBeforeExpiration(10))
            {
                IncreaseQuality();
            }
            IncreaseQuality();
        }

        public override void UpdateQualityAfterExpired()
        {
            if (ItemIsExpired())
            {
                ResetQuality();
            }
        }

    }
}