using System.Collections.Generic;

namespace GildedRoseApp.Console
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            List<Item> items = new List<Item>
            {
                new Item {Name = Constants.DexterityVest, SellIn = 10, Quality = 20},
                new Item {Name = Constants.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = Constants.ElixirOfTheMongoose, SellIn = 5, Quality = 7},
                new Item {Name = Constants.Sulfuras, SellIn = 0, Quality = 80},
                new Item
                {
                    Name = Constants.BackstagePasses,
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = Constants.ConjuredManaCake, SellIn = 3, Quality = 6}
            };
            
            GildedRose app = new GildedRose(items);

            for (var i = 0; i < 31; i++)
            {
                System.Console.WriteLine($"-------- day {i} --------");
                System.Console.WriteLine("name, sellIn, quality");
                
                foreach (Item item in items)
                {
                    System.Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
                }
                
                System.Console.WriteLine();
                
                app.UpdateQuality();
            }

            System.Console.ReadKey();
        }
    }
}
