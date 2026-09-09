namespace Monopoly;

public class Board
{
    private readonly int size;
    public List<Space> Spaces { get; }

    //Erstellt das Spielfeld mit der angegebenen Größe.
    public Board(int size)
    {
        this.size = size;
        Spaces = CreateSpaces();
    }

    //Erstellt und mischt die verschiedenen Spielfelder.
    private List<Space> CreateSpaces()
    {
        var spaces = new List<Space>();
        for (int i = 0; i < size - 1; i++)
        {
            spaces.Add(Random.Shared.Next(1, 5) switch
            {
                1 => new EventSpace(),
                2 => new MoneySpace(),
                3 => new EstateSpace(),
                4 => new TaxSpace(),
                _ => throw new Exception()
            });
        }
        spaces = spaces.Shuffle().ToList();
        spaces.Insert(0, new StartSpace());
        return spaces;
    }
}