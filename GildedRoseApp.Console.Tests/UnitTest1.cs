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
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new Program(Items);

            Assert.Equal("foo", app.GetItems()[0].Name);
        }

        [Fact]
        public void NormalItemAfterOneDay_QualityandSellInDecrementedByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            // Quality should be 9
            Assert.Equal(9, app.GetItems()[0].Quality);
            // SellIn should be 9
            Assert.Equal(9, app.GetItems()[0].SellIn);
        }

        [Fact]
        public void QualityCanNeverBeNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(0, app.GetItems()[0].Quality);
        }

        [Fact]
        public void AgedBrieGetsBetterWithAge()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(1, app.GetItems()[0].Quality);
        }

        [Fact]
        public void ItemQualityCannotBeGreaterThanFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void SulfurasValuesDoNotChange()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(80, app.GetItems()[0].Quality);
        }
    }
}
