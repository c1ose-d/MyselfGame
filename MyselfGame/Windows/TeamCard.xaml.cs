namespace MyselfGame.Windows;

public partial class TeamCard : Window
{
    public TeamCard(Team? team)
    {
        InitializeComponent();

        Team = team;
    }

    private Team? Team { get; set; }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        if (Team != null)
        {
            TeamName.Text = Team.Name;
        }
    }

    private void Name_TextChanged(object sender, TextChangedEventArgs e)
    {
        ElementName.Text = TeamName.Text;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (Team != null)
        {
            if (!string.IsNullOrEmpty(TeamName.Text))
            {
                Team.Name = TeamName.Text;
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(TeamName.Text))
            {
                Team = new()
                {
                    Name = TeamName.Text
                };

                StaticResources.Teams.Add(Team);
            }
        }

        DialogResult = true;
    }

    private void Surface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Normal;
        DragMove();
    }
}