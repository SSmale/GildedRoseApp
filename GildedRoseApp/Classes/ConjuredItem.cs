using System;
namespace GildedRoseApp.console
{
    public class ConjuredItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateQuality()
        {
            if (SellIn >= 0)
            {
                Quality -= 2;
            }
            else
            {
                Quality -= 4;
            }
        }
    }
}
