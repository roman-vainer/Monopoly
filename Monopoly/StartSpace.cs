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
        return
            $"\n=== STARTBONUS ===\n\n" +
            $"{player.Name} hat die {player.Lap}. Runde abgeschlossen.\n" +
            $"{player.Name} erhält einen Bonus von {gewinn:F2} €.\n" +
            $"Restguthaben: {player.Money:F2} €.";
    }
}
