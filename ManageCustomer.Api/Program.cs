var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

app.MapGet("/", () => "Hello, world!");

app.Urls.Add("http://*:5030");

startup.Configure(app, app.Environment);


app.Run();
