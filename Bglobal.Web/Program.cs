using Bglobal.Data;
using Bglobal.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Vehiculos}/{action=Index}/{id?}");

app.Run();
