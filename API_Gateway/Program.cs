using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();

var app = builder.Build();

// Utiliser le middleware Prometheus
app.UseMetricServer();  // Ajoute un endpoint pour les métriques Prometheus
app.UseHttpMetrics();   // Collecte les métriques HTTP (requêtes, latence, etc.)

await app.UseOcelot();

app.Run();
