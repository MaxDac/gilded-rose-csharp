using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class BackstagePassesTests
    {
        private const string BACKSTAGE_PASSES_NAME = "Backstage passes to a TAFKAL80ETC concert";
        
        [Fact]
        public void BackstagePassesIncreaseValueBeforeTheConcert()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 15, Quality = 10 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(11, app.GetItems()[0].Quality);
            Assert.Equal(14, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassesIncreaseValueTwiceTenDaysBeforeTheConcert()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 10, Quality = 10 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(12, app.GetItems()[0].Quality);
            Assert.Equal(9, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassesIncreaseValueTwiceNineDaysBeforeTheConcert()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 9, Quality = 10 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(12, app.GetItems()[0].Quality);
            Assert.Equal(8, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassesIncreaseValueThriceFiveDaysBeforeTheConcert()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 5, Quality = 10 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(13, app.GetItems()[0].Quality);
            Assert.Equal(4, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassesIncreaseValueThriceFourDaysBeforeTheConcert()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 4, Quality = 10 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(13, app.GetItems()[0].Quality);
            Assert.Equal(3, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassesLoseValueAfterTheConcert()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 0, Quality = 10 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(0, app.GetItems()[0].Quality);
            Assert.Equal(-1, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassesQualityDoesNotIncreaseAfterFifty()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 11, Quality = 50 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(50, app.GetItems()[0].Quality);
            Assert.Equal(10, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassesQualityDoesNotIncreaseAfterFiftyBeforeTenDays()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 10, Quality = 50 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(50, app.GetItems()[0].Quality);
            Assert.Equal(9, app.GetItems()[0].SellIn);
        }
        
        [Fact]
        public void BackstagePassesQualityDoesNotIncreaseAfterFiftyBeforeFiveDays()
        {
            var app = new GildedRose(
                new List<Item> { new Item { Name = BACKSTAGE_PASSES_NAME, SellIn = 5, Quality = 50 } });
            app.UpdateQuality();
            Assert.Equal(BACKSTAGE_PASSES_NAME, app.GetItems()[0].Name);
            Assert.Equal(50, app.GetItems()[0].Quality);
            Assert.Equal(4, app.GetItems()[0].SellIn);
        }
    }
}