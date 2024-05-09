using Katas.GildedRoseKata.App;
using Katas.GildedRoseKata.App.Strategy;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests.Strategy;

public class BackstageUpdateQualityShould
{
    private BackstageUpdateQuality _backstageUpdateQuality;

    [SetUp]
    public void Setup()
    {
        _backstageUpdateQuality = new BackstageUpdateQuality();
    }

    [Test]
    [TestCase(-1, -2)]
    [TestCase(0, -1)]
    [TestCase(1, 0)]
    [TestCase(99, 98)]
    public void DecreaseSellInByOneEachDay_WhenUpdate(int sellIn, int expectedSellIn)
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(expectedSellIn));
    }

    [Test]
    public void IncreaseQualityByOne_WhenMoreThan_10_DaysToTheConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(11));
    }

    [Test]
    public void IncreaseQualityByTwo_When_10_DaysOrLessToTheConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(12));
        Assert.That(item.SellIn, Is.EqualTo(9));
    }

    [Test]
    public void IncreaseQualityByThree_When_5_DaysOrLessToTheConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(13));
    }

    [Test]
    public void DropQualityToZero_When_DateForTheConcertHasPassed()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(0));
    }
    
    [Test]
    public void CheckThisScenario_When_Update()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(13), "Quality should increase by 3 when 1 day to the concert");
        Assert.That(item.SellIn, Is.EqualTo(0), "SellIn should decrease by 1 each day");
    }
}