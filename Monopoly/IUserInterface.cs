using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public interface IUserInterface {
    public void DisplayMessage(string message);

    public void DrawGame(string message, int diceValue, Player player);
}
