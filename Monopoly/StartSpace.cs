namespace Monopoly;

public class StartSpace : Space
{
    public StartSpace()
    {
        Name = "START";
    }

    public override string ExecuteAction(Player player)
    {
        decimal gewinn = player.Money / 3;
        player.MoneyChanges(gewinn);
        return $"{player.Name} ist die {player.Lap - 1}. Runde durchgelaufen und erhält einen Bonus {gewinn:F2} €";
    }
}
