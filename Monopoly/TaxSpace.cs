namespace Monopoly;

public class TaxSpace : Space
{
    public int Amount { get; }

    public TaxSpace()
    {
        Amount = - new Random().Next(1, 4) * 100;
        Name = "Tax";
    }

    public override string ExecuteAction(Player player)
    {
            player.MoneyChanges(Amount);
            return $"{player.Name} Der Spieler landet auf einem Tax-Feld und zahlt {Amount} €";
    }
}

