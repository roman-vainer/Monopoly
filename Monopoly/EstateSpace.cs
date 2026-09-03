using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class EstateSpace : Space {
    public decimal Price { get; set; }
    
    public EstateSpace() { 
    Name = this.GetType().Name;
        Price = new Random().Next(1, 6) * 100;     
    }
    public override string ExecuteAction(Player player) {
        return "";
    }
}
