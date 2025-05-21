using WeerEventsApi.Metingen;
using WeerEventsApi.Stations.Models;

namespace WeerEventsApi.Stations.Managers; 
public interface IWeerstationManager {
    public List<Meting> GeefMetingen();

    public void VoerMetingUit();

    public Meting GenereerMeting(Weerstation ws);

    public List<Weerstation> GeefWeerstations();
}