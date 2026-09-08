namespace Monopoly;

internal class Program
{
    static void Main(string[] args)
    {
        int size = 28;
        int playerCount = 4; ;
        Player.BoardSize = size;
        List<Player> players = CreatePlayers(playerCount);
        Game game = new Game(players, size);
        game.Start();
    }

    private static List<Player> CreatePlayers(int playerCount)
    {
        var players = new List<Player>();
        for (int i = 0; i < playerCount; i++)
        {
            Console.WriteLine($"Geben Sie den Namen der {i + 1}. Spielers ein");
            players.Add(new Player(Console.ReadLine()!));
        }
        return players;
    }
}
