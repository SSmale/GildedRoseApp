using System;
namespace GildedRoseApp.console
{
    public class BackStagePassItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public void UpdateQuality()
        {
            if (SellIn > 10)
            {
                Quality += 1;
            }
            else if (SellIn > 5)
            {
                Quality += 2;
            }
            else if (SellIn >= 0)
            {
                Quality += 3;
            }
            else
            {
                Quality = 0;
            }
        }
    }
}
