namespace Monopoly;

public class TaxSpace : Space
{
    public int Amount { get; }

    //Erstellt ein Steuerfeld mit einem zufälligen Betrag.
    public TaxSpace()
    {
        Amount = Random.Shared.Next(1, 4) * 100;
        Name = "Tax";
    }

    //Zieht dem Spieler den Steuerbetrag ab.
    public override string ExecuteAction(Player player)
    {
        if (player.Money < Amount)
        {
            player.MoneyChanges(-Amount);
            return
            $"\n=== STEUERZAHLUNG ===\n\n" +
            $"{player.Name} muss {Amount:F2} € Steuern zahlen.\n" +
            $"Das Guthaben reicht nicht aus.\n" +
            $"{player.Name} ist bankrott und scheidet aus dem Spiel aus.";
        }
        player.MoneyChanges(-Amount);
        return
            $"\n=== STEUERZAHLUNG ===\n\n" +
            $"{player.Name} muss {Amount:F2} € Steuern zahlen.\n" +
            $" Restguthaben: {player.Money:F2} €";
    }
}

