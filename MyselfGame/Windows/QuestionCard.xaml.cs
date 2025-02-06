namespace MyselfGame.Windows;

public partial class QuestionCard : Window
{
    public QuestionCard()
    {
        InitializeComponent();
    }

    public Question Question { get; set; } = new();

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrEmpty(QuestionContent.Text) && !string.IsNullOrEmpty(Answer.Text) && int.TryParse(Points.Text, out int points))
        {
            Question.Content = QuestionContent.Text;
            Question.Answer = Answer.Text;
            Question.Points = points;

            DialogResult = true;
        }
    }

    private void Surface_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        WindowState = WindowState.Normal;
        DragMove();
    }
}