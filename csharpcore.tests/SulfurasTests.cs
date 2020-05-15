using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class SulfurasTests
    {
        private const string SULFURAS_NAME = "Sulfuras, Hand of Ragnaros";
        
        [Fact]
        public void SulfurasItemsDoNotIncreaseQualityOrSellInProperty()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = SULFURAS_NAME, SellIn = 4, Quality = 50 } });
            app.UpdateQuality();
            Assert.Equal(SULFURAS_NAME, app.GetItems()[0].Name);
            Assert.Equal(50, app.GetItems()[0].Quality);
            Assert.Equal(4, app.GetItems()[0].SellIn);
        }
    }
}
