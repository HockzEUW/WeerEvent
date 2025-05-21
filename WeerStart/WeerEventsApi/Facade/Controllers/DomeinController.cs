using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen.Factories;
using WeerEventsApi.Stations.Factories;
using WeerEventsApi.Stations.Managers;
using WeerEventsApi.Steden.Factories;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Weerberichten.Factories;

namespace WeerEventsApi.Facade.Controllers;

public class DomeinController : IDomeinController
{
    private readonly IStadManager _stadManager;
    private readonly IWeerstationManager _weerstationManager;
    private readonly WeerberichtGeneratorProxy _proxy;

    public DomeinController(
        IStadManager stadManager,
        IWeerstationManager weerstationManager,
        WeerberichtGeneratorProxy proxy
    )
    {
        _stadManager = stadManager;
        _weerstationManager = weerstationManager;
        _proxy = proxy;
    }

    public IEnumerable<StadDto> GeefSteden()
    {
        return _stadManager.GeefSteden().Select(s => StadMapper.ConvertStadToStadDto(s));
    }

    public IEnumerable<WeerstationDto> GeefWeerstations()
    {
        return _weerstationManager.GeefWeerstations().Select(ws => WeerstationMapper.ConvertWeerstationToWeerstationDto(ws));
    }

    public IEnumerable<MetingDto> GeefMetingen() {
        return _weerstationManager.GeefMetingen().Select(m => MetingMapper.ConvertMetingToMetingDto(m));
    }

    public void DoeMetingen() {
        _weerstationManager.VoerMetingUit();
    }

    public WeerberichtDto GeefWeerbericht()
    {
        var metingen = GeefMetingen();
        var weerbericht = _proxy.GenereerWeerbericht(metingen);

        return new WeerberichtDto
        {
            Moment = weerbericht.Moment,
            Bericht = weerbericht.Bericht
        };
    }
}