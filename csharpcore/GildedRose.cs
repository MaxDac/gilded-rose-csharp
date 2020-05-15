using System.Collections.Generic;
using csharpcore.Strategies;

namespace csharpcore
{
    public class GildedRose
    {
        private const string AGED_BRIE_NAME = "Aged Brie";
        private const string BACKSTAGE_PASS_NAME = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
        
        IList<Item> Items;
        
        // The property should be accessed from the class, not by retaining the reference in the item sent to the 
        // constructor
        //
        // No syntactic sugar with get: because by problem definition the property *Items* must not be touched.
        public IList<Item> GetItems() => this.Items;
        
        public GildedRose(IList<Item> items)
        {
            this.Items = items;
        }

        private IUpdateStrategy StrategySelector(Item item)
        {
            switch (item.Name)
            {
                case AGED_BRIE_NAME: return new AgedBrieUpdateStrategy();
                case SULFURAS_NAME: return new SulfurasUpdateStrategy();
                case BACKSTAGE_PASS_NAME: return new BackstagePassUpdateStrategy();
                default: return new NormalItemUpdateStrategy();
            }
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var strategy = this.StrategySelector(Items[i]);
                Items[i] = strategy.UpdateItem(Items[i]);
            }
        }
    }
}
