using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class StartSpace : Space {
    public StartSpace()
    {
        Name = this.GetType().Name;
    }
    public override string ExecuteAction(Player player) {
        return "";

    }
}
