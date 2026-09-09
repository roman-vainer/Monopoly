namespace Monopoly;

public class Dice
{
    public int CurrentValue { get; set; }

    //Würfelt eine zufällige Zahl von 1 bis 6.
    public int Roll()
    {
        CurrentValue = Random.Shared.Next(1, 7);
        return CurrentValue;
    }
}
