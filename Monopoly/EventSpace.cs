using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class EventSpace : Space {
    public EventSpace(string name,int position ) : base(name, position)
    {
        Name = this.GetType().Name;
    }
    public override string ExecuteAction(Player player) {
     
        return Event.TriggerRandomEvent(player);
    }
}
