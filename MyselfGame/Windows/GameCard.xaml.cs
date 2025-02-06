namespace MyselfGame.Windows;

public partial class GameCard : Window
{
    public GameCard()
    {
        InitializeComponent();
    }

    Game Game { get; set; } = new();

    private void Surface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Normal;
        DragMove();
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        ThemeCard themeCard = new();
        if (themeCard.ShowDialog() == true)
        {
            Game.Themes.Add(themeCard.Theme);

            ListView.ItemsSource = null;
            ListView.ItemsSource = Game.Themes;
        }
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Game.Themes.Remove((Theme)ListView.SelectedItem);

            ListView.ItemsSource = null;
            ListView.ItemsSource = Game.Themes;
        }
        catch { }
    }

    private void GameName_TextChanged(object sender, TextChangedEventArgs e)
    {
        ElementName.Text = GameName.Text;

        Game.Name = GameName.Text;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (ListView.Items.Count != 0 && !string.IsNullOrEmpty(GameName.Text))
        {
            File.Create(@$".\Games\{Game.Name}.txt").Close();

            foreach (Theme theme in Game.Themes)
            {
                string questions = string.Empty;
                for (int i = 0; i < theme.Questions.Count; i++)
                {
                    questions += $";{theme.Questions[i].Content}:{theme.Questions[i].Answer}:{theme.Questions[i].Points}";
                }

                File.AppendAllText(@$".\Games\{Game.Name}.txt", $"{theme.Name}{questions}\r\n");
            }

            DialogResult = true;
        }
    }
}