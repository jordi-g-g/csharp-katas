using Katas.GildedRoseKata.App;
using Katas.GildedRoseKata.App.Strategy;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests.Strategy;

public class StandardItemUpdateQualityShould
{
    private StandardItemUpdateQuality _standardItemUpdateQuality;
    
    [SetUp]
    public void Setup()
    {
        _standardItemUpdateQuality = new StandardItemUpdateQuality();
    }
    
    [Test]
    public void DecreaseSellInByOneEachDay_WhenUpdated()
    {
        var item = new Item { Name = "foo", SellIn = 5, Quality = 10 };
        
        _standardItemUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(4));
    }
    
    [Test]
    public void DecreaseQualityByOneEachDayBeforeSellDate_WhenUpdated()
    {
        var item = new Item { Name = "foo", SellIn = 5, Quality = 10 };
        
        _standardItemUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(9));
    }    
    
    [Test]
    public void DecreaseQualityByTwoEachDayPastSellDate_WhenUpdated()
    {
        var item = new Item { Name = "foo", SellIn = -1, Quality = 10 };
        
        _standardItemUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(-2));
        Assert.That(item.Quality, Is.EqualTo(8));
    }    
    
    [Test]
    public void EnsureQualityOfAnItemIsNeverNegative_WhenUpdated()
    {
        var item = new Item { Name = "foo", SellIn = -1, Quality = 0 };

        _standardItemUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(-2));
        Assert.That(item.Quality, Is.EqualTo(0));
    }
}