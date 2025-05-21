using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen;

namespace WeerEventsApi.Weerberichten.Factories;

public interface IWeerberichtGenerator {
    WeerberichtDto GenereerWeerbericht(IEnumerable<MetingDto> metingen);

    static WeerberichtDto GenereerWeerberichtProxy(IEnumerable<MetingDto> metingen) {
        var weerberichtGen = new WeerberichtGenerator();
        var proxyWeerBerichtGen = new WeerberichtGeneratorProxy(weerberichtGen);
        return proxyWeerBerichtGen.GenereerWeerbericht(metingen);
    }
}