namespace Monopoly;

public class EstateSpace : Space
{
    private readonly string[] names = ["House", "Villa", "Plaza", "Tower", "Palace", "Castle", "Hotel"];
    public decimal Price { get; }
    public decimal RentPrice { get; }
    public Player? Owner { get; set; }

    //Erstellt eine Immobilie mit zufälligem Namen und Preis.
    public EstateSpace()
    {
        Name = names[Random.Shared.Next(names.Length)];
        Price = Random.Shared.Next(1, 6) * 100;
        RentPrice = Price / 2;
    }

    //Führt den Kauf oder die Mietzahlung für die Immobilie aus.
    public override string ExecuteAction(Player player)
    {
        string message =
            $"\n=== IMMOBILIE ===\n\n";

        if (Owner == null)
        {
            if (player.Money >= Price)
            {
                player.MoneyChanges(-Price);
                Owner = player;
                player.Estate.Add(this);
                message +=
                    $"{player.Name} hat die Immobilie für {Price:F2} € gekauft.\n" +
                    $"{player.Name} ist jetzt der Besitzer und erhält Miete von anderen Spielern.";
            }
            else
            {
                message +=
                    $"Die Immobilie kostet {Price:F2} €.\n" +
                    $"Das Guthaben von {player.Name} reicht für den Kauf nicht aus.";
            }
        }
        else
        {
            if (Owner != player)
            {
                message += $"Der Besitzer ist {Owner.Name}, daher musst du {RentPrice} € Miete zahlen.";
                decimal payment = Math.Min(RentPrice, player.Money);
                player.MoneyChanges(-RentPrice);
                Owner.MoneyChanges(payment);
                if (!player.IsActive)
                {
                    message +=
                        $"\nDas Guthaben von {player.Name} reicht nicht aus.\n" +
                        $"{player.Name} ist bankrott und scheidet aus dem Spiel aus.";
                }
            }
            else
            {
                message += $"{player.Name} ist bereits der Besitzer dieser Immobilie.";

            }
        }
        return message;
    }
}
