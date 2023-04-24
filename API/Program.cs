using API.Config;
using API.Services.Currency.Fake;
using API.Validations;
using APIResfault.Application.Services;
using APIResfault.Application.Services.Currency;
using APIResfault.Application.Services.Filter;
using APIResfault.Application.Services.Post;
using APIRestful.Domain.Interfaces;
using APIRestful.Domain.Models.Request;
using APIRestfull.Services;
using FluentValidation;


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
builder.Services.AddScoped<ISetPostFlight, PostService>();
builder.Services.AddScoped<ICurrency, CurrencyServices>();
builder.Services.AddTransient<IValidator<RequestJourney>, ValidationRequest>();
builder.Services.AddTransient<ICurrencyType, CuerrencyTypeFake>();
builder.Services.AddTransient<ICurrencyValue, ConfigHttpCurrency>();
builder.Services.AddTransient<ICurrencyConvert, CurrencyConvertServices>();

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
