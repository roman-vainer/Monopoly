using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public abstract class Space {
    public int Position { get; set; }


    public abstract void ExecuteAction(Player player);
}
