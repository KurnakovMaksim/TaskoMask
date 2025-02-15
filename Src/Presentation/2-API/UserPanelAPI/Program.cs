
using TaskoMask.Presentation.Framework.Web.Configuration.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebApiProjectConfigureServices(builder.Configuration);


var app = builder.Build();

app.UseWebApiProjectConfigure(app.Services, builder.Environment);


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
