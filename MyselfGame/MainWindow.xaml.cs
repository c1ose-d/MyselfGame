using MyselfGame.Pages;
using MyselfGame.Windows;
using System.Windows.Media;

namespace MyselfGame;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        switch (WindowState)
        {
            case WindowState.Normal:
                Max.Content = "";
                break;
            case WindowState.Maximized:
                Max.Content = "";
                break;
        }
    }

    private void Surface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Normal;
        DragMove();
    }

    private void Min_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void Max_Click(object sender, RoutedEventArgs e)
    {
        switch (WindowState)
        {
            case WindowState.Normal:
                try
                {
                    WindowStyle = WindowStyle.SingleBorderWindow;
                    WindowState = WindowState.Maximized;
                    WindowStyle = WindowStyle.None;
                }
                catch
                {
                    WindowState = WindowState.Maximized;
                }
                break;
            case WindowState.Maximized:
                WindowState = WindowState.Normal;
                break;
        }
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void CurrentGame_Click(object sender, RoutedEventArgs e)
    {
        SelectGame selectGame = new();
        if (selectGame.ShowDialog() == true)
        {
            CurrentGame.Content = StaticResources.SelectedGame.Name;

            StaticResources.GameField = GameField;
            StaticResources.GameContainer = new();
            StaticResources.GameField.Child = StaticResources.GameContainer;
        }
    }

    private void Start_Click(object sender, RoutedEventArgs e)
    {
        if (CurrentGame.Content.ToString() != "Не выбрано" && TeamsField.Children.Count > 0)
        {
            CurrentGame.IsEnabled = false;
            Start.IsEnabled = false;
            Games.IsEnabled = false;
            Teams.IsEnabled = false;

            End.IsEnabled = true;
            GameField.IsEnabled = true;
        }
    }

    private void End_Click(object sender, RoutedEventArgs e)
    {
        CurrentGame.IsEnabled = true;
        Start.IsEnabled = true;
        Games.IsEnabled = true;
        Teams.IsEnabled = true;

        End.IsEnabled = false;
        GameField.IsEnabled = false;

        CurrentGame.Content = "Не выбрано";
        GameField.Child = null;
    }

    private void Teams_Click(object sender, RoutedEventArgs e)
    {
        TeamsWindow teamsWindow = new();
        if (teamsWindow.ShowDialog() == true)
        {
            foreach (Team team in StaticResources.Teams)
            {
                Border border = new()
                {
                    BorderBrush = (SolidColorBrush)Application.Current.FindResource("Light.StrokeColor.SurfaceStroke"),
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(3),
                    Margin = new Thickness(8)
                };

                Grid grid = new();
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                border.Child = grid;

                TextBlock teamName = new()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Style = (Style)Application.Current.FindResource("Text.Title"),
                    Text = team.Name
                };
                grid.Children.Add(teamName);

                TextBlock teamPoints = new()
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Style = (Style)Application.Current.FindResource("Text.Subtitle"),
                    Text = team.Points.ToString()
                };
                grid.Children.Add(teamPoints);
                Grid.SetRow(teamPoints, 1);

                TeamsField.Children.Add(border);
            }
        }
    }

    private void Games_Click(object sender, RoutedEventArgs e)
    {
        GamesWindow gamesWindow = new();
        gamesWindow.ShowDialog();
    }
}