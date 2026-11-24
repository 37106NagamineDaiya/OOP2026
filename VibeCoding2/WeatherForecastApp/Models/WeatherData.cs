namespace WeatherForecastApp.Models;

public sealed class WeatherData
{
    public required CurrentWeather Current { get; init; }
    public required IReadOnlyList<DailyForecast> DailyForecasts { get; init; }
}

public sealed class CurrentWeather
{
    public double Temperature { get; init; }
    public int RelativeHumidity { get; init; }
    public double WindSpeed { get; init; }
    public int WeatherCode { get; init; }
    public string WeatherDescription => WeatherCodeConverter.ToJapanese(WeatherCode);
    public string WeatherSymbol => WeatherCodeConverter.ToSymbol(WeatherCode);
}

public sealed class DailyForecast
{
    public DateTime Date { get; init; }
    public int WeatherCode { get; init; }
    public double MaxTemperature { get; init; }
    public double MinTemperature { get; init; }
    public int PrecipitationProbability { get; init; }
    public string WeatherDescription => WeatherCodeConverter.ToJapanese(WeatherCode);
    public string WeatherSymbol => WeatherCodeConverter.ToSymbol(WeatherCode);
    public string DateLabel => Date.ToString("M/d (ddd)", System.Globalization.CultureInfo.GetCultureInfo("ja-JP"));
}

public sealed record City(string Name, double Latitude, double Longitude)
{
    public override string ToString() => Name;
}

public static class WeatherCodeConverter
{
    public static string ToJapanese(int code) => code switch
    {
        0 => "快晴",
        1 => "晴れ",
        2 => "一部曇り",
        3 => "曇り",
        45 or 48 => "霧",
        51 or 53 or 55 => "霧雨",
        56 or 57 => "着氷性の霧雨",
        61 or 63 or 65 => "雨",
        66 or 67 => "着氷性の雨",
        71 or 73 or 75 or 77 => "雪",
        80 or 81 or 82 => "にわか雨",
        85 or 86 => "にわか雪",
        95 => "雷雨",
        96 or 99 => "ひょうを伴う雷雨",
        _ => "不明"
    };

    public static string ToSymbol(int code) => code switch
    {
        0 or 1 => "☀",
        2 => "⛅",
        3 => "☁",
        45 or 48 => "≋",
        51 or 53 or 55 or 56 or 57 or 61 or 63 or 65 or 66 or 67 or 80 or 81 or 82 => "☂",
        71 or 73 or 75 or 77 or 85 or 86 => "❄",
        95 or 96 or 99 => "⚡",
        _ => "?"
    };
}
