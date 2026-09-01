namespace Monopoly {
    internal class Program {
        static void Main(string[] args) {
            for (int i = 0; i < 20; i++) {
                Console.WriteLine($"{new Random().Next(7)}");
            }
            //    int size = 28;
            //    List<Player> players = CreatePlayers();
            //    Game game = new Game(players, size);
            //    game.Start();

            //}

            //private static List<Player> CreatePlayers() {
            //    return new List<Player>();
            //}
        }
    }
}
