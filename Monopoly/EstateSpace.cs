using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class EstateSpace : Space {
    public decimal Prise { get; set; }
    
    public EstateSpace() { 
    Name = this.GetType().Name;
        Prise = new Random().Next(1, 6) * 100;     
    }
    public override string ExecuteAction(Player player) {
        return "";
    }
}
