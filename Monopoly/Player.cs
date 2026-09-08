using Spectre.Console;

namespace Monopoly;

public class Player
{
    public string Name { get; }
    public List<EstateSpace> Estate { get; }
    public decimal Money { get; private set; }
    public bool IsActive { get; private set; }
    public int Position { get; private set; }
    public int Lap { get; private set; }
    public Color PlayerColor { get; set; }
    public string Token { get; set; }
    public bool SkipTurn { get; set; }
    public static int BoardSize { get; set; }

    public Player(string name)
    {
        Name = name;
        Money = 1000m;
        IsActive = true;
        Position = 0;
        SkipTurn = false;
        Lap = 1;
        Estate = new List<EstateSpace>();
        Token = "";
    }

    public void Move(int direction)
    {
        Position += direction;
        if (Position >= BoardSize)
        {
            Position = 0;
            Lap++;
        }
        if (Position < 0)
        {
            if (Lap == 0)
            {
                Position = 0;
            }
            else
            {
                Position = BoardSize - 1;
                Lap--;
            }
        }
    }

    public void MoneyChanges(decimal amount)
    {
        if (Money + amount <= 0)
        {
            MakeBankrupt();
        }
        else
        {
            Money += amount;
        }
    }

    private void MakeBankrupt()
    {
        IsActive = false;
        Money = 0;
        Token = "";
        foreach (var estate in Estate)
        {
            estate.Owner = null;
        }
        Estate.Clear();
        Position = 0;
        Lap = 0;
    }
}
