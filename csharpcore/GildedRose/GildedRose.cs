using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private int _day;

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
                    break;
                case ItemName.AgedBrie:
                    if (item.Quality < 50)
                        ExecuteChangeOfQuality(item, 1, multiplier);
                    break;
                case ItemName.BackstagePasses:
                    AdjustQualityOfBackstagePass(item, multiplier);
                    break;
                default:
                    ExecuteChangeOfQuality(item, -1, multiplier);
                    break;
            }
        }

        private static void AdjustQualityOfBackstagePass(Item item, int multiplier)
        {
            switch (item.SellIn)
            {
                case <= 0:
                    item.Quality = 0;
                    break;
                case <= 5:
                    ExecuteChangeOfQuality(item, 3, multiplier);
                    break;
                case <= 10:
                    ExecuteChangeOfQuality(item, 2, multiplier);
                    break;
                default:
                    ExecuteChangeOfQuality(item, 1, multiplier);
                    // TODO - RESOLVE AMBIGUITY - Confirm whether backstage passes should increase in value when sellIn > 10
                    break;
            }
        }

        private static void ExecuteChangeOfQuality(Item item, int change, int multiplier)
        {
            var difference = change * multiplier;
            if (item.Name == ItemName.Sulfuras)
                return;
            item.Quality += difference;
            if (item.Quality > 50)
                item.Quality = 50;
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