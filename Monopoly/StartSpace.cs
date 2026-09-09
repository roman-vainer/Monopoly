namespace Monopoly;

public class StartSpace : Space
{
    
    //Erstellt das Startfeld.
    public StartSpace()
    {
        Name = "START";
    }

    //Gibt dem Spieler beim Überqueren von START einen Bonus.
    public override string ExecuteAction(Player player)
    {
        decimal gewinn = player.Money / 3;
        player.MoneyChanges(gewinn);
        return $"{player.Name} ist die {player.Lap}. Runde durchgelaufen und erhält einen Bonus {gewinn:F2} €";
    }
}
