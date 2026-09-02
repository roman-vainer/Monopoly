namespace Monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int size = 28;
            Player.Size = size;
            List<Player> players = CreatePlayers();
            Game game = new Game(players, size);
            game.Start();
        }

        private static List<Player> CreatePlayers()
        {
            var players = new List<Player>();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Geben Sie den Namen der {i + 1}. Spielers ein");
                players.Add(new Player(Console.ReadLine()!));
            }
            return players;
        }
    }
}
