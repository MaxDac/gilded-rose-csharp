namespace csharpcore.Strategies
{
    public class ConjuredItemUpdateStrategy : IUpdateStrategy
    {
        public override Item UpdateItemStandard(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 2;
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
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 2;
            }

            return item;
        }
    }
}