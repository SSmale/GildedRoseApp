using System;
using System.Collections.Generic;
using GildedRoseApp.console;

namespace ConsoleApplication
{
    public class Program
    {
        IList<IItem> Items;
        private int MAX_QUALITY = 50;
        private int MIN_QUALITY = 0;

        public Program(IList<IItem> items)
        {
            Items = items;
        }

        public IList<IItem> GetItems()
        {
            return Items;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program(
                new List<IItem>
                        {
                            new StandardItem {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                            new AgedBrieItem {Name = "Aged Brie", SellIn = 2, Quality = 0},
                            new StandardItem {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                            new SulfurasItem {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                            new BackStagePassItem
                                {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 15,
                                    Quality = 20
                                },
                            new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                        }
                );


            app.UpdateQuality();

            Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (IItem item in Items)
            {

                if (item is SulfurasItem)
                {
                    // return early for items that will never change
                    return;
                }

                // decrement the number of days before doing anything else.
                item.SellIn -= 1;

                if (item.Quality == MAX_QUALITY || (item.Quality == MIN_QUALITY && !(item is AgedBrieItem)))
                {
                    // return early for known limit conditions
                    return;
                }

                // use the method defined on the class to perform the update 
                item.UpdateQuality();
                
                if (item.Quality > MAX_QUALITY)
                {
                    item.Quality = MAX_QUALITY;
                }
                else if (item.Quality < MIN_QUALITY)
                {
                    item.Quality = MIN_QUALITY;
                }
            }
        }
    }
}
