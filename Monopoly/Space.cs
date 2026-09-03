using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public abstract class Space {
    public string? Name { get; protected set; }

    public abstract string ExecuteAction(Player player);

}
