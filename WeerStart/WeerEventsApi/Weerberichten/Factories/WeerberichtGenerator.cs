using WeerEventsApi.Facade.Dto;

namespace WeerEventsApi.Weerberichten.Factories;

public class WeerberichtGenerator : IWeerberichtGenerator
{
    public WeerberichtDto GenereerWeerbericht(IEnumerable<MetingDto> metingen)
    {
        Thread.Sleep(5000);// Simuleer zware operatie

        int aantalMetingen = metingen.Count();
        string weerType = "goed";

        var metingenPerEenheid = metingen.GroupBy(m => m.Eenheid);
        foreach (var meting in metingenPerEenheid) {
            double gemiddelde = meting.Average(m => m.Waarde);
            switch (meting.Key) {
                case "°C":
                    if (gemiddelde < 15) weerType = "slecht";
                    break;
                case "mm/h":
                    if (gemiddelde > 20) weerType = "slecht";
                    break;
                case "km/h":
                    if (gemiddelde > 60) weerType = "slecht";
                    break;
                case "hPa":
                    if (gemiddelde < 980 || gemiddelde > 1040) weerType = "slecht";
                    break;
            }
            if (weerType == "slecht") 
                break;
        }

        string bericht = $"Op basis van {aantalMetingen} metingen en mijn diepzinnig computermodel kan ik zeggen dat er kans is op {weerType} weer.";

        return new WeerberichtDto {
            Moment = DateTime.Now,
            Bericht = bericht
        };
    }
}