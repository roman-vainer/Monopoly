namespace Monopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            List<Player> players = CreatePlayers();
            Game game = new Game(players);
            game.Start();

        }

        private static List<Player> CreatePlayers()
        {
            return new List<Player>();
        }
    }
}
}