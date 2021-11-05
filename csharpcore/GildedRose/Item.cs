namespace GildedRoseKata
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    }

    public static class ItemName
    {
        public const string DexterityVest = "+5 Dexterity Vest";
        public const string AgedBrie = "Aged Brie";
        public const string ElixirOfMongoose = "Elixir of the Mongoose";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        public const string ConjuredManaCake = "Conjured Mana Cake";

        public static bool IsConjured(Item item)
        {
            return item.Name.ToLower().Contains("conjured");
        }
    }
}
