namespace Katas.GildedRoseKata.App.Strategy;

public class SulfurasUpdateQuality: IUpdateQualityStrategy
{
    private const int SulfurasDefaultQuality = 80;

    public void Update(Item item)
    {
        item.Quality = SulfurasDefaultQuality;
    }
}