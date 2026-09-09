namespace Monopoly;

public class Dice
{
    public int CurrentValue { get; set; }
    public int Roll()
    {
        CurrentValue = Random.Shared.Next(1, 7);
        return CurrentValue;
    }
}
