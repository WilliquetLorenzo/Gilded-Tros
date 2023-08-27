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
                && item.Name != BACKSTAGE_PASS_HAXX)
            {
                if (item.Quality > 0)
                {
                    if (item.Name != B_DAWG_KEYCHAIN)
                    {
                        if (item.Name == DUPLICATE_CODE || item.Name == LONG_METHODS || item.Name == UGLY_VARIABLE_NAMES)
                            AdjustItemQuality(item, -2);

                        else
                            AdjustItemQuality(item, -1);
                    }
                   
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    AdjustItemQuality(item, 1);

                    if (item.Name == BACKSTAGE_PASS_RE_FACTOR
                    || item.Name == BACKSTAGE_PASS_HAXX)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                AdjustItemQuality(item, 1);
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                AdjustItemQuality(item, 1);
                            }
                        }
                    }
                }
            }

            if (item.Name != B_DAWG_KEYCHAIN)
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                if (item.Name != GOOD_WINE)
                {
                    if (item.Name != BACKSTAGE_PASS_RE_FACTOR
                        && item.Name != BACKSTAGE_PASS_HAXX)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != B_DAWG_KEYCHAIN)
                            {
                                if (item.Name == DUPLICATE_CODE || item.Name == LONG_METHODS || item.Name == UGLY_VARIABLE_NAMES)
                                    AdjustItemQuality(item, -2);

                                else
                                    AdjustItemQuality(item, -1);
                            }
                        }
                    }
                    else
                    {
                        AdjustItemQuality(item, -1);
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        AdjustItemQuality(item, 1);
                    }
                }
            }
        }

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

        private bool IsItemQualityBiggerThenFifthy(int item)
        {
            if(item > 50)
                return true;

            return false;
        }

        private bool IsItemQualitySmallerThenZero(int item)
        {
            if (item < 0)
                return true;

            return false;
        }
    }
}
