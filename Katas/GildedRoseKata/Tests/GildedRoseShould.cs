using Katas.GildedRoseKata.App;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests;

public class GildedRoseShould
{
    [Test]
    public void UpdateQuality_StandardItems_Behavior()
    {
        var items = new List<Item>
        {
            new() { Name = "foo", SellIn = 5, Quality = 10 },
            new() { Name = "foo", SellIn = -1, Quality = 10 }
        };

        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(9), "Quality should decrease by 1 each day before sell date");
        Assert.That(items[0].SellIn, Is.EqualTo(4), "SellIn should decrease by 1 each day");

        Assert.That(items[1].Quality, Is.EqualTo(8), "Quality should decrease by 2 each day past sell date");
        Assert.That(items[1].SellIn, Is.EqualTo(-2), "SellIn should decrease by 1 each day");
    }
    
    [Test]
    public void UpdateQuality_AgedBrie_IncreasesQualityAsItAges()
    {
        var items = new List<Item>
        {
            new() { Name = "Aged Brie", SellIn = 5, Quality = 10 },
            new() { Name = "Aged Brie", SellIn = -1, Quality = 45 }
        };

        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(11), "Quality should increase by 1 each day before sell date");
        Assert.That(items[0].SellIn, Is.EqualTo(4), "SellIn should decrease by 1 each day");

        Assert.That(items[1].Quality, Is.EqualTo(47), "Quality should increase by 2 when past sell date");
        Assert.That(items[1].SellIn, Is.EqualTo(-2), "SellIn should decrease by 1 each day");
    }
    
    [TestFixture]
    public class BackstagePassTests
    {
        [Test]
        public void UpdateQuality_BackstagePasses_IncreaseQualityAsEventApproaches()
        {
            var items = new List<Item>
            {
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 },
                new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 },
            };

            var gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.That(items[0].Quality, Is.EqualTo(11), "Quality should increase by 1 when more than 10 days to the concert");
            Assert.That(items[0].SellIn, Is.EqualTo(10), "SellIn should decrease by 1 each day");
            Assert.That(items[1].Quality, Is.EqualTo(12), "Quality should increase by 2 when 10 days or less to the concert");
            Assert.That(items[1].SellIn, Is.EqualTo(9), "SellIn should decrease by 1 each day");
            Assert.That(items[2].Quality, Is.EqualTo(13), "Quality should increase by 3 when 5 days or less to the concert");
            Assert.That(items[2].SellIn, Is.EqualTo(4), "SellIn should decrease by 1 each day");
            Assert.That(items[3].Quality, Is.EqualTo(13), "Quality should increase by 3 when 1 day to the concert");
            Assert.That(items[3].SellIn, Is.EqualTo(0), "SellIn should decrease by 1 each day");
            Assert.That(items[4].Quality, Is.EqualTo(0), "Quality should drop to 0 after the concert");
            Assert.That(items[4].SellIn, Is.EqualTo(-1), "SellIn should decrease by 1 each day");
        }
    }
    
    [Test]
    public void UpdateQuality_Sulfuras_RemainsUnchangedRegardlessOfSellInValue()
    {
        var items = new List<Item>
        {
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 5 },
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 5 }
        };

        var gildedRose = new GildedRose(items);
        gildedRose.UpdateQuality();

        Assert.That(items[0].Quality, Is.EqualTo(5), "Quality should not change for Sulfuras when SellIn is positive");
        Assert.That(items[0].SellIn, Is.EqualTo(5), "SellIn should not change for Sulfuras when SellIn is positive");

        Assert.That(items[1].Quality, Is.EqualTo(5), "Quality should not change for Sulfuras when SellIn is negative");
        Assert.That(items[1].SellIn, Is.EqualTo(-1), "SellIn should not change for Sulfuras when SellIn is negative");
    }
}