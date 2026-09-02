using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class StartSpace : Space
{

    public int Round { get; set; } = 0;

    public StartSpace(){
        Name = this.GetType().Name;
    }

    public override string ExecuteAction(Player player)
    {
        switch (Game.CurrentRound)
        {
            case 0:
                return $"{player.Name} hat die Startposition erreicht";

            case 1:
                player.MoneyChanges(200);
                return $"{player.Name} hat die Startposition erreicht und erhält 200 €";

            case 2:
                player.MoneyChanges(400);
                return $"{player.Name} hat die Startposition erreicht und erhält 400 €";

            case 3:
                player.MoneyChanges(600);
                return $"{player.Name} hat die Startposition erreicht und erhält 600 €";

            default:
                return "Ungültige Runde";
        }

        //RoundSwitch = Round switch
        //{
        //    1 => "First",
        //    2 => "Second",
        //    3 => "Third",
        //    _ => "Unknown"
        //};
        //Round++;
        //return RoundSwitch switch
        //{
        //    "First" => $"{player.Name} hat die Startposition erreicht und erhält 200 €",
        //    "Second" => $"{player.Name} hat die Startposition erreicht und erhält 400 €",
        //    "Third" => $"{player.Name} hat die Startposition erreicht und erhält 600 €",
        //    _ => $"{player.Name} hat die Startposition erreicht"
        //};
    }
}
