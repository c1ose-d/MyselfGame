namespace MyselfGame;

public static class StaticResources
{
    public static List<Team> Teams { get; set; } = [];
}

public class Team
{
    public string Name { get; set; } = null!;

    public int Points { get; set; } = 0;
}