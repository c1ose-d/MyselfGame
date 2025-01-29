namespace MyselfGame;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private Button Last { get; set; } = null!;

    private void TeamsList_Click(object sender, RoutedEventArgs e)
    {
        Process process = new();
        process.StartInfo.FileName = "explorer";
        process.StartInfo.Arguments = Directory.GetCurrentDirectory() + @"\Teams.txt";
        _ = process.Start();
    }

    private void Refresh_Click(object sender, RoutedEventArgs e)
    {
        foreach (string line in File.ReadAllLines("Teams.txt"))
        {
            if (!string.IsNullOrEmpty(line.Trim()))
            {
                StaticResources.Teams.Add(new()
                {
                    Name = line.Trim()
                });
            }
        }

        Teams.ItemsSource = StaticResources.Teams.OrderBy(x => x.Name);

        foreach (Team team in StaticResources.Teams.OrderBy(x => x.Name))
        {
            Button button = new()
            {
                Style = (Style)Application.Current.FindResource("Button.Standart.TextOnly"),
                Content = team.Name
            };
            button.Click += Team_Click;

            SelectTeam.Children.Add(button);
        }
    }

    private void Team_Click(object sender, RoutedEventArgs e)
    {
        StaticResources.Teams.Single(x => x.Name == ((Button)sender).Content.ToString()).Points = Convert.ToInt32(Last.Content);

        Teams.ItemsSource = StaticResources.Teams.OrderBy(x => x.Name);

        Answer.Visibility = Visibility.Collapsed;
        Container.Visibility = Visibility.Visible;
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Last = (Button)sender;

        Last.IsEnabled = false;

        Question_Text.Text = Last.DataContext.ToString()!.Split("!")[0];

        Container.Visibility = Visibility.Collapsed;
        Question.Visibility = Visibility.Visible;
    }

    private void ShowAnswer_Click(object sender, RoutedEventArgs e)
    {
        Answer_Text.Text = Last.DataContext.ToString()!.Split("!")[1];

        Question.Visibility = Visibility.Collapsed;
        Answer.Visibility = Visibility.Visible;
    }

    private void Skip_Click(object sender, RoutedEventArgs e)
    {
        Answer.Visibility = Visibility.Collapsed;
        Container.Visibility = Visibility.Visible;
    }
}