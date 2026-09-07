namespace Monopoly;

public class Event
{
    public static string TriggerRandomEvent(Player player)
    {
        return new Random().Next(1, 7) switch
        {
            1 => ExecuteGoldGains(player),
            2 => ExecuteTaxLoss(player),
            3 => ExecuteMoveForward(player),
            4 => ExecuteMoveBackward(player),
            5 => ExecuteSkipTurn(player),
            6 => ExecuteDeath(player),
            _ => "No event triggered."
        };
    }
    private static string ExecuteGoldGains(Player player)
    {
        decimal money = player.Money / 3;
        player.MoneyChanges(money);
        return $"\n===Goldgewinn===\n: {player.Name} gewinnt {money:F2} €!";
    }

    private static string ExecuteTaxLoss(Player player)
    {
        decimal taxLoss = player.Money / 3;
        decimal money = player.MoneyChanges(-taxLoss);
        if (money == 0)
        {
            return $"\n===Steuerzahlung===\n{player.Name} muss {taxLoss:F2} € zahlen.\nNicht genug Geld! {player.Name} ist Bankrott";
        }
        else
        {
            return $"===Steuerzahlung===\n{player.Name} zahlt {taxLoss:F2} € Steuern";
        }
    }
    private static string ExecuteMoveForward(Player player)
    {
        string message = $"\n===Vorwärtsbewegung===\n";
        int steps = new Random().Next(1, 6);
        for (int i = 0; i < steps; i++)
        {
            player.Move(1);
        }
        message += $"{player.Name} ist {steps} vorwärts gegangen!";
        return message ;
    }

    private static string ExecuteMoveBackward(Player player)
    {
        string message = $"\n===Vorwärtsbewegung===\n";
        int steps = new Random().Next(1, 6);
        for (int i = 0; i < steps; i++)
        {
            player.Move(-1);
        }
        message += $"{player.Name} ist {steps} rückwärts gegangen!";
        return message;
    }

    private static string ExecuteSkipTurn(Player player)
    {
        player.SkipTurn = true;
        return $"\n===Runde Aussetzen===\n{player.Name} setzt einen Zug aus!";
    }

    private static string ExecuteDeath(Player player)
    {
        player.MoneyChanges(-player.Money);
        return $"\n===Getötet===\n{player.Name} wurde von der Konkurrenz liquidiert!";
    }
}
