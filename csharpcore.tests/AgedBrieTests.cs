using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class AgedBrieTests
    {
        private const string AGED_BRIE_NAME = "Aged Brie";
        
        [Fact]
        public void AgedBrieIncreaseQualityWithTime()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = AGED_BRIE_NAME, SellIn = 4, Quality = 4 } });
            app.UpdateQuality();
            Assert.Equal(AGED_BRIE_NAME, app.GetItems()[0].Name);
            Assert.Equal(5, app.GetItems()[0].Quality);
            Assert.Equal(3, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void AgedBrieDoNotIncreaseQualityAfterFifty()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = AGED_BRIE_NAME, SellIn = 4, Quality = 50 } });
            app.UpdateQuality();
            Assert.Equal(AGED_BRIE_NAME, app.GetItems()[0].Name);
            Assert.Equal(50, app.GetItems()[0].Quality);
            Assert.Equal(3, app.GetItems()[0].SellIn);
        }
    }
}