using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using TalabatHackathon.API.Services;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables();

builder.Configuration.AddConfiguration(configurationBuilder.Build());

builder.Services.Scan(scan => scan.FromAssemblyOf<Program>());
builder.Services.AddSingleton<ITranslateService, TranslateService>();
builder.Services.Decorate<ITranslateService, CacheTranslateService>();

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(o =>
{
    o.AssumeDefaultVersionWhenUnspecified = true;
    o.DefaultApiVersion = new(1, 0);
    o.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(
    options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
