using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen;
using System.Collections.Concurrent;
using WeerEventsApi.Metingen.Factories;
using WeerEventsApi.Logging.Observer;

namespace WeerEventsApi.Weerberichten.Factories;

public class WeerberichtGenerator : IWeerberichtGenerator, IObserver
{
    private readonly List<MetingDto> _metingen = new();

    public void Update(Meting meting)
    {
        _metingen.Add(MetingMapper.ConvertMetingToMetingDto(meting));
    }

    public WeerberichtDto GenereerWeerbericht()
    {
        Thread.Sleep(5000); // Simuleer zware operatie

        var metingen = _metingen.ToList();
        int aantalMetingen = metingen.Count;
        string weerType = "goed";

        var metingenPerEenheid = metingen.GroupBy(m => m.Eenheid);
        foreach (var meting in metingenPerEenheid)
        {
            double gemiddelde = meting.Average(m => m.Waarde);
            switch (meting.Key)
            {
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

        return new WeerberichtDto
        {
            Moment = DateTime.Now,
            Bericht = bericht
        };
    }
}