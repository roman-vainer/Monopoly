using System;

namespace Monopoly;

public class MoneySpace : Space
{
 
    public int Amount { get; private set; }

    public MoneySpace(string name, int position, int amount) : base(name, position)
    {
        Amount = amount;
        Name = this.GetType().Name;
    }

    public override string ExecuteAction(Player player)
    {
        int roll = Roll();
        if (roll % 2 == 0)
        {
            player.MoneyChanges(150);
            return $"{player.Name} hat eine {roll} gewürfelt und erhält 150.";
        }
        else
        {
            player.MoneyChanges(-100);
            return $"{player.Name} hat eine {roll} gewürfelt und zahlt 100!";
        }
    }

    public override void OnLand(Player player, Dice dice)
    {
        ExecuteAction(player);
    }
    public static int Roll()
    {
        return new Random().Next(1, 7);
    }
       

}
