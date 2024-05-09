using Katas.GildedRoseKata.App;
using Moq;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests;

public class GildedRoseShould
{
    [Test]
    public void ApplyCorrectStrategyForEachItemType()
    {
        var agedBrieStrategyMock = new Mock<IUpdateStrategy>();
        var backstageStrategyMock = new Mock<IUpdateStrategy>();
        var sulfurasStrategyMock = new Mock<IUpdateStrategy>();
        var conjuredStrategyMock = new Mock<IUpdateStrategy>();
    
        var strategies = new Dictionary<string, IUpdateStrategy>
        {
            { "Aged Brie", agedBrieStrategyMock.Object },
            { "Backstage passes to a TAFKAL80ETC concert", backstageStrategyMock.Object },
            { "Sulfuras, Hand of Ragnaros", sulfurasStrategyMock.Object },
            { "Conjured", conjuredStrategyMock.Object }
        };

        var items = new List<Item>
        {
            new() { Name = "Aged Brie", SellIn = 5, Quality = 10 },
            new() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 10 },
            new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 10 },
            new() { Name = "Conjured", SellIn = -1, Quality = 10 }
        };

        var gildedRose = new GildedRose(items, strategies);

        gildedRose.UpdateQuality();

        agedBrieStrategyMock.Verify(m => m.UpdateQuality(It.Is<Item>(i => i.Name == "Aged Brie")), Times.Once());
        backstageStrategyMock.Verify(m => m.UpdateQuality(It.Is<Item>(i => i.Name == "Backstage passes to a TAFKAL80ETC concert")), Times.Once());
        sulfurasStrategyMock.Verify(m => m.UpdateQuality(It.Is<Item>(i => i.Name == "Sulfuras, Hand of Ragnaros")), Times.Once());
        conjuredStrategyMock.Verify(m => m.UpdateQuality(It.Is<Item>(i => i.Name == "Conjured")), Times.Once());
    }
}