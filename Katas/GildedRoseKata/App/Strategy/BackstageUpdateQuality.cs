namespace Katas.GildedRoseKata.App.Strategy;

public class BackstageUpdateQuality : IUpdateQualityStrategy
{
    public void Update(Item item)
    {
        if (item.SellIn <= 10)
        {
            item.Quality += 1;
        }

        if (item.SellIn <= 5)
        {
            item.Quality += 1;
        }

        item.Quality += 1;

        if (item.SellIn <= 0)
        {
            item.Quality = 0;
        }

        item.SellIn -= 1;
    }
}