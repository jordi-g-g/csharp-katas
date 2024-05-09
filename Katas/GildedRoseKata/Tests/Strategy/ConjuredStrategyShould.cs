using Katas.GildedRoseKata.App;
using Katas.GildedRoseKata.App.Strategy;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests.Strategy;

public class ConjuredStrategyShould
{
    private ConjuredStrategy _conjuredStrategy;
    
    [SetUp]
    public void Setup()
    {
        _conjuredStrategy = new ConjuredStrategy();
    }
    
    [Test]
    public void DecreaseSellInByOne_EachDay()
    {
        var item = new Item { Name = "foo", SellIn = 5, Quality = 10 };
        
        _conjuredStrategy.UpdateQuality(item);

        Assert.That(item.SellIn, Is.EqualTo(4));
    }
    
    [Test]
    public void DecreaseQualityByTwo_BeforeSellDate()
    {
        var item = new Item { Name = "foo", SellIn = 5, Quality = 10 };
        
        _conjuredStrategy.UpdateQuality(item);

        Assert.That(item.Quality, Is.EqualTo(8));
    }    
    
    [Test]
    public void DecreaseQualityByFour_AfterSellDate()
    {
        var item = new Item { Name = "foo", SellIn = -1, Quality = 10 };
        
        _conjuredStrategy.UpdateQuality(item);

        Assert.That(item.SellIn, Is.EqualTo(-2));
        Assert.That(item.Quality, Is.EqualTo(6));
    }    
    
    [Test]
    public void EnsureQualityNeverNegative_Always()
    {
        var item = new Item { Name = "foo", SellIn = -1, Quality = 0 };

        _conjuredStrategy.UpdateQuality(item);

        Assert.That(item.SellIn, Is.EqualTo(-2));
        Assert.That(item.Quality, Is.EqualTo(0));
    }
}