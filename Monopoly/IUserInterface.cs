namespace Monopoly; 

public interface IUserInterface {

    public void DrawGame(string message, int diceValue, Player player);
    public void DrawFinalState(Player winner);
    public void StartLive(Action gameAction);
}
 