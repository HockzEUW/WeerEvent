using WeerEventsApi.Facade.Dto;

namespace WeerEventsApi.Weerberichten.Factories;

public interface IWeerberichtGenerator {
    WeerberichtDto GenereerWeerbericht();
}