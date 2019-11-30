using System;
namespace GildedRoseApp.console
{
    public class AgedBrieItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateQuality()
        {
            Quality += 1;
        }
    }
}
