using System;
using System.Collections.Generic;
using csharpcore.Strategies;

namespace csharpcore
{
    public class GildedRose
    {
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

        public void UpdateQuality()
        {
            var strategies = IUpdateStrategy.GetStrategies();
            
            for (var i = 0; i < Items.Count; i++)
            {
                var strategy = IUpdateStrategy.StrategySelector(Items[i], strategies);
                Items[i] = strategy.UpdateItem(Items[i]);
            }
        }
    }
}
