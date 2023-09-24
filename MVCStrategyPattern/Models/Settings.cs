namespace MVCStrategyPattern.Models;

public class Settings
{
    public static string claimDatabaseType = "databasetype";

    public EDatabaseType DatabaseType;

    public EDatabaseType DefaultDatabaseType => EDatabaseType.SqlServer;
}
