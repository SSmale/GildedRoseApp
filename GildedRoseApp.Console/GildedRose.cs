using System.Collections.Generic;

namespace GildedRoseApp.Console
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        private const int BaseQualityDecrement = 1;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (Item item in _items)
            {
                if (item.Name == Constants.Sulfuras)
                {
                    // skip iteration for items that will never change
                    continue;
                }

                // decrement the number of days before doing anything else.
                item.SellIn -= 1;

                if (item.Quality == MaxQuality || (item.Quality == MinQuality && item.Name != Constants.AgedBrie))
                {
                    // continue for known limit conditions
                    continue;
                }

                switch (item.Name)
                {
                    case Constants.AgedBrie:
                        HandleAgedItem(item);
                        break;
                    case Constants.BackstagePasses:
                        HandleBackstagePasses(item);
                        break;
                    case Constants.ConjuredManaCake:
                        HandleConjuredItem(item);
                        break;
                    default:
                        HandleDefaultItem(item);
                        break;
                }

                if (item.Quality > MaxQuality)
                {
                    item.Quality = MaxQuality;
                }
                else if (item.Quality < MinQuality)
                {
                    item.Quality = MinQuality;
                }
            }
        }

        private static void HandleAgedItem(Item item)
        {
            item.Quality += 1;
        }

        private static void HandleDefaultItem(Item item)
        {
            if (item.SellIn >= 0)
            {
                item.Quality -= BaseQualityDecrement;
            }
            else
            {
                item.Quality -= BaseQualityDecrement * 2;
            }
        }

        private static void HandleConjuredItem(Item item)
        {
            if (item.SellIn >= 0)
            {
                item.Quality -= BaseQualityDecrement * 2;
            }
            else
            {
                item.Quality -= BaseQualityDecrement * 2 * 2;
            }
        }

        private static void HandleBackstagePasses(Item item)
        {
            if (item.SellIn > 10)
            {
                item.Quality += 1;
            }
            else if (item.SellIn > 5)
            {
                item.Quality += 2;
            }
            else if (item.SellIn >= 0)
            {
                item.Quality += 3;
            }
            else
            {
                item.Quality = 0;
            }
        }
    }
}