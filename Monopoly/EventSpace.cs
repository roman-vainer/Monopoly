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
        string resultMessage = 
            $"\n=== ZUFÄLLIGES EREIGNIS ===\n\n" +
            $"{player.Name} landet auf einem Ereignisfeld.";
        resultMessage += Event.TriggerRandomEvent(player);
        return resultMessage;
    }
}
