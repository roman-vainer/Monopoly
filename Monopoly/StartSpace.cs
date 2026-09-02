using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class StartSpace : Space
{

    public int Round { get; set; } = 0;

    public string? RoundSwitch { get; set; }

    public StartSpace(){
        Name = this.GetType().Name;
    }

    public override string ExecuteAction(Player player)
    {

        RoundSwitch = Round switch
        {
            1 => "First",
            2 => "Second",
            3 => "Third",
            _ => "Unknown"
        };

        return RoundSwitch switch
        {
            "First" => $"{player.Name} hat die Startposition erreicht und erhält 200 Punkte",
            "Second" => $"{player.Name} hat die Startposition erreicht und erhält 400 Punkte",
            "Third" => $"{player.Name} hat die Startposition erreicht und erhält 600 Punkte",
            _ => $"{player.Name} hat die Startposition erreicht"
        };
    }
}
