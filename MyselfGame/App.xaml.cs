namespace MyselfGame;

public partial class App : Application
{
    public App()
    {
        AppContext.SetSwitch("Switch.System.Windows.Controls.Text.UseAdornerForTextboxSelectionRendering", false);

        File.Create("Teams.txt").Close();
    }
}