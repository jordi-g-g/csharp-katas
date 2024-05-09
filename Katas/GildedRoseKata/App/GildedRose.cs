using Katas.GildedRoseKata.App.Strategy;

namespace Katas.GildedRoseKata.App;

public class GildedRose(List<Item> items, Dictionary<string, IUpdateStrategy> strategies)
{
    public void UpdateQuality()
    {
        foreach (var item in items)
        {
            if (strategies.TryGetValue(item.Name, out var strategy))
            {
                strategy.UpdateQuality(item);
            }
            else
            {
                strategy = new StandardStrategy();
                strategy.UpdateQuality(item);
            }
        }
    }
}