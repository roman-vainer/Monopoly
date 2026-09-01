using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class MoneySpace : Space {
    public decimal Amount { get; set; } = 100;
    public override string ExecuteAction(Player player) {
        return "";
    }
}
