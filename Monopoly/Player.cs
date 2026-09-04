using Spectre.Console;

namespace Monopoly;

public class Player
{
    public string Name { get; set; }
    public decimal Money { get; set; }
    public bool IsActive { get; set; }
    public int Position { get; private set; }
    public List<EstateSpace> Estate { get; }
    public Color PlayerColor { get; set; }
    public string Token { get; set; }
    public static int Size { get; set; }
    public int Lap { get; set; } = 0;
    public static int i = 0;

    public Player(string name)
    {
        Name = name;
        Money = 1000m;
        IsActive = true;
        Position = 0;
        Estate = new List<EstateSpace>();
    }

    public void Move(int direction)
    {
        Position += direction;
        if (Position >= Size)
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
                Position = Size - 1;
                Lap--;
            }
        }
    }

    public decimal MoneyChanges(decimal amount)
    {
        if (Money + amount < 0)
        {
            IsActive = false;
            Token = "";
            return Money;
        }
        else
        {
            Money += amount;
            return Money;
        }
    }
}
