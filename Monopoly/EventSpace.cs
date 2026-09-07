namespace Monopoly;

public class EventSpace : Space
{
    public EventSpace()
    {
        Name = "EVENT";
    }
    public override string ExecuteAction(Player player)
    {
        string resultMessage = $"Der Spieler {player.Name} landet auf einem Zufallsereignisfeld";
        resultMessage += Event.TriggerRandomEvent(player);
        return resultMessage;
    }
}
