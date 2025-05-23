using Microsoft.Extensions.WebEncoders.Testing;
using System.Text.Json;
using System.Xml.Linq;
using WeerEventsApi.Logging.Observer;
using WeerEventsApi.Metingen;

namespace WeerEventsApi.Logging;

public class MetingLogger : IMetingLogger, IObserver
{
    public virtual void Log(Meting meting)
    {
        Console.WriteLine($"In {meting.Locatie.Naam} op {meting.Moment}: {meting.Waarde}{meting.Eenheid}");
    }

    public void Update(Meting meting)
    {
        Log(meting);
    }
}

public class XMLLogger(IMetingLogger inner) : IMetingLogger, IObserver
{
    public void Log(Meting meting)
    {
        var xml = new XElement("Meting",
            new XElement("Moment", meting.Moment.ToString("G")),
            new XElement("Waarde", meting.Waarde),
            new XElement("Eenheid", meting.Eenheid)
        );
        File.AppendAllText("log.xml", xml + Environment.NewLine);

        inner.Log(meting);
    }

    public void Update(Meting meting)
    {
        Log(meting);
    }
}

public class JSONLogger(IMetingLogger inner) : IMetingLogger, IObserver
{
    public void Log(Meting meting)
    {
        var options = new JsonSerializerOptions { WriteIndented = true, Encoder = JavaScriptTestEncoder.UnsafeRelaxedJsonEscaping };
        var json = JsonSerializer.Serialize(new
        {
            Moment = meting.Moment,
            Eenheid = meting.Eenheid,
            Waarde = meting.Waarde,
            Locatie = new
            {
                meting.Locatie.Naam,
                meting.Locatie.Beschrijving,
                meting.Locatie.GekendVoor
            }
        }, options);
        File.AppendAllText("log.json", json + Environment.NewLine);
        inner.Log(meting);
    }

    public void Update(Meting meting)
    {
        Log(meting);
    }
}