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

        // private Item UpdateQualityStandard(Item item)
        // {
        //     if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
        //     {
        //         if (item.Quality > 0)
        //         {
        //             if (item.Name != "Sulfuras, Hand of Ragnaros")
        //             {
        //                 item.Quality = item.Quality - 1;
        //             }
        //         }
        //     }
        //     else
        //     {
        //         if (item.Quality < 50)
        //         {
        //             item.Quality = item.Quality + 1;
        //
        //             if (item.Name == )
        //             {
        //                 if (item.SellIn < 11)
        //                 {
        //                     if (item.Quality < 50)
        //                     {
        //                         item.Quality = item.Quality + 1;
        //                     }
        //                 }
        //
        //                 if (item.SellIn < 6)
        //                 {
        //                     if (item.Quality < 50)
        //                     {
        //                         item.Quality = item.Quality + 1;
        //                     }
        //                 }
        //             }
        //         }
        //     }
        //
        //     return item;
        // }

        private Item UpdateQualityAfterSellInUpdate(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }

            return item;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                // this.Items[i] = this.UpdateQualityStandard(this.Items[i]);
                var strategy = this.StrategySelector(Items[i]);
                this.Items[i] = strategy.UpdateItemStandard(this.Items[i]);
                
                if (Items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                this.Items[i] = this.UpdateQualityAfterSellInUpdate(this.Items[i]);
            }
        }
    }
}
