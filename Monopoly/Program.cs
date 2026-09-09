namespace Monopoly;

internal class Program
{

    //Erstellt die Spieler und startet das Spiel.
    static void Main(string[] args)
    {
        int size = 28;
        Player.BoardSize = size;
        List<Player> players = CreatePlayers();
        Game game = new Game(players, size);
        game.Start();
    }

    //Erstellt die angegebene Anzahl von Spielern.
    private static List<Player> CreatePlayers()
    {
        int playerCount;
        do
        {
            Console.WriteLine("Geben Sie die Anzahl der Spieler ein (2-4): ");
        }
        while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount < 2 || playerCount > 4);

        List<Player> players = new List<Player>();

        for (int i = 0; i < playerCount; i++)
        {
            Console.Write($"Geben Sie den Namen der {i + 1}. Spielers ein: ");
            players.Add(new Player(Console.ReadLine()!));
        }
        return players;
    }
}
