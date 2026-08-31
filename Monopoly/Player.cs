using System;
using System.Collections.Generic;
using System.Text;
    

namespace Monopoly;

public class Player {
    public string Name { get; set; }
    public decimal Money { get; set; }
    public int Punkte { get; set; }
    public bool IstAktiv { get; set; }
    public int Position { get; set; }
    public List<PropertySpace> Estate { get; }

    public Player(string name) {
        Name = name;
        Money = 1000m;
        Punkte = 0;
        IstAktiv = true;
        Position = 0;
        Estate = new List<PropertySpace>();
    }
}
