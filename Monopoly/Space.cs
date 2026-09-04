namespace Monopoly;

public abstract class Space
{
    public string? Name { get; protected set; }

    public abstract string ExecuteAction(Player player);

}
