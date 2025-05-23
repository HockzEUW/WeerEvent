using WeerEventsApi.Facade.Controllers;
using WeerEventsApi.Logging;
using WeerEventsApi.Logging.Factories;
using WeerEventsApi.Stations;
using WeerEventsApi.Stations.Managers;
using WeerEventsApi.Steden.Managers;
using WeerEventsApi.Steden.Repositories;
using WeerEventsApi.Weerberichten.Factories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = builder.Services.AddSingleton<IMetingLogger>(MetingLoggerFactory.Create(true, true));
builder.Services.AddSingleton<IStadRepository, StadRepository>();
builder.Services.AddSingleton<IStadManager, StadManager>();
builder.Services.AddSingleton<WeerberichtGenerator>();
builder.Services.AddSingleton<IDomeinController, DomeinController>();
builder.Services.AddSingleton<IWeerberichtGenerator>(provider =>
    new WeerberichtGeneratorProxy(provider.GetRequiredService<WeerberichtGenerator>())
);
builder.Services.AddSingleton<IWeerstationManager>(provider => {
    var logger = provider.GetRequiredService<IMetingLogger>();
    var generator = provider.GetRequiredService<WeerberichtGenerator>();
    var stations = WeerstationFactory.CreateWeerstations(
        provider.GetRequiredService<IStadRepository>().GetSteden(),
        logger,
        generator
    );
    return new WeerstationManager(stations);
});


var app = builder.Build();

app.MapGet("/", () => "WEER - WEERsomstandigheden Evalueren En Rapporteren");

app.MapGet("/steden", (IDomeinController dc) => dc.GeefSteden());

app.MapGet("/weerstations", (IDomeinController dc) => dc.GeefWeerstations());

app.MapGet("/metingen", (IDomeinController dc) => dc.GeefMetingen());

app.MapGet("/weerbericht", (IDomeinController dc) => dc.GeefWeerbericht());

app.MapPost("/commands/meting-command", (IDomeinController dc) => dc.DoeMetingen());

app.Run();