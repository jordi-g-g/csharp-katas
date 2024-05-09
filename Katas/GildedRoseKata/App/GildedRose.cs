using Katas.GildedRoseKata.App.Strategy;

namespace Katas.GildedRoseKata.App;

public class GildedRose(List<Item> items)
{
    private readonly Dictionary<string, IUpdateStrategy> _strategies = new()
    {
        { "Aged Brie", new AgedBrieStrategy() },
        { "Backstage passes to a TAFKAL80ETC concert", new BackstageStrategy() },
        { "Sulfuras, Hand of Ragnaros", new SulfurasStrategy() },
        { StandardStrategy, new StandardStrategy() }
    };

    private const string StandardStrategy = "standard";

    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            if (_strategies.TryGetValue(item.Name, out var strategy))
            {
                strategy.UpdateQuality(item);
            }
            else
            {
                _strategies[StandardStrategy].UpdateQuality(item);
            }
        }
    }
}