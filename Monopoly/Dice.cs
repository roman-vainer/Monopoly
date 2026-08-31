using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public class Dice {
    public int DiceNumber { get; set; }

    public int RollDice()
    {
        Random random = new Random();
        DiceNumber = random.Next(1, 7);
        return DiceNumber;
    }
}
