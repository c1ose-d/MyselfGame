namespace MyselfGame.Windows;

public partial class ThemeCard : Window
{
    public ThemeCard()
    {
        InitializeComponent();
    }

    public Theme Theme { get; set; } = new();

    private void Surface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Normal;
        DragMove();
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        QuestionCard questionCard = new();
        if (questionCard.ShowDialog() == true)
        {
            Theme.Questions.Add(questionCard.Question);

            ListView.ItemsSource = null;
            ListView.ItemsSource = Theme.Questions;
        }
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            Theme.Questions.Remove((Question)ListView.SelectedItem);

            ListView.ItemsSource = null;
            ListView.ItemsSource = Theme.Questions;
        }
        catch { }
    }

    private void ThemeName_TextChanged(object sender, TextChangedEventArgs e)
    {
        ElementName.Text = ThemeName.Text;

        Theme.Name = ThemeName.Text;
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (ListView.Items.Count > 0)
        {
            DialogResult = true;
        }
    }
}