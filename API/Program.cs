using API.Config;
using APIResfault.Application.Services;
using APIResfault.Application.Services.Filter;
using APIRestful.Entities.Interfaces;
using APIRestfull.Interfaces;
using APIRestfull.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFlight, FligthsServices>();
builder.Services.AddScoped<IConfig, Config>();
builder.Services.AddScoped<IFlightFiltered, FilterFlightServices>();
builder.Services.AddScoped<ITotalCalculator, PriceCalculatorService>();
builder.Services.AddScoped<IBuildJson, BuildJsonService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
