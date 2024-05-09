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
    public void DecreaseSellInByOne_EachDay(int sellIn, int expectedSellIn)
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(expectedSellIn));
    }

    [Test]
    public void IncreaseQualityByOne_MoreThan10DaysToConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(11));
    }

    [Test]
    public void IncreaseQualityByTwo_10DaysOrLessToConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(12));
        Assert.That(item.SellIn, Is.EqualTo(9));
    }

    [Test]
    public void IncreaseQualityByThree_5DaysOrLessToConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(13));
    }

    [Test]
    public void IncreaseQualityByThree_1DayOrLessToConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(13));
        Assert.That(item.SellIn, Is.EqualTo(0));
    }

    [Test]
    public void DropQualityToZero_AfterConcert()
    {
        var item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 };

        _backstageUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(0));
    }
}