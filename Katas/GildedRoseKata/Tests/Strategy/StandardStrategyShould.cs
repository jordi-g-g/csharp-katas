using Katas.GildedRoseKata.App;
using Katas.GildedRoseKata.App.Strategy;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests.Strategy;

public class StandardStrategyShould
{
    private StandardStrategy _standardStrategy;
    
    [SetUp]
    public void Setup()
    {
        _standardStrategy = new StandardStrategy();
    }
    
    [Test]
    public void DecreaseSellInByOne_EachDay()
    {
        var item = new Item { Name = "foo", SellIn = 5, Quality = 10 };
        
        _standardStrategy.UpdateQuality(item);

        Assert.That(item.SellIn, Is.EqualTo(4));
    }
    
    [Test]
    public void DecreaseQualityByOne_BeforeSellDate()
    {
        var item = new Item { Name = "foo", SellIn = 5, Quality = 10 };
        
        _standardStrategy.UpdateQuality(item);

        Assert.That(item.Quality, Is.EqualTo(9));
    }    
    
    [Test]
    public void DecreaseQualityByTwo_AfterSellDate()
    {
        var item = new Item { Name = "foo", SellIn = -1, Quality = 10 };
        
        _standardStrategy.UpdateQuality(item);

        Assert.That(item.SellIn, Is.EqualTo(-2));
        Assert.That(item.Quality, Is.EqualTo(8));
    }    
    
    [Test]
    public void EnsureQualityNeverNegative_Always()
    {
        var item = new Item { Name = "foo", SellIn = -1, Quality = 0 };

        _standardStrategy.UpdateQuality(item);

        Assert.That(item.SellIn, Is.EqualTo(-2));
        Assert.That(item.Quality, Is.EqualTo(0));
    }
}