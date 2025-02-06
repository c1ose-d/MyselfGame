namespace MyselfGame.Pages;

public partial class GameContainer : UserControl
{
    public GameContainer()
    {
        InitializeComponent();

        int
            columns = 0,
            rows = StaticResources.SelectedGame.Themes.Count;
        foreach (Theme theme in StaticResources.SelectedGame.Themes)
        {
            if (theme.Questions.Count > columns)
            {
                columns = theme.Questions.Count;
            }
        }

        Grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto)});
        for (int i = 0; i < columns; i++)
        {
            Grid.ColumnDefinitions.Add(new ColumnDefinition());
        }
        for (int i = 0; i < rows; i++)
        {
            Grid.RowDefinitions.Add(new RowDefinition());
        }

        for (int i = 0; i < rows; i++)
        {
            TextBlock themeName = new()
            {
                Style = (Style)Application.Current.FindResource("Text.Title"),
                Text = StaticResources.SelectedGame.Themes[i].Name,
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.Children.Add(themeName);

            Grid.SetRow(themeName, i);

            for (int j = 0; j < columns; j++)
            {
                Button button = new()
                {
                    Content = StaticResources.SelectedGame.Themes[i].Questions[j].Points.ToString(),
                    DataContext = StaticResources.SelectedGame.Themes[i].Questions[j],
                    FontSize = 64,
                    Height = double.NaN,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    Margin = new Thickness(16),
                    MaxHeight = double.MaxValue,
                    MaxWidth = double.MaxValue,
                    Style = (Style)Application.Current.FindResource("Button.Accent.TextOnly"),
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Width = double.NaN
                };
                button.Click += Button_Click;
                Grid.Children.Add(button);

                Grid.SetColumn(button, j + 1);
                Grid.SetRow(button, i);
            }
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Question question = (Question)((Button)sender).DataContext;
        ((Button)sender).IsEnabled = false;

        QuestionContainer questionContainer = new(question);
        ((Border)Parent).Child = questionContainer;
    }
}