using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Ngclopedia.Application;
using Ngclopedia.Auth;
using Ngclopedia.Infrastructure;
using Ngclopedia.Infrastructure.Common;
using Ngclopedia.WebApi.Configurations;
using Ngclopedia.WebApi.Controllers;
using Serilog;

[assembly: ApiConventionType(typeof(NgclopediaApiConventions))]

StaticLogger.EnsureInitialized();
Log.Information("Server booting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.AddConfigurations();

    builder.Host.UseSerilog((_, config) =>
    {
        config.WriteTo.Console()
            .ReadFrom.Configuration(builder.Configuration);
    });

    builder.Services.AddControllers(config =>
    {
        config.RespectBrowserAcceptHeader = true;
        config.ReturnHttpNotAcceptable = true;
        config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
        config.CacheProfiles.Add("120SecondsDuration", new CacheProfile { Duration = 120 });
    });
    //.AddFluentValidation();
    //builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddAuth(builder.Configuration);
    builder.Services.AddApplication();

    var app = builder.Build();

    app.UseInfrastructure(builder.Configuration);
    app.UseAuth();
    app.MapEndpoints();
    app.Run();
}
catch (Exception ex) when (!ex.GetType().Name.Equals("StopTheHostException", StringComparison.Ordinal))
{
    StaticLogger.EnsureInitialized();
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    StaticLogger.EnsureInitialized();
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}

NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
{
    return new ServiceCollection().AddLogging().AddMvc().AddNewtonsoftJson()
        .Services.BuildServiceProvider()
        .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
        .OfType<NewtonsoftJsonPatchInputFormatter>().First();
}


/*// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
//builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureHttpsRedirection();
//builder.Services.ConfigureServiceManager();
builder.Services.ConfigurePsqlContext(builder.Configuration);
builder.Services.ConfigureDefaultIdentity();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();*/