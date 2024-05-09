using Katas.GildedRoseKata.App;
using Katas.GildedRoseKata.App.Strategy;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests.Strategy;

public class SulfurasUpdateQualityShould
{
    private SulfurasUpdateQuality _sulfurasUpdateQuality;
    
    [SetUp]
    public void Setup()
    {
        _sulfurasUpdateQuality = new SulfurasUpdateQuality();
    }
    
    [Test]
    [TestCase(-1)]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(99)]
    public void MaintainQualityAtEighty_LegendaryItem(int sellIn)
    {
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = sellIn, Quality = 5 };
        
        _sulfurasUpdateQuality.Update(item);

        Assert.That(item.Quality, Is.EqualTo(80));
    }    

    [Test]
    public void NotChangeSellIn_WhenSellInIsPositive()
    {
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 5 };
        
        _sulfurasUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(5));
    }    
    
    [Test]
    public void NotChangeSellIn_WhenSellInIsNegative()
    {
        var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -5, Quality = 5 };
        
        _sulfurasUpdateQuality.Update(item);

        Assert.That(item.SellIn, Is.EqualTo(-5));
    }
}