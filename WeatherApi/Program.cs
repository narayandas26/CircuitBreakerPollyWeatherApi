using Microsoft.Net.Http.Headers;
using WeatherApi.MeteoClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpClient("MeteoClient", httpClient => {
    httpClient.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.UserAgent, "NarWeatherApi");
});

builder.Services.AddHttpClient<IMimicFailureClient, MimicFailureClient>();

builder.Services.AddScoped<IWeatherClient, MeteoWeatherClient>();
builder.Services.AddScoped<IMimicFailureClient, MimicFailureClient>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
