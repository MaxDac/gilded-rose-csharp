namespace csharpcore.Strategies
{
    public class SulfurasUpdateStrategy : IUpdateStrategy
    {
        public Item UpdateItemStandard(Item item)
        {
            return item;
        }

        public Item UpdateExpiredItem(Item item)
        {
            return item;
        }
    }
}