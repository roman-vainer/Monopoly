using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public abstract class Space {
    public string Name { get; set; }
    public int Position { get; set; }

    public abstract string ExecuteAction(Player player);

}
