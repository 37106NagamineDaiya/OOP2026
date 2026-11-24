using System.Globalization;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using WeatherForecastApp.Models;

namespace WeatherForecastApp.Services;

public sealed class WeatherService
{
    private static readonly HttpClient HttpClient = new()
    {
        BaseAddress = new Uri("https://api.open-meteo.com/"),
        Timeout = TimeSpan.FromSeconds(15)
    };

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<WeatherData> GetWeatherAsync(City city, CancellationToken cancellationToken = default)
    {
        string latitude = city.Latitude.ToString(CultureInfo.InvariantCulture);
        string longitude = city.Longitude.ToString(CultureInfo.InvariantCulture);
        string requestUri =
            $"v1/forecast?latitude={latitude}&longitude={longitude}" +
            "&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m" +
            "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max" +
            "&timezone=Asia%2FTokyo&forecast_days=7";

        using HttpResponseMessage response = await HttpClient.GetAsync(requestUri, cancellationToken);
        response.EnsureSuccessStatusCode();

        await using Stream responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
        ApiResponse? apiResponse = await JsonSerializer.DeserializeAsync<ApiResponse>(responseStream, JsonOptions, cancellationToken);

        if (apiResponse?.Current is null || apiResponse.Daily is null)
            throw new InvalidOperationException("天気データの形式が正しくありません。");

        ValidateDailyData(apiResponse.Daily);

        var forecasts = Enumerable.Range(0, apiResponse.Daily.Time.Count)
            .Select(index => new DailyForecast
            {
                Date = DateTime.Parse(apiResponse.Daily.Time[index], CultureInfo.InvariantCulture),
                WeatherCode = apiResponse.Daily.WeatherCode[index],
                MaxTemperature = apiResponse.Daily.TemperatureMax[index],
                MinTemperature = apiResponse.Daily.TemperatureMin[index],
                PrecipitationProbability = apiResponse.Daily.PrecipitationProbabilityMax[index]
            })
            .ToList();

        return new WeatherData
        {
            Current = new CurrentWeather
            {
                Temperature = apiResponse.Current.Temperature,
                RelativeHumidity = apiResponse.Current.RelativeHumidity,
                WeatherCode = apiResponse.Current.WeatherCode,
                WindSpeed = apiResponse.Current.WindSpeed
            },
            DailyForecasts = forecasts
        };
    }

    private static void ValidateDailyData(DailyResponse daily)
    {
        int count = daily.Time.Count;
        if (count == 0 || daily.WeatherCode.Count != count || daily.TemperatureMax.Count != count ||
            daily.TemperatureMin.Count != count || daily.PrecipitationProbabilityMax.Count != count)
            throw new InvalidOperationException("週間予報データの件数が一致しません。");
    }

    private sealed class ApiResponse
    {
        [JsonPropertyName("current")] public CurrentResponse? Current { get; init; }
        [JsonPropertyName("daily")] public DailyResponse? Daily { get; init; }
    }

    private sealed class CurrentResponse
    {
        [JsonPropertyName("temperature_2m")] public double Temperature { get; init; }
        [JsonPropertyName("relative_humidity_2m")] public int RelativeHumidity { get; init; }
        [JsonPropertyName("weather_code")] public int WeatherCode { get; init; }
        [JsonPropertyName("wind_speed_10m")] public double WindSpeed { get; init; }
    }

    private sealed class DailyResponse
    {
        [JsonPropertyName("time")] public List<string> Time { get; init; } = [];
        [JsonPropertyName("weather_code")] public List<int> WeatherCode { get; init; } = [];
        [JsonPropertyName("temperature_2m_max")] public List<double> TemperatureMax { get; init; } = [];
        [JsonPropertyName("temperature_2m_min")] public List<double> TemperatureMin { get; init; } = [];
        [JsonPropertyName("precipitation_probability_max")] public List<int> PrecipitationProbabilityMax { get; init; } = [];
    }
}
