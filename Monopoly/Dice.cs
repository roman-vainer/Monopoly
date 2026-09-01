using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public class Dice {
    public int Roll() {
        
        return new Random().Next(7);
    }
}
