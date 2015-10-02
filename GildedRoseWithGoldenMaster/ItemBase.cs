namespace GildedRoseWithGoldenMaster
{
    public abstract class ItemBase
    {
        private const int MaxQuality = 50;
        protected virtual int QualityChangeRate { get { return 1; } }
        protected virtual int SellInChangeRate { get { return 1; } }
        protected virtual int DaysBeforeExpiration { get { return _item.SellIn; } }

        public abstract void UpdateQualityBeforeExpired();
        public abstract void UpdateQualityAfterExpired();

        private readonly Item _item;

        protected ItemBase(Item item)
        {
            _item = item;
        }

        protected void DecreaseQuality()
        {
            if (_item.Quality > 0)
                _item.Quality -= QualityChangeRate;
        }

        protected bool IsNDaysBeforeExpiration(int numberOfDays)
        {
            return DaysBeforeExpiration < numberOfDays + 1;
        }

        protected void IncreaseQuality()
        {
            if (_item.Quality < MaxQuality)
                _item.Quality += QualityChangeRate;
        }

        protected void ResetQuality()
        {
            _item.Quality = 0;
        }

        public void DecreaseSellIn()
        {
            _item.SellIn -= SellInChangeRate;
        }

        protected bool ItemIsExpired()
        {
            return IsNDaysBeforeExpiration(-1);
        }

    }
}