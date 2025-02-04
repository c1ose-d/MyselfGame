namespace MyselfGame.Windows;

public partial class TeamsWindow : Window
{
    public TeamsWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        ListView.ItemsSource = StaticResources.Teams;
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        TeamCard teamCard = new(null);

        if (teamCard.ShowDialog() == true)
        {
            ListView.ItemsSource = null;
            ListView.ItemsSource = StaticResources.Teams;
        }
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            _ = StaticResources.Teams.Remove((Team)ListView.SelectedItem);
        }
        catch { }
    }

    private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        try
        {
            TeamCard teamCard = new((Team)ListView.SelectedItem);

            if (teamCard.ShowDialog() == true)
            {
                ListView.ItemsSource = null;
                ListView.ItemsSource = StaticResources.Teams;
            }
        }
        catch { }
    }

    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}