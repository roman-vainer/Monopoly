namespace Monopoly;

public class MoneySpace : Space
{
    public int Amount { get; }

    public MoneySpace()
    {
        Amount = Random.Shared.Next(1, 4) * 100;
        Name = "Money";
    }

    public override string ExecuteAction(Player player)
    {
        player.MoneyChanges(Amount);
        return $"{player.Name} Der Spieler landet auf einem Money-Feld und erhält {Amount} €";
    }
}



