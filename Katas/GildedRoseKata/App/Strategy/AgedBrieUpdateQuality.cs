namespace Katas.GildedRoseKata.App.Strategy;

public class AgedBrieUpdateQuality : IUpdateQualityStrategy
{
    public void Update(Item item)
    {
        if (item.SellIn < 0)
        {
            item.Quality += 1;
        }

        item.Quality += 1;
        item.SellIn -= 1;
    }
}