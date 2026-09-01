namespace Monopoly {
    internal class Program {
        static void Main(string[] args) {
            int size = 28;
            List<Player> players = CreatePlayers();
            Game game = new Game(players, size);
            game.Start();

        }

        private static List<Player> CreatePlayers()
        {
            return new List<Player>();
        }
    }
}
}