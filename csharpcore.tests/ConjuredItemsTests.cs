using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class ConjuredItemsTests
    {
        private const string CONJURED_ITEM_NAME = "Conjured";

        [Fact]
        public void ConjuredItemsLoseValueTwicePerDay()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = CONJURED_ITEM_NAME, SellIn = 5, Quality = 10 } });
            app.UpdateQuality();
            Assert.Equal(CONJURED_ITEM_NAME, app.GetItems()[0].Name);
            Assert.Equal(8, app.GetItems()[0].Quality);
            Assert.Equal(4, app.GetItems()[0].SellIn);
        }

        [Fact]
        public void ConjuredItemsLoseValueTwicePerDayAfterSellIn()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = CONJURED_ITEM_NAME, SellIn = 0, Quality = 10 } });
            app.UpdateQuality();
            Assert.Equal(CONJURED_ITEM_NAME, app.GetItems()[0].Name);
            Assert.Equal(6, app.GetItems()[0].Quality);
            Assert.Equal(-1, app.GetItems()[0].SellIn);
        }
    }
}