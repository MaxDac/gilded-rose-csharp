using System;
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

        private Dictionary<string, IUpdateStrategy> GetStrategies()
        {
            var dict = new Dictionary<string, IUpdateStrategy>();
            dict.Add(AGED_BRIE_NAME, new AgedBrieUpdateStrategy());
            dict.Add(SULFURAS_NAME, new SulfurasUpdateStrategy());
            dict.Add(BACKSTAGE_PASS_NAME, new BackstagePassUpdateStrategy());
            dict.Add("Normal", new NormalItemUpdateStrategy());
            return dict;
        }

        private IUpdateStrategy StrategySelector(Item item, Dictionary<string, IUpdateStrategy> strategies) =>
            strategies.ContainsKey(item.Name) ? strategies[item.Name] : strategies["Normal"];

        public void UpdateQuality()
        {
            var strategies = this.GetStrategies();
            
            for (var i = 0; i < Items.Count; i++)
            {
                var strategy = this.StrategySelector(Items[i], strategies);
                Items[i] = strategy.UpdateItem(Items[i]);
            }
        }
    }
}
