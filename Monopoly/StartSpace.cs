using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class StartSpace : Space
{

    public int Round { get; set; } = 0;
    public static int CurrentRound { get; set; }

    public StartSpace()
    {
        Name = this.GetType().Name;
    }

    public override string ExecuteAction(Player player)
    {
        int position = player.Position;
        int size = Player.Size;

        if (position < size && position != 0)
        {
            CurrentRound = 1;
            player.MoneyChanges(200);
            return $"{player.Name} hat die Startposition erreicht und erhält 200 €";
        }
        else if (position < size * 2 && position > size)
        {
            CurrentRound = 2;
            player.MoneyChanges(400);
            return $"{player.Name} hat die Startposition erreicht und erhält 400 €";
        }
        else if (position < size * 3 && position > size * 2)
        {
            CurrentRound = 3;
            player.MoneyChanges(600);
            return $"{player.Name} hat die Startposition erreicht und erhält 600 €";
        }
        else if (position < size * 4 && position > size * 3)
        {
            CurrentRound = -1;
            return $"{player.Name} hat das Game beendet und hat {player.Money} € Geld";
        }

        return "Ungültige Runde";

        //switch (CurrentRound)
        //{
        //    case 0:
        //        return $"{player.Name} hat die Startposition erreicht";

        //    case 1:
        //        player.MoneyChanges(200);
        //        return $"{player.Name} hat die Startposition erreicht und erhält 200 €";

        //    case 2:
        //        player.MoneyChanges(400);
        //        return $"{player.Name} hat die Startposition erreicht und erhält 400 €";

        //    case 3:
        //        player.MoneyChanges(600);
        //        return $"{player.Name} hat die Startposition erreicht und erhält 600 €";

        //    default:
        //        return "Ungültige Runde";
        //}

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
