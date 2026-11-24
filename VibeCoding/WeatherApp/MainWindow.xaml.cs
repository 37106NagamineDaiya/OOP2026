using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WeatherApp.Models;
using WeatherApp.Services;
namespace WeatherApp;
public partial class MainWindow : Window {
    readonly WeatherService service = new(); readonly City[] cities = [new("東京", 35.6762, 139.6503), new("札幌", 43.0618, 141.3545), new("前橋", 36.3895, 139.0634), new("名古屋", 35.1815, 136.9066), new("大阪", 34.6937, 135.5023), new("福岡", 33.5904, 130.4017), new("那覇", 26.2124, 127.6809)];
    public MainWindow() { InitializeComponent(); CityBox.ItemsSource = cities; CityBox.SelectedIndex = 0; Loaded += async (_, _) => await Load(); }
    async void UpdateClicked(object s, RoutedEventArgs e) => await Load(); async void CityChanged(object s, SelectionChangedEventArgs e) { if (IsLoaded) await Load(); }
    async Task Load() { if (CityBox.SelectedItem is not City c) return; UpdateButton.IsEnabled = false; StatusText.Text = $"{c.Name}の天気を取得中..."; try { var w = await service.GetAsync(c); CityText.Text = c.Name; TempText.Text = $"{w.Current.Temperature:0.#}℃"; WeatherText.Text = w.Current.Description; HumidityText.Text = $"{w.Current.Humidity}%"; WindText.Text = $"{w.Current.WindSpeed:0.#} km/h"; UpdatedText.Text = $"最終更新  {DateTime.Now:M月d日 HH:mm}"; ForecastList.ItemsSource = w.Daily; Show("最新データを取得しました。", false); } catch (Exception ex) { Show($"通信またはデータ取得に失敗しました。アプリは終了していません。詳細: {ex.Message}", true); } finally { UpdateButton.IsEnabled = true; } }
    void Show(string m, bool err) { StatusText.Text = m; StatusBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(err ? "#FDEBEC" : "#E8EEF8")); }
}
