using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public static class Event {

    public static void TriggerRandomEvent(Player player)
    {
        switch (new Random().Next(1, 6))
        {
            case 1:
                ExecuteGoldGains(player);
                break;
            case 2:
                ExecuteTaxLoss(player);
                break;
            case 3:
                ExecuteMoveForward(player);
                break;
            case 4:
                ExecuteMoveBackward(player);
                break;
            case 5:
                ExecuteSkipTurn(player);
                break;
            default:
                Console.WriteLine("No event triggered.");
                break;
        }
    }
    private static void ExecuteGoldGains(Player player)
    {
        int goldGained = 200; 
        player.Money += goldGained;
        Console.WriteLine($"{player.Name} hat {goldGained} Gold erhalten!");
    }
    private static void ExecuteTaxLoss(Player player)
    {
        int taxLoss = 100; 
        player.Money -= taxLoss;
        Console.WriteLine($"{player.Name} hat {taxLoss} Gold verloren!");
    }
    private static void ExecuteMoveForward(Player player)
    {
        int spaces = 3; 
        player.Position += spaces;
        Console.WriteLine($"{player.Name} ist {spaces} vorwärts gegangen!");
    }
    private static void ExecuteMoveBackward(Player player)
    {
        int spaces = 2; 
        player.Position -= spaces;
        Console.WriteLine($"{player.Name} ist {spaces} rückwärts gegangen!");
    }
    private static void ExecuteSkipTurn(Player player)
    {
        Console.WriteLine($"{player.Name} setzt einen Zug aus!");
    }
}
