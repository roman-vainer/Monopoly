namespace Monopoly;

public class Dice
{
    public int CurrentValue { get; private set; }
    public int Roll()
    {
        CurrentValue = Random.Shared.Next(1, 7);
        return CurrentValue;
    }
}
