using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Monopoly;

public class StartSpace : Space
{

    public int Round { get; set; } = 0;
    public int Amount { get; set; }
    public string? RoundSwitch { get; set; }

    public StartSpace(){
        Name = this.GetType().Name;
    }

    public override string ExecuteAction(Player player)
    {
        Round++;
        Amount = 1000 / 4;
        var message = RoundSwap(player, Amount);
        player.MoneyChanges((decimal)Amount);
        return message;
    }

    public string RoundSwap(Player player, decimal amount)
    {
        Amount = 1000 / 4;
        RoundSwitch = Round switch
        {
            1 => "Erste",
            2 => "Zweite",
            3 => "Dritte",
            _ => "Unbekannt"
        };

        return RoundSwitch switch
        {
            "Erste" => $"{player.Name} hat die Startposition passiert und erhält {Amount}",
            "Zweite" => $"{player.Name} hat die Startposition erreicht und erhält {Amount}",
            "Dritte" => $"{player.Name} hat die Startposition erreicht und erhält {Amount}",
            _ => $"{player.Name} hat die Startposition erreicht"
        };
    }
}
        


