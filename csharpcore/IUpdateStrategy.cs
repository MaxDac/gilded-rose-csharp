using System.Collections.Generic;
using csharpcore.Strategies;

namespace csharpcore
{
    public abstract class IUpdateStrategy
    {
        /// <summary>
        /// This method updates the item characteristics before updating the SellIn property
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item.</returns>
        public abstract Item UpdateItemStandard(Item item);

        /// <summary>
        /// This method updates the expiration of the item.
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item.</returns>
        public abstract Item UpdateExpiration(Item item);

        /// <summary>
        /// This method updates an item whose SellIn property is less than 0.
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item</returns>
        public abstract Item UpdateExpiredItem(Item item);

        /// <summary>
        /// Updates the item for a day.
        /// </summary>
        /// <param name="item">The item to be updated.</param>
        /// <returns>The updated item</returns>
        public Item UpdateItem(Item item)
        {
            item = this.UpdateItemStandard(item);

            item = this.UpdateExpiration(item);

            if (item.SellIn < 0)
            {
                item = this.UpdateExpiredItem(item);
            }

            return item;
        }
        
        private const string AGED_BRIE_NAME = "Aged Brie";
        private const string BACKSTAGE_PASS_NAME = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
        private const string CONJURED_NAME = "Conjured";

        public static Dictionary<string, IUpdateStrategy> GetStrategies() =>
            new Dictionary<string, IUpdateStrategy>
            {
                {AGED_BRIE_NAME, new AgedBrieUpdateStrategy()},
                {SULFURAS_NAME, new SulfurasUpdateStrategy()},
                {BACKSTAGE_PASS_NAME, new BackstagePassUpdateStrategy()},
                {CONJURED_NAME, new ConjuredItemUpdateStrategy()},
                {"Normal", new NormalItemUpdateStrategy()}
            };

        public static IUpdateStrategy StrategySelector(Item item, Dictionary<string, IUpdateStrategy> strategies) =>
            strategies.ContainsKey(item.Name) ? strategies[item.Name] : strategies["Normal"];
    }
}