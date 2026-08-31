using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly;

public class PropertySpace : Space {

    public decimal Price { get; set; }
    public decimal RentPrice { get; set; }
    public Player? Owner { get; set; }

    public PropertySpace(int position, decimal price, decimal rentPrice, Player? owner)
    {
        Position = position;
        Price = price;
        RentPrice = rentPrice;
        Owner = owner;
    }
    public override void ExecuteAction(Player player) {
    }
}
