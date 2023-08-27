using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTest
    {
        // Theory = Representeert een reeks van testen met dezelfde code maar met verschillende input parameters
        [Theory]
        // InlineData = Specifieke waarden voor deze inputs
        [InlineData("test", 10, 10, 9, 9)]
        // Test: De Quality van een item is nooit negatief
        [InlineData("test", 0, 0, -1, 0)]
        // Test: Wanneer de SellIn datum voorbij is verdubbelt de afname van de Quality
        [InlineData("test", -1, 10, -2, 8)]
        // Test: Quality gaat naar omhoog
        [InlineData("Good Wine", 2, 2, 1, 3)]
        // Test: Quality kan niet hoger dan 50 zijn. Eens de Quality 60 is dan wordt deze gewijzigd naar 50
        [InlineData("Good Wine", 2, 60, 1, 50)]
        // Test: Wanneer de SellIn datum voorbij de datum blijft, dan stijgt de Quality continu
        [InlineData("Good Wine", -5, 15, -6, 17)]
        // Test: de waarde veranderen nooit
        [InlineData("B-DAWG Keychain", 10, 80, 10, 80)]
        [InlineData("B-DAWG Keychain", 4, 40, 4, 40)]
        [InlineData("B-DAWG Keychain", 6, 12, 6, 12)]
        // Test: Als de SellIn meer dan 10 dagen heeft dan stijgt de Quality met 1
        [InlineData("Backstage passes for HAXX", 15, 10, 14, 11)]
        // Test: Als de SellIn 10 dage of minder heeft dan stijgt de Quality met 2
        [InlineData("Backstage passes for HAXX", 10, 10, 9, 12)]
        // Test: Als de SellIn 5 dagen heeft of minder dan stijgt de Quality met 3
        [InlineData("Backstage passes for HAXX", 5, 10, 4, 13)]
        // Test: De Quality daalt na de conferentie naar 0
        [InlineData("Backstage passes for HAXX", 0, 10, -1, 0)]
        // Test: Quality daalt dubbel zo snel
        [InlineData("Duplicate Code", 7, 5, 6, 3)]
        [InlineData("Duplicate Code", 0, 10, -1, 6)]
        public void UpdateQuality(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // Arrange = setup van de test
            List<Item> Items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedTros app = new GildedTros(Items);

            // Act = uitvoeren van de test
            app.UpdateQuality();
            
            // Assert = checken en verifïeren van resultaten
            Assert.Equal(name, Items[0].Name);
            Assert.Equal(expectedSellIn, Items[0].SellIn);
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
    }
}