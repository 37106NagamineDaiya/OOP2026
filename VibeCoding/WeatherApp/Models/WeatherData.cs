using System;
using System.Collections.Generic;
using System.Globalization;

namespace WeatherApp.Models
{
    public sealed record City(
        string Name,
        double Latitude,
        double Longitude)
    {
        public override string ToString() => Name;
    }

    public sealed class WeatherData
    {
        public required CurrentWeather Current { get; init; }

        public required IReadOnlyList<DailyForecast> Daily
        {
            get;
            init;
        }
    }

    public sealed class CurrentWeather
    {
        public double Temperature { get; init; }

        public int Humidity { get; init; }

        public double WindSpeed { get; init; }

        public int Code { get; init; }

        // 例: ☀️ 快晴
        public string Description =>
            WeatherCode.ToDisplayText(Code);

        // 絵文字だけを使いたい場合
        public string Emoji =>
            WeatherCode.ToEmoji(Code);
    }

    public sealed class DailyForecast
    {
        public DateTime Date { get; init; }

        public int Code { get; init; }

        public double Max { get; init; }

        public double Min { get; init; }

        public int Rain { get; init; }

        public string DateLabel =>
            Date.ToString(
                "M/d (ddd)",
                CultureInfo.GetCultureInfo("ja-JP"));

        // 例: 🌧️ 雨
        public string Description =>
            WeatherCode.ToDisplayText(Code);

        // 絵文字だけを使いたい場合
        public string Emoji =>
            WeatherCode.ToEmoji(Code);
    }

    public static class WeatherCode
    {
        public static string ToJapanese(int code) =>
            code switch
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

        public static string ToEmoji(int code) =>
            code switch
            {
                0 => "☀️",
                1 => "🌞",
                2 => "⛅",
                3 => "☁️",

                45 or 48 => "🌫️",

                51 or 53 or 55 => "🌦️",
                56 or 57 => "🌧️",

                61 or 63 => "🌧️",
                65 => "☔",
                66 or 67 => "🌧️",

                71 or 73 or 75 or 77 => "🌨️",

                80 or 81 or 82 => "🌦️",
                85 or 86 => "❄️",

                95 => "⛈️",
                96 or 99 => "⛈️",

                _ => "❔"
            };

        public static string ToDisplayText(int code)
        {
            return $"{ToEmoji(code)} {ToJapanese(code)}";
        }
    }
}