using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GildedRoseKata;
using Xunit;

namespace GildedRoseKataTests
{
    public class GildedRoseTests
    {
        [Fact]
        public void UpdateQuality_GivenANonExpiredBasicItem_DecreasesInSellin()
        {
            // Arrange
            var item = new Item
            {
                Name = "Basic Item",
                Quality = 40,
                SellIn = 40
            };
            var items = new List<Item> { item };
            var gildedRose = new GildedRose(items);

            // Act
            gildedRose.UpdateQuality();

            // Assert
            item.SellIn.Should().Be(39);
        }

        [Fact]
        public void UpdateQuality_GivenANonExpiredBasicItem_DecreaseQuality()
        {
            //Given
            var item = new Item
            {
                Name = "Basic Item",
                Quality = 40,
                SellIn = 40
            };
            var items = new List<Item> { item };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            item.Quality.Should().Be(39);
        }

        [Fact]
        public void UpdateQuality_GivenMultipleNonExpiredItems_DecreaseInSellInForAll()
        {
            //Given
            var basicItem1 = new Item
            {
                Name = "Basic Item 1",
                Quality = 40,
                SellIn = 40
            };

            var basicItem2 = new Item
            {
                Name = "Basic Item 2",
                Quality = 25,
                SellIn = 13
            };
            var items = new List<Item> { basicItem1, basicItem2 };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            basicItem1.SellIn.Should().Be(39);
            basicItem2.SellIn.Should().Be(12);
        }

        [Fact]
        public void UpdateQuality_GivenMultipleNonExpiredItems_DecreaseInQualityInForAll()
        {
            //Given
            var basicItem1 = new Item
            {
                Name = "Basic Item 1",
                Quality = 40,
                SellIn = 40
            };

            var basicItem2 = new Item
            {
                Name = "Basic Item 2",
                Quality = 25,
                SellIn = 13
            };
            var items = new List<Item> { basicItem1, basicItem2 };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            basicItem1.Quality.Should().Be(39);
            basicItem2.Quality.Should().Be(24);
        }

        [Fact]
        public void UpdateQuality_GivenExpiredBasicItem_QualityDegradesTwiceAsFast()
        {
            //Given
            var item = new Item
            {
                Name = "Basic Item",
                Quality = 40,
                SellIn = 0
            };
            var items = new List<Item> { item };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            item.Quality.Should().Be(38);
        }

        [Fact]
        public void UpdateQuality_GiveABasicItem_QualityIsNeverNegagtive()
        {
            //Given
            var item = new Item
            {
                Name = "Basic Item",
                Quality = 0,
                SellIn = 10
            };
            var items = new List<Item> { item };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            item.Quality.Should().Be(0);
        }

        [Fact]
        public void UpdateQuality_GivenNonExpiredAgedBrie_QualityIncreasesBy1()
        {
            //Given
            var agedBrie = new Item
            {
                Name = "Aged Brie",
                Quality = 40,
                SellIn = 5
            };
            var items = new List<Item> { agedBrie };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            agedBrie.Quality.Should().Be(41);
        }

        [Fact]
        public void UpdateQuality_GiveAgedBrie_SellInDecreasesByOne()
        {
            //Given
            var agedBrie = new Item
            {
                Name = "Aged Brie",
                Quality = 40,
                SellIn = 5
            };
            var items = new List<Item> { agedBrie };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            agedBrie.SellIn.Should().Be(4);
        }

        [Fact]
        public void UpdateQuality_GivenExpiredAgedBrie_QualityIncreasesBy2()
        {
            //Given
            var agedBrie = new Item
            {
                Name = "Aged Brie",
                Quality = 40,
                SellIn = 0
            };
            var items = new List<Item> { agedBrie };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            agedBrie.Quality.Should().Be(42);
        }

        [Fact]
        public void UpdateQuality_GivenAnItemThatIncreaseInQualityWithAge_QualityCanNotBeOver50()
        {
            //Given
            var agedBrie = new Item
            {
                Name = "Aged Brie",
                Quality = 50,
                SellIn = 5
            };
            var items = new List<Item> { agedBrie };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            agedBrie.Quality.Should().Be(50);
        }

        [Fact]
        public void UpdateQuality_GivenALegendaryItem_SellInDoesNotChange()
        {
            //Given
            var sulfuras = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = 5
            };
            var items = new List<Item> { sulfuras };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            sulfuras.SellIn.Should().Be(5);
        }

        [Fact]
        public void UpdateQuality_GivenALegendaryItem_QualityDoesNotChange()
        {
            //Given
            var sulfuras = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 80,
                SellIn = 5
            };
            var items = new List<Item> { sulfuras };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            sulfuras.Quality.Should().Be(80);
        }

        [Fact]
        public void UpdateQuality_GivenABackstagePassWithSellInGreateThan10Days_QualityIncreasesBy1()
        {
            //Given
            var backstagePasses = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 40,
                SellIn = 11
            };
            var items = new List<Item> { backstagePasses };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            backstagePasses.Quality.Should().Be(41);
        }

        [Fact]
        public void UpdateQuality_GivenANonExpiredBackstagePass_SellInShouldDeceaseByOne()
        {
            //Given
            var backstagePasses = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 40,
                SellIn = 11
            };
            var items = new List<Item> { backstagePasses };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            backstagePasses.SellIn.Should().Be(10);
        }

        [Fact]
        public void UpdateQuality_GivenBackstagePassWithSellInLessWithTenOrLessAndMoreThanFiveDays_QualityIncreasesBy2()
        {
            //Given
            var backstagePasses = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 40,
                SellIn = 7
            };

            var items = new List<Item> { backstagePasses };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            backstagePasses.Quality.Should().Be(42);
        }

        [Fact]
        public void UpdateQuality_GivenNonExpiredBackstagePassWithSellInLessWithFiveDays_QualityIncreasesBy3()
        {
            //Given
            var backstagePasses = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 40,
                SellIn = 3
            };

            var items = new List<Item> { backstagePasses };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            backstagePasses.Quality.Should().Be(43);
        }

        [Fact]
        public void UpdateQuality_GivenAnExpiredBackstagePass_HasQualityOfZero()
        {
            //Given
            var backstagePasses = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 40,
                SellIn = 0
            };

            var items = new List<Item> { backstagePasses };
            var gildedRose = new GildedRose(items);

            //When
            gildedRose.UpdateQuality();

            //Then
            backstagePasses.Quality.Should().Be(0);
        }
    }
}
