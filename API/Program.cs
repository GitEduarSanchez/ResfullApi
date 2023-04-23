using API.Config;
using API.Controllers;
using API.Validations;
using APIResfault.Application.Services;
using APIResfault.Application.Services.Filter;
using APIResfault.Application.Services.Post;
using APIRestful.Entities.Interfaces;
using APIRestful.Entities.Models.Request;
using APIRestfull.Interfaces;
using APIRestfull.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;


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
builder.Services.AddTransient<IValidator<RequestJourney>, ValidationRequest>();





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
