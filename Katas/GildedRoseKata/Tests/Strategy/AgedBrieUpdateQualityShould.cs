using Katas.GildedRoseKata.App;
using Katas.GildedRoseKata.App.Strategy;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests.Strategy;

public class AgedBrieUpdateQualityShould
{
    private AgedBrieUpdateQuality _agedBrieUpdateQuality;

    [SetUp]
    public void Setup()
    {
        _agedBrieUpdateQuality = new AgedBrieUpdateQuality();
    }

    [Test]
    public void IncreaseQualityByOneEachDayBeforeSellDate_WhenUpdate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };

        _agedBrieUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(11));
    }

    [Test]
    public void DecreaseSellInByOneEachDayBeforeSellDate_WhenUpdate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };

        _agedBrieUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(4));
    }

    [Test]
    public void IncreaseQualityByTwoEachDayAfterSellDate_WhenUpdate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 45 };

        _agedBrieUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(47));
    }

    [Test]
    public void DecreaseSellInByOneEachDayAfterSellDate_WhenUpdate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 45 };

        _agedBrieUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(-2));
    }
}