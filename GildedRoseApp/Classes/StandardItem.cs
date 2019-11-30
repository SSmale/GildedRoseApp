using System;
namespace GildedRoseApp.console
{
    public class StandardItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateQuality()
        {
            if (SellIn >= 0)
            {
                Quality -= 1;
            }
            else
            {
                Quality -= 2;
            }
        }
    }
}
