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
        public void Test1()
        {
            Assert.True(true);
        }
        [Fact]
        public void Test2()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new Program(Items);
            Assert.Equal("foo", app.GetItems()[0].Name);
        }
    }
}
