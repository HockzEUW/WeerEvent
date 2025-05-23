using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen.Factories;
using WeerEventsApi.Stations.Factories;
using WeerEventsApi.Stations.Managers;
using WeerEventsApi.Steden.Factories;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Weerberichten.Factories;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController(
    IStadManager stadManager,
    IWeerstationManager weerstationManager,
    IWeerberichtGenerator weerberichtGenerator
    ) : IDomeinController
{
    public IEnumerable<StadDto> GeefSteden()
    {
        return stadManager.GeefSteden().Select(s => StadMapper.ConvertStadToStadDto(s));
    }

    public IEnumerable<WeerstationDto> GeefWeerstations()
    {
        return weerstationManager.GeefWeerstations().Select(ws => WeerstationMapper.ConvertWeerstationToWeerstationDto(ws));
    }

    public IEnumerable<MetingDto> GeefMetingen() {
        return weerstationManager.GeefMetingen().Select(m => MetingMapper.ConvertMetingToMetingDto(m));
    }

    public void DoeMetingen() {
        weerstationManager.VoerMetingUit();
    }

    public WeerberichtDto GeefWeerbericht()
    {
        var weerbericht = weerberichtGenerator.GenereerWeerbericht();

        return new WeerberichtDto
        {
            Moment = weerbericht.Moment,
            Bericht = weerbericht.Bericht
        };
    }
}