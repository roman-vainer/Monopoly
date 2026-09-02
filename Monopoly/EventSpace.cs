using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class EventSpace : Space {
    public EventSpace()
    {
        Name = this.GetType().Name;
    }
    public override string ExecuteAction(Player player) {
     
        return Event.TriggerRandomEvent(player);
    }
}
