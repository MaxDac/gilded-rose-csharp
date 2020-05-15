namespace csharpcore.Strategies
{
    public class BackstagePassUpdateStrategy : IUpdateStrategy
    {
        public override Item UpdateItemStandard(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
            
            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
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
            item.Quality = item.Quality - item.Quality;
            return item;
        }
    }
}