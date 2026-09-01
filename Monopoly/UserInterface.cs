using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly {
    internal class UserInterface : IUserInterface {
        public void DisplayMessage(string message) {
            Console.WriteLine(message);
        }

        public void DrawGame(Board board, List<Player> players, string message, int diceValue) {

        }
    }
}
