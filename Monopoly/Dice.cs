namespace Monopoly;

public class Dice
{
    public int CurrentValue { get; private set; }
    public int Roll()
    {
        CurrentValue = new Random().Next(1, 20);
        return CurrentValue;
    }
}
