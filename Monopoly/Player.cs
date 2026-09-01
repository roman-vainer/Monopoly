using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

    

namespace Monopoly;

public class Player {
    public string Name { get; set; }
    public decimal Money { get; set; }
    public int Punkte { get; set; }
    public bool IstAktiv { get; set; }
    public int Position { get; set; }
    public List<PropertySpace> Estate { get; }
    public Color PlayerColor { get; set; }
    private int size;

    public Player(string name, int size) {
        Name = name;
        Money = 1000m;
        Punkte = 0;
        IstAktiv = true;
        Position = 0;
        this.size = size;
        Estate = new List<PropertySpace>();

    }
    public int GoTo(int steps) {
        return Position = (Position + steps) % size;

    }
    public decimal MoneyChanges (decimal amount)
    {
        if (Money + amount <0)
        {
            IstAktiv = false;
            Money = 0;
            return Money;
        }
        else
        {
            Money += amount;
            return Money;
        }
    }
}
