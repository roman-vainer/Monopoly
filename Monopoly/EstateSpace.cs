namespace Monopoly;

public class EstateSpace : Space
{
    private readonly string[] names = ["House", "Villa", "Plaza", "Tower", "Palace", "Castle", "Hotel"];
    public decimal Price { get; }
    public decimal RentPrice { get; }
    Player? owner;

    public EstateSpace()
    {
        Name = names[new Random().Next(names.Length)];
        Price = new Random().Next(1, 6) * 100;
        RentPrice = Price / 2;
    }
    public override string ExecuteAction(Player player)
    {
        string message = $"Du bist auf der Immobilie {Name} gelandet.\n";
        if (owner == null)
        {
            if (player.Money >= Price)
            {
                player.MoneyChanges(-Price);
                owner = player;
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
            if (owner != player)
            {
                player.MoneyChanges(-RentPrice);
                message += $"Der Besitzer ist {owner}, daher musst du {RentPrice} € Miete zahlen." +
                    $"{(!player.IsActive ? "\nDu bist jetzt bankrott und scheidest aus dem Spiel aus" : "")}";
            }
            else
            {
                message += "Du bist bereits der Besitzer";
            }
        }
        return message;
    }
}
