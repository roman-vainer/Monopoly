using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class Event
{

    public static string TriggerRandomEvent(Player player)
    {
        //switch (new Random().Next(1, 6))
        //{
        //     case 1:
        //       return ExecuteGoldGains(player);
        //    break;
        //    case 2:
        //    return ExecuteTaxLoss(player);
        //    break;
        //case 3:
        //    return ExecuteMoveForward(player);
        //    break;
        //case 4:
        //    return ExecuteMoveBackward(player);
        //    break;
        //case 5:
        //    return ExecuteSkipTurn(player);
        //    break;
        //case 6:
        //    return ExecuteNothingHappens(player);
        //    break;
        //default:
        //    Console.WriteLine("No event triggered.");
        //    break;
        //}
        return new Random().Next(1, 7) switch
        {
            1 => ExecuteGoldGains(player),
            2 => ExecuteTaxLoss(player),
            3 => ExecuteMoveForward(player),
            4 => ExecuteMoveBackward(player),
            5 => ExecuteSkipTurn(player),
            6 => ExecuteNothingHappens(player),
            7 => ExecuteDeath(player),
            _ => "No event triggered."
        };
    }
    private static string ExecuteGoldGains(Player player)
    {
        decimal goldGained = 200m;
        player.MoneyChanges(goldGained);
        return $"{player.Name} hat {goldGained} Gold erhalten!";
    }


    private static string ExecuteTaxLoss(Player player)
    {
        decimal taxLoss = 100m;
        decimal money = player.MoneyChanges(-taxLoss);
        if (money <= 0)
        {
            return $"{player.Name} ist Bankrott gegangen!";
        }
        else
        {
            player.MoneyChanges(-taxLoss);
            return $"{player.Name} hat {taxLoss} Gold verloren!";
        }
    }
    private static string ExecuteMoveForward(Player player)
    {
        int spaces = 3;
        player.GoTo(spaces);
        return $"{player.Name} ist {spaces} vorwärts gegangen!";
    }
    private static string ExecuteMoveBackward(Player player)
    {
        int spaces = 2;
        player.GoTo(-spaces);
        return $"{player.Name} ist {spaces} rückwärts gegangen!";
    }
    private static string ExecuteSkipTurn(Player player)
    {
        return $"{player.Name} setzt einen Zug aus!";
    }

    private static string ExecuteDeath(Player player)
    {
        player.IstAktiv = false;
        return $"{player.Name} ist gestorben und aus dem Spiel ausgeschieden!";
    }
    private static string ExecuteNothingHappens(Player player)
    {
        return $"{player.Name} ist auf ein Ereignisloses Feld getreten....";
    }
}
