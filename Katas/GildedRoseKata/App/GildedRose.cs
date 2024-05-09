using Katas.GildedRoseKata.App.Strategy;

namespace Katas.GildedRoseKata.App;

public class GildedRose(List<Item> items)
{
    private readonly Dictionary<string, IUpdateQualityStrategy> _strategies = new()
    {
        { "Aged Brie", new AgedBrieUpdateQuality() },
        { "Backstage passes to a TAFKAL80ETC concert", new BackstageUpdateQuality() },
        { "Sulfuras, Hand of Ragnaros", new SulfurasUpdateQuality() },
        { StandardStrategy, new StandardItemUpdateQuality() }
    };

    private const string StandardStrategy = "standard";

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            if (_strategies.TryGetValue(item.Name, out var strategy))
            {
                strategy.Update(item);
            }
            else
            {
                _strategies[StandardStrategy].Update(item);
            }
        }
    }
}