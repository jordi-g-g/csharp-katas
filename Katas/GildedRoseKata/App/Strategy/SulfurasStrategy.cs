namespace Katas.GildedRoseKata.App.Strategy;

public class SulfurasStrategy: IUpdateStrategy
{
    private const int SulfurasDefaultQuality = 80;

    public void UpdateQuality(Item item)
    {
        item.Quality = SulfurasDefaultQuality;
    }
}