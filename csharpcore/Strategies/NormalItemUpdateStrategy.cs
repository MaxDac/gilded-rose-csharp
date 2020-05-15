namespace csharpcore.Strategies
{
    public class NormalItemUpdateStrategy : IUpdateStrategy
    {
        public Item UpdateItemStandard(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
            
            return item;
        }
    }
}