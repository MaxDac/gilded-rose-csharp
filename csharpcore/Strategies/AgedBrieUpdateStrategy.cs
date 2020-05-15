namespace csharpcore.Strategies
{
    public class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        public Item UpdateItemStandard(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            return item;
        }

        public Item UpdateExpiredItem(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            return item;
        }
    }
}