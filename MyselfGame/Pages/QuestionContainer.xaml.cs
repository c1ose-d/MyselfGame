namespace MyselfGame.Pages;

public partial class QuestionContainer : UserControl
{
    public QuestionContainer(Question question)
    {
        InitializeComponent();

        Question = question;
    }

    Question Question { get; set; } = null!;

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        QuestionContent.Text = Question.Content;

        Task task = new(InitializeTimer);
        task.Start();
    }

    private async void InitializeTimer()
    {
        while (true)
        {
            TimeSpan timeSpan = new(0, 2, 0);
            do
            {
                await Task.Delay(1000);
                timeSpan -= new TimeSpan(0, 0, 1);
                Timer.Dispatcher.Invoke(() => Timer.Text = $"{timeSpan.Minutes}:{timeSpan.Seconds}");
            } while (timeSpan > new TimeSpan(0, 0, 0));
        }
    }

    private void Continue_Click(object sender, RoutedEventArgs e)
    {
        AnswerContainer answerContainer = new(Question);
        StaticResources.GameField.Child = answerContainer;
    }
}