using WeerEventsApi.Facade.Dto;
using WeerEventsApi.Metingen;

namespace WeerEventsApi.Weerberichten.Factories;

public interface IWeerberichtGenerator {
    WeerberichtDto GenereerWeerbericht();
}