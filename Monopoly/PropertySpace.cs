using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class PropertySpace : Space {
    public PropertySpace()
    {
        Name = this.GetType().Name;
    }
    public override string ExecuteAction(Player player) {
        return "";
    }
}
