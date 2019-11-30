using System;
using System.Collections.Generic;
using GildedRoseApp.console;

namespace ConsoleApplication
{
    public class Program
    {
        IList<Item> Items;
        private int MAX_QUALITY = 50;
        private int MIN_QUALITY = 0;
        private int BASE_QUALITY_DECREMENT = 1;

        public Program(IList<Item> items)
        {
            Items = items;
        }

        public IList<Item> GetItems()
        {
            return Items;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program(
                new List<Item>
                        {
                            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                            new Item
                                {
                                    Name = "Backstage passes to a TAFKAL80ETC concert",
                                    SellIn = 15,
                                    Quality = 20
                                },
                            new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                        }
                );


            app.UpdateQuality();

            Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (Item item in Items)
            {

                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    // return early for items that will never change
                    return;
                }

                // decrement the number of days before doing anything else.
                item.SellIn -= 1;

                if (item.Quality == MAX_QUALITY || (item.Quality == MIN_QUALITY && item.Name != "Aged Brie"))
                {
                    // return early for known limit conditions
                    return;
                }

                switch (item.Name)
                {
                    case "Aged Brie":
                        item.Quality += 1;
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        if (item.SellIn > 10)
                        {
                            item.Quality += 1;
                        } else if (item.SellIn > 5)
                        {
                            item.Quality += 2;
                        } else if (item.SellIn >= 0)
                        {
                            item.Quality += 3;
                        } else
                        {
                            item.Quality = 0;
                        }
                        break;
                    case "Conjured Mana Cake":
                        if (item.SellIn >= 0)
                        {
                            item.Quality -= BASE_QUALITY_DECREMENT * 2;
                        } else
                        {
                            item.Quality -= BASE_QUALITY_DECREMENT * 2 * 2;
                        }
                        break;
                    default:
                        if (item.SellIn >= 0)
                        {
                            item.Quality -= BASE_QUALITY_DECREMENT;
                        }
                        else
                        {
                            item.Quality -= BASE_QUALITY_DECREMENT * 2;
                        }
                        break;
                }

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
