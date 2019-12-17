using System;
using System.Collections.Generic;
using GildedRoseApp.Console;
using Xunit;

namespace GildedRoseApp.Console.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void CanSetAndReadItems()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(items);

            Assert.Equal("foo", items[0].Name);
        }

        [Fact]
        public void NormalItemAfterOneDay_QualityAndSellInDecrementedByOne()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            // Quality should be 9
            Assert.Equal(9, items[0].Quality);
            // SellIn should be 9
            Assert.Equal(9, items[0].SellIn);
        }

        [Fact]
        public void NormalItemAfterSellIn_QualityDecrementedByTwo()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void QualityCanNeverBeNegative()
        {
            IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void AgedBrieGetsBetterWithAge()
        {
            IList<Item> items = new List<Item> { new Item { Name = Constants.AgedBrie, SellIn = 10, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void ItemQualityCannotBeGreaterThanFifty()
        {
            IList<Item> items = new List<Item> { new Item { Name = Constants.AgedBrie, SellIn = 10, Quality = 50 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void SulfurasValuesDoNotChange()
        {
            IList<Item> items = new List<Item> { new Item { Name = Constants.Sulfuras, SellIn = 0, Quality = 80 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_GreaterThan10Days_QualityIncreasesByOne()
        {
            IList<Item> items = new List<Item> { new Item { Name = Constants.BackstagePasses, SellIn = 12, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void BackstagePasses_LessThanOrEqual10DaysButGreaterThanFive_QualityIncreasesByTwo()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = Constants.BackstagePasses, SellIn = 11, Quality = 10 },
                new Item { Name = Constants.BackstagePasses, SellIn = 6, Quality = 10 }
            };
            var app = new GildedRose(items);
            app.UpdateQuality();

            // 10 days
            Assert.Equal(12, items[0].Quality);
            // 5 days
            Assert.Equal(13, items[1].Quality);
        }

        [Fact]
        public void BackstagePasses_LessThanOrEqual5DaysButGreaterThanZero_QualityIncreasesByThree()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = Constants.BackstagePasses, SellIn = 5, Quality = 10 },
                new Item { Name = Constants.BackstagePasses, SellIn = 1, Quality = 10 }
            };
            var app = new GildedRose(items);
            app.UpdateQuality();

            // 5 days
            Assert.Equal(13, items[0].Quality);
            // 1 days
            Assert.Equal(13, items[1].Quality);
        }

        [Fact]
        public void BackstagePasses_AfterShowPasses_QualityEqualsZero()
        {
            IList<Item> items = new List<Item> {
                new Item { Name = Constants.BackstagePasses, SellIn = 0, Quality = 10 }
            };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void ConjuredItemsDegradeTwoPerDay_PositiveSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = Constants.ConjuredManaCake, SellIn = 10, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void ConjuredItemsDegradeTwoPerDay_NegativeSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = Constants.ConjuredManaCake, SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items);
            app.UpdateQuality();

            Assert.Equal(6, items[0].Quality);
        }
    }
}
