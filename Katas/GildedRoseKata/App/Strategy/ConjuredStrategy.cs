namespace Katas.GildedRoseKata.App.Strategy;

public class ConjuredStrategy : IUpdateStrategy
{
    public void UpdateQuality(Item item)
    {
        item.SellIn -= 1;
        item.Quality -= 2;
        if (item.SellIn < 0)
        {
            item.Quality -= 2;
        }

        if (item.Quality < 0)
        {
            item.Quality = 0;
        }
    }
}