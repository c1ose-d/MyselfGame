namespace MyselfGame;

public partial class App : Application
{
    public App()
    {
        AppContext.SetSwitch("Switch.System.Windows.Controls.Text.UseAdornerForTextboxSelectionRendering", false);

        if (!Directory.Exists(@".\Games"))
        {
            Directory.CreateDirectory(@".\Games");
        }
    }
}