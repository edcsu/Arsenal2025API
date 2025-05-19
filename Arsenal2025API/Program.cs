using System.Text.Json.Serialization;
using Arsenal2025API.Services;
using Scalar.AspNetCore;
using Serilog;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Debug()
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting up Env:{Environment}", environment);
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    builder.Services.AddSerilog((services, lc) => lc
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .Enrich.WithAssemblyName()
        .Enrich.WithAssemblyVersion()
        .Enrich.WithClientIp()
        .Enrich.WithCorrelationId()
        .Enrich.WithEnvironmentName()
        .Enrich.WithMachineName()
        .Enrich.WithProcessId()
        .Enrich.WithProcessName()
        .Enrich.WithThreadId()
        .Enrich.WithThreadName()
        .Enrich.WithAssemblyName());

    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.Services.AddScoped<DataService>();

    var app = builder.Build();
        
    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.MapScalarApiReference("api-docs", options =>
        {
            options.Title = "Arsenal 2024/2025 Demo API";
            options.ShowSidebar = true;
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception exception)
{
    var type = exception.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.OrdinalIgnoreCase))
    {
        throw;
    }
    Log.Fatal(exception, "Unknown exception");
}
finally
{
    Log.Information("Application completely stopped");
    Log.CloseAndFlush();
}