namespace csharpcore.Strategies
{
    public class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        public override Item UpdateItemStandard(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            return item;
        }

        public override Item UpdateExpiration(Item item)
        {
            item.SellIn = item.SellIn - 1;
            return item;
        }

        public override Item UpdateExpiredItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            return item;
        }
    }
}