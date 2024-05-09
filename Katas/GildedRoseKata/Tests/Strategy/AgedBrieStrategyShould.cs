using Katas.GildedRoseKata.App;
using Katas.GildedRoseKata.App.Strategy;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests.Strategy;

public class AgedBrieStrategyShould
{
    private AgedBrieStrategy _agedBrieStrategy;

    [SetUp]
    public void Setup()
    {
        _agedBrieStrategy = new AgedBrieStrategy();
    }

    [Test]
    public void IncreaseQualityByOne_BeforeSellDate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };

        _agedBrieStrategy.UpdateQuality(item);

        Assert.That(item.Quality, Is.EqualTo(11));
    }

    [Test]
    public void DecreaseSellInByOne_EachDayBeforeSellDate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 };

        _agedBrieStrategy.UpdateQuality(item);

        Assert.That(item.SellIn, Is.EqualTo(4));
    }

    [Test]
    public void IncreaseQualityByTwo_AfterSellDate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 45 };

        _agedBrieStrategy.UpdateQuality(item);

        Assert.That(item.Quality, Is.EqualTo(47));
    }

    [Test]
    public void DecreaseSellInByOne_EachDayAfterSellDate()
    {
        var item = new Item { Name = "Aged Brie", SellIn = -1, Quality = 45 };

        _agedBrieStrategy.UpdateQuality(item);

        Assert.That(item.SellIn, Is.EqualTo(-2));
    }
}