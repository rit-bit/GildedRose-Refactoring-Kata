using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var gildedRose = new GildedRose(GetItems());

            for (var day = 0; day < 31; day++)
            {
                gildedRose.ListInventory();
                gildedRose.AnotherDayPasses();
            }
        }

        private static IList<Item> GetItems()
        {
            return new List<Item>
            {/*
                new()
                {
                    Name = ItemName.DexterityVest,
                    SellIn = 10,
                    Quality = 20
                },
                new()
                {
                    Name = ItemName.AgedBrie,
                    SellIn = 2,
                    Quality = 0
                },
                new()
                {
                    Name = ItemName.ElixirOfMongoose,
                    SellIn = 5,
                    Quality = 7
                },
                new()
                {
                    Name = ItemName.Sulfuras,
                    SellIn = -1,
                    Quality = 80
                },
                new()
                {
                    Name = ItemName.Sulfuras,
                    SellIn = -1,
                    Quality = 80
                },*/
                new()
                {
                    Name = ItemName.BackstagePasses,
                    SellIn = 15,
                    Quality = 20
                },/*
                new()
                {
                    Name = ItemName.BackstagePasses,
                    SellIn = 10,
                    Quality = 49
                },
                new()
                {
                    Name = ItemName.BackstagePasses,
                    SellIn = 5,
                    Quality = 49
                },
                // TODO this conjured item does not work properly yet
                new()
                {
                    Name = ItemName.ConjuredManaCake,
                    SellIn = 3,
                    Quality = 6
                }*/
            };
        }
    }
}