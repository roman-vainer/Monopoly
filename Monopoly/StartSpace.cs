using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class StartSpace : Space {

    public int Round { get; set; } = 0;

    public int BoardSize { get; set; }


    public override string ExecuteAction(Player player) {
        Random random = new Random();

        if (random.Next(50) == 0 && Round >= 2)
        {
            player.IstAktiv = false;
            return $"{player.Name} wurde getötet";
        }


            switch (Round)
        {
            case 1:
                player.MoneyChanges(200);
                Round++;
                return $"{player.Name} hat die Startposition erreicht und erhält 200 Punkte";
            case 2:
                player.MoneyChanges(400);
                Round++;
                return $"{player.Name} hat die Startposition erreicht und erhält 400 Punkte";
            case 3:
                player.MoneyChanges(600);
                Round++;
                return $"{player.Name} hat die Startposition erreicht und erhält 600 Punkte";
            case >= 4:
                return $"{player.Name} hat die Spiel erreicht";
        }

    }
}
