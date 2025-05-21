using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging;

public interface IMetingLogger
{
    void LogInXml(Meting meting);
    void LogInJson(Meting meting);
}