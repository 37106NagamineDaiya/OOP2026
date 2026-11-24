using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WeatherForecastApp.Models;
using WeatherForecastApp.Services;

namespace WeatherForecastApp;

public partial class MainWindow : Window
{
    private readonly WeatherService _weatherService = new();
    private CancellationTokenSource? _cancellationTokenSource;

    private readonly IReadOnlyList<City> _cities =
    [
        new("東京", 35.6762, 139.6503), new("札幌", 43.0618, 141.3545),
        new("仙台", 38.2682, 140.8694), new("前橋", 36.3895, 139.0634),
        new("名古屋", 35.1815, 136.9066), new("大阪", 34.6937, 135.5023),
        new("広島", 34.3853, 132.4553), new("福岡", 33.5904, 130.4017),
        new("那覇", 26.2124, 127.6809)
    ];

    public MainWindow()
    {
        InitializeComponent();
        CityComboBox.ItemsSource = _cities;
        CityComboBox.SelectedIndex = 0;
        Loaded += async (_, _) => await LoadWeatherAsync();
        Closed += (_, _) => _cancellationTokenSource?.Cancel();
    }

    private async void RefreshButton_Click(object sender, RoutedEventArgs e) => await LoadWeatherAsync();

    private async void CityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (IsLoaded) await LoadWeatherAsync();
    }

    private async Task LoadWeatherAsync()
    {
        if (CityComboBox.SelectedItem is not City city) return;

        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        _cancellationTokenSource = new CancellationTokenSource();

        SetLoadingState(true, $"{city.Name}の天気を取得しています...");

        try
        {
            WeatherData weather = await _weatherService.GetWeatherAsync(city, _cancellationTokenSource.Token);
            ShowWeather(city, weather);
            ShowStatus("最新の天気データを取得しました。", false);
        }
        catch (OperationCanceledException) { }
        catch (HttpRequestException ex)
        {
            ShowStatus($"通信に失敗しました。インターネット接続またはAPIの状態を確認してください。詳細: {ex.Message}", true);
        }
        catch (TaskCanceledException)
        {
            ShowStatus("通信がタイムアウトしました。しばらくしてから再度お試しください。", true);
        }
        catch (Exception ex)
        {
            ShowStatus($"天気データを表示できませんでした。詳細: {ex.Message}", true);
        }
        finally
        {
            SetLoadingState(false, StatusText.Text);
        }
    }

    private void ShowWeather(City city, WeatherData weather)
    {
        LocationText.Text = city.Name;
        CurrentWeatherSymbolText.Text = weather.Current.WeatherSymbol;
        CurrentTemperatureText.Text = $"{weather.Current.Temperature:0.#}℃";
        CurrentDescriptionText.Text = weather.Current.WeatherDescription;
        HumidityText.Text = $"{weather.Current.RelativeHumidity} %";
        WindSpeedText.Text = $"{weather.Current.WindSpeed:0.#} km/h";
        UpdatedAtText.Text = DateTime.Now.ToString("M月d日 HH:mm");
        ForecastItemsControl.ItemsSource = weather.DailyForecasts;
    }

    private void SetLoadingState(bool isLoading, string message)
    {
        RefreshButton.IsEnabled = !isLoading;
        CityComboBox.IsEnabled = !isLoading;
        RefreshButton.Content = isLoading ? "取得中" : "更新";
        if (isLoading) ShowStatus(message, false);
    }

    private void ShowStatus(string message, bool isError)
    {
        StatusText.Text = message;
        StatusBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(isError ? "#FDEBEC" : "#E8EEF8"));
        StatusText.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(isError ? "#9D2632" : "#40516B"));
    }
}
