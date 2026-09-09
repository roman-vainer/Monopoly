namespace Monopoly;

public class EventSpace : Space
{
    //Erstellt ein Ereignisfeld.
    public EventSpace()
    {
        Name = "EVENT";
    }

    //Löst ein zufälliges Ereignis für den Spieler aus.
    public override string ExecuteAction(Player player)
    {
        string resultMessage = $"Der Spieler {player.Name} landet auf einem Zufallsereignisfeld";
        resultMessage += Event.TriggerRandomEvent(player);
        return resultMessage;
    }
}
