using System.Windows.Media;

namespace MyselfGame.Pages;

public partial class AnswerContainer : UserControl
{
    public AnswerContainer(Question question)
    {
        InitializeComponent();

        Question = question;
    }

    Question Question { get; set; } = null!;

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        AnswerContent.Text = Question.Answer;

        foreach (Team team in StaticResources.Teams)
        {
            Button button = new()
            {
                Content = team.Name,
                Style = (Style)Application.Current.FindResource("Button.Accent.TextOnly")
            };
            button.Click += Button_Click;
            TeamsField.Children.Add(button);
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        StaticResources.Teams.Single(x => x.Name == ((Button)sender).Content.ToString()).Points += Question.Points;

        ((StackPanel)Application.Current.MainWindow.FindName("TeamsField")).Children.Clear();
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

            ((StackPanel)Application.Current.MainWindow.FindName("TeamsField")).Children.Add(border);

            StaticResources.GameField.Child = StaticResources.GameContainer;
        }
    }
}