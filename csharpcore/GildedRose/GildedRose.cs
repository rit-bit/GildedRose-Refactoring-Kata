using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private int _day = 0;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void ListInventory()
        {
            Console.WriteLine($"-------- day {_day} --------");
            Console.WriteLine("name, sellIn, quality");
            foreach (var item in Items)
            {
                Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }

            Console.WriteLine("");
        }

        public void AnotherDayPasses()
        {
            foreach (var item in Items)
            {
                AdjustQuality(item);
                AdjustSellIn(item);
            }

            _day++;
        }

        private static void AdjustQuality(Item item)
        {
            var multiplier = 1;
            if (ItemName.IsConjured(item))
                multiplier *= 2;
            if (item.SellIn < 0)
                multiplier *= 2;
            
            switch (item.Name)
            {
                case ItemName.Sulfuras:
                    return;
                case ItemName.AgedBrie:
                    if (item.Quality < 50)
                        item.Quality += multiplier;
                    return;
                case ItemName.BackstagePasses:
                    AdjustQualityOfBackstagePass(item, multiplier);
                    return;
                default:
                    if (item.Quality > 0)
                        item.Quality -= multiplier;
                    return;
            }
        }

        private static void AdjustQualityOfBackstagePass(Item item, int multiplier)
        {
            if (item.SellIn <= 10)
            {
                item.Quality += (2 * multiplier);
                return;
            }

            if (item.SellIn <= 5)
            {
                item.Quality += (3 * multiplier);
                return;
            }

            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
        }

        private static void AdjustSellIn(Item item)
        {
            if (item.Name != ItemName.Sulfuras)
                item.SellIn--;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name != ItemName.AgedBrie && item.Name != ItemName.BackstagePasses)
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != ItemName.Sulfuras)
                        {
                            item.Quality--;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality++;

                        if (item.Name == ItemName.BackstagePasses)
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality++;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality++;
                                }
                            }
                        }
                    }
                }

                if (item.Name != ItemName.Sulfuras)
                {
                    item.SellIn--;
                }

                if (item.SellIn < 0)
                {
                    if (item.Name == ItemName.AgedBrie)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality++;
                        }
                    }
                    else
                    {
                        if (item.Name == ItemName.BackstagePasses)
                        {
                            item.Quality -= item.Quality;
                        }
                        else
                        {
                            if (item.Quality > 0)
                            {
                                if (item.Name != ItemName.Sulfuras)
                                {
                                    item.Quality--;
                                }
                            }
                        }
                    }
                }
            }

            _day++;
        }
    }
}