using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        private const string GOOD_WINE = "Good Wine";
        private const string B_DAWG_KEYCHAIN = "B-DAWG Keychain";
        private const string BACKSTAGE_PASS_RE_FACTOR = "Backstage passes for Re:factor";
        private const string BACKSTAGE_PASS_HAXX = "Backstage passes for HAXX";

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
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == BACKSTAGE_PASS_RE_FACTOR
                    || item.Name == BACKSTAGE_PASS_HAXX)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
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
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }
    }
}
