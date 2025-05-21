using System.Text.Json;
using WeerEventsApi.Steden.Models;

namespace WeerEventsApi.Steden.Repositories;

public class StadRepository : IStadRepository
{
    public IEnumerable<Stad> GetSteden()
    {
        return JsonSerializer.Deserialize<List<Stad>>(File.ReadAllText("Steden/Data/steden.json"))!;
    }
}