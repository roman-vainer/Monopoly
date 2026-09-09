namespace Monopoly;

public abstract class Space
{
    public string? Name { get; protected set; }

    //Führt die jeweilige Aktion des Spielfeldes aus.
    public abstract string ExecuteAction(Player player);

}
