using System.Globalization; using System.Text.Json; using System.Text.Json.Serialization; using WeatherApp.Models;
namespace WeatherApp.Services;
using System.Net.Http;

public sealed class WeatherService {
 static readonly HttpClient Client=new(){BaseAddress=new("https://api.open-meteo.com/"),Timeout=TimeSpan.FromSeconds(15)
 };

 public async Task<WeatherData> GetAsync(City city,CancellationToken ct=default){
  string lat=city.Latitude.ToString(CultureInfo.InvariantCulture),lon=city.Longitude.ToString(CultureInfo.InvariantCulture);
  string u=$"v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,relative_humidity_2m,weather_code,wind_speed_10m&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&timezone=Asia%2FTokyo&forecast_days=7";
  using var r=await Client.GetAsync(u,ct); r.EnsureSuccessStatusCode(); await using var s=await r.Content.ReadAsStreamAsync(ct); var a=await JsonSerializer.DeserializeAsync<Api>(s,cancellationToken:ct)??throw new InvalidOperationException("天気データを解析できません。");
  if(a.Current is null||a.Daily is null||a.Daily.Time.Count!=7) throw new InvalidOperationException("天気データの形式が正しくありません。");
  return new(){Current=new(){Temperature=a.Current.Temperature,Humidity=a.Current.Humidity,WindSpeed=a.Current.Wind,Code=a.Current.Code},Daily=Enumerable.Range(0,7).Select(i=>new DailyForecast{Date=DateTime.Parse(a.Daily.Time[i]),Code=a.Daily.Code[i],Max=a.Daily.Max[i],Min=a.Daily.Min[i],Rain=a.Daily.Rain[i]}).ToList()}; 
    }


 sealed class Api{[JsonPropertyName("current")]public Cur? Current{get;init;}[JsonPropertyName("daily")]public Day? Daily{get;init;}}
 sealed class Cur{[JsonPropertyName("temperature_2m")]public double Temperature{get;init;}[JsonPropertyName("relative_humidity_2m")]public int Humidity{get;init;}[JsonPropertyName("weather_code")]public int Code{get;init;}[JsonPropertyName("wind_speed_10m")]public double Wind{get;init;}}
 sealed class Day{[JsonPropertyName("time")]public List<string> Time{get;init;}=[];[JsonPropertyName("weather_code")]public List<int> Code{get;init;}=[];[JsonPropertyName("temperature_2m_max")]public List<double> Max{get;init;}=[];[JsonPropertyName("temperature_2m_min")]public List<double> Min{get;init;}=[];[JsonPropertyName("precipitation_probability_max")]public List<int> Rain{get;init;}=[];}
}
