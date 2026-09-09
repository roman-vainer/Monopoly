namespace Monopoly; 

public interface IUserInterface {

    //Aktualisiert die aktuelle Spielanzeige.
    public void DrawGame(string message, int diceValue, Player player);

    //Zeigt den Endzustand und den Gewinner an.
    public void DrawFinalState(Player winner);

    //Startet die dynamische Konsolenanzeige.
    public void StartLive(Action gameAction);

    //Zeigt das Ergebnis einer Spielaktion an.
    public void ShowResult(string message);
}
 