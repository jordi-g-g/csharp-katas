namespace Katas.GildedRoseKata.App.Strategy;

public class AgedBrieStrategy : IUpdateStrategy
{
    public void UpdateQuality(Item item)
    {
        if (item.SellIn < 0)
        {
            item.Quality += 1;
        }

        item.Quality += 1;
        item.SellIn -= 1;
    }
}