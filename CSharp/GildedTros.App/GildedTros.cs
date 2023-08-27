using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        private const string GOOD_WINE = "Good Wine";
        private const string B_DAWG_KEYCHAIN = "B-DAWG Keychain";
        private const string BACKSTAGE_PASS_RE_FACTOR = "Backstage passes for Re:factor";
        private const string BACKSTAGE_PASS_HAXX = "Backstage passes for HAXX";
        private const string DUPLICATE_CODE = "Duplicate Code";
        private const string LONG_METHODS = "Long Methods";
        private const string UGLY_VARIABLE_NAMES = "Ugly Variable Names";

        IList<Item> Items;
        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            // Simpele iteratie door een lijst
            foreach (Item item in Items)
                UpdateItemQuality(item);
        }

        private void UpdateItemQuality(Item item)
        {
            if (item.Name != GOOD_WINE
                && item.Name != BACKSTAGE_PASS_RE_FACTOR
                && item.Name != BACKSTAGE_PASS_HAXX
                && item.Name != B_DAWG_KEYCHAIN)
            {
                int decrement = GetDecrementItemQuality(item);
                AdjustItemQuality(item, decrement);
            }

            else if (item.Name == GOOD_WINE)
            {
                int decrement = isItemSellInExpired(item.SellIn) ? 2 : 1;
                AdjustItemQuality(item, decrement);
            }

            else if (item.Name == BACKSTAGE_PASS_RE_FACTOR || item.Name == BACKSTAGE_PASS_HAXX)
            {
                AdjustItemQuality(item, 1);

                if (item.SellIn < 11)
                    AdjustItemQuality(item, 1);

                if (item.SellIn < 6)
                    AdjustItemQuality(item, 1);

                if (isItemSellInExpired(item.SellIn))
                    item.Quality = 0;
            }

            if (!item.Name.Equals(B_DAWG_KEYCHAIN))
                item.SellIn --;
        }

        // Methode: haalt de Quality van een Item naar omhoog of naar omlaag
        private void AdjustItemQuality(Item item, int adjustment)
        {
            int newItemQuality = item.Quality + adjustment;

            if (IsItemQualityBiggerThenFifthy(newItemQuality) == false && IsItemQualitySmallerThenZero(newItemQuality) == false)
                item.Quality = newItemQuality;

            else if (IsItemQualityBiggerThenFifthy(newItemQuality))
                item.Quality = 50;

            else if (IsItemQualitySmallerThenZero(newItemQuality))
                item.Quality = 0;
        }

        // Methode: Controleert of de waarde groter is dan 50 indien dit het geval is retourneren we True anders False
        private bool IsItemQualityBiggerThenFifthy(int item)
        {
            if (item > 50)
                return true;

            return false;
        }

        // Methode: Controleert of de waarde kleiner is dan 0 indien dit het geval is retourneren we True anders False
        private bool IsItemQualitySmallerThenZero(int item)
        {
            if (item < 0)
                return true;

            return false;
        }

        // Methode: Controleert of de SellIn van het Item expired is
        private bool isItemSellInExpired(int itemSellIn)
        {
            if (itemSellIn < 1)
                return true;
            
            return false;
        }

        // Methode: retourneert een waarde die men aftrekt van de Quality van een Item
        private int GetDecrementItemQuality(Item item)
        {
            int decrement = -1;
            if (isItemSellInExpired(item.SellIn))
                decrement *= 2;

            if (item.Name == DUPLICATE_CODE || item.Name == LONG_METHODS || item.Name == UGLY_VARIABLE_NAMES)
                decrement *= 2;

            return decrement;
        }
    }
}
