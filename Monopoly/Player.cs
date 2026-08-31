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

    public Player(string name, decimal money, int punkte, bool istAktiv, int position) {
        Name = name;
        Money = money;
        Punkte = punkte;
        IstAktiv = istAktiv;
        Position = position;
    }
}
