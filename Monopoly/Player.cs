using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

    

namespace Monopoly;

public class Player {
    public string Name { get; set; }
    public decimal Money { get; set; }
    //Prüft ob ein Spieler noch aktiv ist, wenn er pleite ist, wird er inaktiv
    public bool IsActive { get; set; }
    public int Position { get; set; }
    // Anzahl der aufeinanderfolgenden Male, die der Spieler das Startfeld passiert hat
    public int StartPassStreak { get; set; }
    public List<EstateSpace> Estate { get; }
    public Color PlayerColor { get; set; }
    public static int Size { get; set; }

    public Player(string name) {
        Name = name;
        Money = 1000m;
        IsActive = true;
        Position = 0;
        StartPassStreak = 0;

        Estate = new List<EstateSpace>();
    }
    public int GoTo(int steps) {
        return Position = (Position + steps) % Size;

    }
    public decimal MoneyChanges (decimal amount)
    {
        if (Money + amount <0)
        {
            IsActive = false;
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
  
