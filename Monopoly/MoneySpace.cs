namespace Monopoly;

public class MoneySpace : Space
{
    public int Amount { get; private set; }

    public MoneySpace()
    {
        Amount = new Random().Next(1, 4) * 100;
        Name = "money";
    }

    public override string ExecuteAction(Player player)
    {
        int position = player.Position;
        if (position % 2 == 0)
        {
            player.MoneyChanges(Amount);
            return $"{player.Name} befindet sich auf einem geraden Feld und erhält {Amount}.";
        }
        else
        {
            player.MoneyChanges(-Amount);
            return $"{player.Name} befindet sich auf einem ungeraden Feld und zahlt {Amount}!";
        }
    }
}



