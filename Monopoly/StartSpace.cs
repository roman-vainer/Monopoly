using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class StartSpace : Space
{
    public StartSpace()
    {
        Name = "START";
    }

    public override string ExecuteAction(Player player)
    {
        int lap = player.Lap;
        decimal gewinn = player.Money / 3 * (lap + 1);

        player.MoneyChanges(gewinn);
        return $"{player.Name} ist die {lap}. Runde durchgelaufen und erhält {gewinn} €";
    }
}
