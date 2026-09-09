namespace Monopoly;

public class MoneySpace : Space
{
    public int Amount { get; }

    //Erstellt ein Geldfeld mit einem zufälligen Betrag.
    public MoneySpace()
    {
        Amount = Random.Shared.Next(1, 4) * 100;
        Name = "Money";
    }

    //Gibt dem Spieler den Geldbonus des Feldes.
    public override string ExecuteAction(Player player)
    {
        player.MoneyChanges(Amount);
        return
            $"\n=== GELDGEWINN ===\n\n" +
            $"{player.Name} erhält {Amount:F2} €." +
            $"Restguthaben: {player.Money:F2} €.";
    }
}



