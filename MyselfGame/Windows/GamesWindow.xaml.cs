namespace MyselfGame.Windows;

public partial class GamesWindow : Window
{
    public GamesWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (string file in Directory.EnumerateFiles(@".\Games"))
        {
            TextBlock textBlock = new()
            {
                Style = (Style)Application.Current.FindResource("Text.BodyStrong"),
                Text = file.Replace(@".\Games\", "").Replace(".txt", "")
            };
            ListView.Items.Add(textBlock);
        }
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        GameCard gameCard = new();

        if (gameCard.ShowDialog() == true)
        {
            ListView.Items.Clear();
            foreach (string file in Directory.EnumerateFiles(@".\Games"))
            {
                TextBlock textBlock = new()
                {
                    Style = (Style)Application.Current.FindResource("Text.BodyStrong"),
                    Text = file.Replace(@".\Games\", "").Replace(".txt", "")
                };
                ListView.Items.Add(textBlock);
            }
        }
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            File.Delete(@$".\Games\{((TextBlock)ListView.SelectedItem).Text}.txt");

            ListView.Items.Clear();
            foreach (string file in Directory.EnumerateFiles(@".\Games"))
            {
                TextBlock textBlock = new()
                {
                    Style = (Style)Application.Current.FindResource("Text.BodyStrong"),
                    Text = file.Replace(@".\Games\", "").Replace(".txt", "")
                };
                ListView.Items.Add(textBlock);
            }
        }
        catch { }
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
        DialogResult = true;
    }
}