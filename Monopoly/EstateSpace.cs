namespace Monopoly;

public class EstateSpace : Space
{
    private readonly string[] names = ["House", "Villa", "Plaza", "Tower", "Palace", "Castle", "Hotel"];
    public decimal Price { get; }
    public decimal RentPrice { get; }
    public Player? Owner { get; set; }

    public EstateSpace()
    {
        Name = names[Random.Shared.Next(names.Length)];
        Price = Random.Shared.Next(1, 6) * 100;
        RentPrice = Price / 2;
    }
    public override string ExecuteAction(Player player)
    {
        string message = $"\nDu bist auf der Immobilie {Name} gelandet.\n";
        if (Owner == null)
        {
            if (player.Money >= Price)
            {
                player.MoneyChanges(-Price);
                Owner = player;
                player.Estate.Add(this);
                message += $"Du hast sie für {Price} € gekauft.\n" +
                    $"Du bist jetzt der Besitzer und erhältst Miete von anderen spielern";
            }
            else
            {
                message += $"Kannst du aber sie nicht kaufen, weil du nicht genug Geld hast.";
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
                    message += $"{player.Name}\nist jetzt bankrott und scheidest aus dem Spiel aus";
                }
            }
            else
            {
                message += "Du bist bereits der Besitzer";
            }
        }
        return message;
    }
}
