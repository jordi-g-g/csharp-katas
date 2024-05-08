using Katas.GildedRoseKata.App;
using NUnit.Framework;

namespace Katas.GildedRoseKata.Tests;

public class GildedRoseShould
{
    [Test]
    public void BeTrue()
    {
        var items = new List<Item>
        {
            new() { Name = "foo", SellIn = 5, Quality = 10 }
        };
        
        new GildedRose(items);
        Assert.That(true, Is.True);
    }
}