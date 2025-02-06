namespace MyselfGame.Windows;

public partial class SelectGame : Window
{
    public SelectGame()
    {
        InitializeComponent();
    }

    List<Game> Games { get; set; } = [];

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (string file in Directory.EnumerateFiles(@".\Games"))
        {
            Game game = new()
            {
                Name = file.Replace(@".\Games\", "").Replace(".txt", "")
            };

            foreach (string line in File.ReadLines(file).Where(x => !string.IsNullOrEmpty(x)))
            {
                List<string> strings = [.. line.Split(";")];

                Theme theme = new()
                {
                    Name = strings[0]
                };

                for (int i = 1; i < strings.Count; i++)
                {
                    Question question = new()
                    {
                        Content = strings[i].Split(":")[0],
                        Answer = strings[i].Split(":")[1],
                        Points = Convert.ToInt32(strings[i].Split(":")[2])
                    };

                    theme.Questions.Add(question);
                }

                game.Themes.Add(theme);
            }

            Games.Add(game);
        }

        ListView.ItemsSource = Games;
    }

    private void Folder_Click(object sender, RoutedEventArgs e)
    {
        Process process = new();
        process.StartInfo.FileName = "explorer";
        process.StartInfo.Arguments = Directory.GetCurrentDirectory() + @"\Games";
        _ = process.Start();
    }

    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }

    private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        try
        {
            StaticResources.SelectedGame = (Game)ListView.SelectedItem;

            DialogResult = true;
        }
        catch { }
    }
}