using WeerEventsApi.Facade.Dto;

namespace WeerEventsApi.Weerberichten.Factories;

public class WeerberichtGeneratorProxy(IWeerberichtGenerator inner) : IWeerberichtGenerator {
    private WeerberichtDto? _cached;
    private DateTime _laatsteWeerberichtGemaakt = DateTime.MinValue;

    public WeerberichtDto GenereerWeerbericht()
    {
        if (_cached == null || DateTime.Now - _laatsteWeerberichtGemaakt > TimeSpan.FromMinutes(1))
        {
            _cached = inner.GenereerWeerbericht();
            _laatsteWeerberichtGemaakt = DateTime.Now;
        }
        return _cached;
    }
}