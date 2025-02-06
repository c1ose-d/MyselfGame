using MyselfGame.Pages;

namespace MyselfGame;

public static class StaticResources
{
    public static List<Team> Teams { get; set; } = [];

    public static Game SelectedGame { get; set; } = null!;

    public static GameContainer GameContainer { get; set; } = null!;

    public static Border GameField { get; set; } = null!;
}

public class Team
{
    public string Name { get; set; } = null!;

    public int Points { get; set; } = 0;
}

public class Game
{
    public string Name { get; set; } = null!;

    public List<Theme> Themes { get; set; } = [];
}

public class Theme
{
    public string Name { get; set; } = null!;

    public List<Question> Questions { get; set; } = [];
}

public class Question
{
    public string Content { get; set; } = null!;

    public string Answer { get; set; } = null!;

    public int Points { get; set; }
}