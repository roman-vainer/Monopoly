using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;



namespace Monopoly;

public class Player {
    public string Name { get; set; }
    public decimal Money { get; private set; }
    public int Punkte { get; set; }
    public bool IstAktiv { get; set; }
    public int Position { get; private set; }
    public List<EstateSpace> Estate { get; }
    public Color PlayerColor { get; set; }
    public static int Size { get; set; }
    public int Lap { get; set; } = 0;

    public Player(string name) {
        Name = name;
        Money = 1000m;
        Punkte = 0;
        IstAktiv = true;
        Position = 0;

        Estate = new List<EstateSpace>();
    }
    public int GoTo(int steps) {
        if (Position + steps > Size) {
            Lap++;
        }
        return Position = (Position + steps) % Size;
    }

    public decimal MoneyChanges(decimal amount) {
        if (Money + amount < 0) {
            IstAktiv = false;
            Money = 0;
            return Money;
        } else {
            Money += amount;
            return Money;
        }
    }
}
