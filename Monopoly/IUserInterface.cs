using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public interface IUserInterface {
    public void DisplayMessage(string message);

    public void DrawGame(Board board, List<Player> players, string message, int diceValue);
}
