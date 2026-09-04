namespace Monopoly;

public class Dice
{
    public int CurrentValue { get; set; }
    public int Roll()
    {
        CurrentValue = new Random().Next(1, 7);
        return CurrentValue;
    }
}
