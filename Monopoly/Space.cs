using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly; 
public abstract class Space {
    public string Name { get; set; }
    public int Position { get; set; }

    protected Space(string name, int position)
    {
        Name = name;
        Position = position;
    }

    public abstract string ExecuteAction(Player player);

    public virtual void OnLand(Player player, Dice dice)
    {
        
    }
}
