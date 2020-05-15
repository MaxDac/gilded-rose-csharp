using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void NormalItemWithZeroQualityDoNotDecreaseQuality()
        {
            var app = new GildedRose(new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } });
            app.UpdateQuality();
            Assert.Equal("foo", app.GetItems()[0].Name);
            Assert.Equal(0, app.GetItems()[0].Quality);
            Assert.Equal(-1, app.GetItems()[0].SellIn);
        }

        [Fact]
        public void NormalItemDecreaseQuality()
        {
            var app = new GildedRose(new List<Item> { new Item { Name = "foo", SellIn = 4, Quality = 4 } });
            app.UpdateQuality();
            Assert.Equal("foo", app.GetItems()[0].Name);
            Assert.Equal(3, app.GetItems()[0].Quality);
            Assert.Equal(3, app.GetItems()[0].SellIn);
        }

        [Fact]
        public void NormalItemDecreaseQualityTwiceAsFastAfterExpiration()
        {
            var app = new GildedRose(new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 4 } });
            app.UpdateQuality();
            Assert.Equal("foo", app.GetItems()[0].Name);
            Assert.Equal(2, app.GetItems()[0].Quality);
            Assert.Equal(-1, app.GetItems()[0].SellIn);
        }
    }
}