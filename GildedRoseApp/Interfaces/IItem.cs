using System;
namespace GildedRoseApp.console
{
    public interface IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateQuality();
    }
}
