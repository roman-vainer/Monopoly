using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Monopoly; 
public class Board {
    List<Space> spaces ;

    public Board()
    {
        spaces = new List<Space>()
        {
            new StartSpace(),
            new MoneySpace(),
            new PropertySpace(2, 1000m, 100m, null),
            new EventSpace(),
            
        };

    }
}
