using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class MoneySpace : Space {
    public int moneyAmount = 200;

    public override void ExecuteAction(Player player)
    {
        // Erhöht das Geld des Spielers um den Betrag
        player.Money(moneyAmount);
    }
}
