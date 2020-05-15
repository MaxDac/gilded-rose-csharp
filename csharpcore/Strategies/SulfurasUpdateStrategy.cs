namespace csharpcore.Strategies
{
    public class SulfurasUpdateStrategy : IUpdateStrategy
    {
        public override Item UpdateItemStandard(Item item)
        {
            return item;
        }

        public override Item UpdateExpiration(Item item)
        {
            return item;
        }

        public override Item UpdateExpiredItem(Item item)
        {
            return item;
        }
    }
}