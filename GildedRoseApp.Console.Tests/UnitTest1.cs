using System;
using System.Collections.Generic;
using ConsoleApplication;
using GildedRoseApp.console;
using Xunit;

namespace GildedRoseApp.Console.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanSetandReadItems()
        {
            IList<IItem> Items = new List<IItem> { new StandardItem { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new Program(Items);

            Assert.Equal("foo", app.GetItems()[0].Name);
        }

        [Fact]
        public void NormalItemAfterOneDay_QualityandSellInDecrementedByOne()
        {
            IList<IItem> Items = new List<IItem> { new StandardItem { Name = "foo", SellIn = 10, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            // Quality should be 9
            Assert.Equal(9, app.GetItems()[0].Quality);
            // SellIn should be 9
            Assert.Equal(9, app.GetItems()[0].SellIn);
        }

        [Fact]
        public void NormalItemAfterSellIn_QualityDecrementedByTwo()
        {
            IList<IItem> Items = new List<IItem> { new StandardItem { Name = "foo", SellIn = 0, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(8, app.GetItems()[0].Quality);
        }

        [Fact]
        public void QualityCanNeverBeNegative()
        {
            IList<IItem> Items = new List<IItem> { new StandardItem { Name = "foo", SellIn = 10, Quality = 0 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(0, app.GetItems()[0].Quality);
        }

        [Fact]
        public void AgedBrieGetsBetterWithAge()
        {
            IList<IItem> Items = new List<IItem> { new AgedBrieItem { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(1, app.GetItems()[0].Quality);
        }

        [Fact]
        public void ItemQualityCannotBeGreaterThanFifty()
        {
            IList<IItem> Items = new List<IItem> { new AgedBrieItem { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void SulfurasValuesDoNotChange()
        {
            IList<IItem> Items = new List<IItem> { new SulfurasItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(80, app.GetItems()[0].Quality);
        }

        [Fact]
        public void BackstagePasses_GreaterThan10Days_QualityIncreasesByOne()
        {
            IList<IItem> Items = new List<IItem> { new BackStagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(11, app.GetItems()[0].Quality);
        }

        [Fact]
        public void BackstagePasses_LessThanOrEqual10DaysButGreaterThanFive_QualityIncreasesByTwo()
        {
            IList<IItem> Items = new List<IItem> {
                new BackStagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 },
                new BackStagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 }
            };
            var app = new Program(Items);
            app.UpdateQuality();

            // 10 days
            Assert.Equal(12, app.GetItems()[0].Quality);
            // 5 days
            Assert.Equal(13, app.GetItems()[1].Quality);
        }

        [Fact]
        public void BackstagePasses_LessThanOrEqual5DaysButGreaterThanZero_QualityIncreasesByThree()
        {
            IList<IItem> Items = new List<IItem> {
                new BackStagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new BackStagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 }
            };
            var app = new Program(Items);
            app.UpdateQuality();

            // 5 days
            Assert.Equal(13, app.GetItems()[0].Quality);
            // 1 days
            Assert.Equal(13, app.GetItems()[1].Quality);
        }

        [Fact]
        public void BackstagePasses_AfterShowPasses_QualityEqualsZero()
        {
            IList<IItem> Items = new List<IItem> {
                new BackStagePassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }
            };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(0, app.GetItems()[0].Quality);
        }

        [Fact]
        public void ConjuredItemsDegradeTwoPerDay_PositiveSellIn()
        {
            IList<IItem> Items = new List<IItem> { new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(8, app.GetItems()[0].Quality);
        }

        [Fact]
        public void ConjuredItemsDegradeTwoPerDay_NegativeSellIn()
        {
            IList<IItem> Items = new List<IItem> { new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(6, app.GetItems()[0].Quality);
        }
    }
}
