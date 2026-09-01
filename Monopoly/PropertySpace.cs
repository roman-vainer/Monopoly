using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class PropertySpace : Space {
    public PropertySpace(string name, int position) : base(name, position)
    {
        Name = this.GetType().Name;
    }
    public override string ExecuteAction(Player player) {
        return "";
    }
}
