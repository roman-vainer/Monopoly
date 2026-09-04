using Spectre.Console;
namespace Monopoly;

public class Game
{
    public int Size { get; }
    public List<Player> players;
    private Board board;
    private Dice dice;
    private Player currentPlayer;
    private static readonly Color[] colors = [Color.Red, Color.Yellow, Color.Green, Color.Blue];
    private string resultMessage = "";
    private readonly SpectreUI ui;

    public Game(List<Player> players, int size)
    {
        this.players = players;
        Size = size;
        dice = new Dice();
        board = new Board(size);
        Initialization();
        ui = new SpectreUI(board, players);

    }

    private void Initialization()
    {
        currentPlayer = players[new Random().Next(players.Count)];
        for (int i = 0; i < players.Count; i++)
        {
            players[i].PlayerColor = colors[i];
            players[i].Token = i switch
            {
                0 => "🔴",
                1 => "🟡",
                2 => "🟢",
                3 => "🔵",
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    public void Start()
    {
        ui.StartLive(() =>
        {
            RefreshGame();
            while (!IsEnd())
            {
                PlayTurn();
                ChangePosition();
            }
        });

        Player player = DetermineWinner();
        DrawFinalState(player);
    }

    private void DrawFinalState(Player player)
    {
        ui.DrawFinalState(player);
    }

    private Player DetermineWinner()
    {
        Player player = null;
        decimal money = 0;
        foreach (Player currentPlayer in players)
        {
            if (currentPlayer.IsActive && currentPlayer.Money > money)
            {
                money = currentPlayer.Money;
                player = currentPlayer;
            }
        }
        return player;
    }

    public void PlayTurn()
    {
        Console.ReadKey();
        int steps = dice.Roll();
        resultMessage = $"{currentPlayer.Name} würfelt {steps}.";
        RefreshGame();
        Thread.Sleep(2000);

        for (int i = 0; i < steps; i++)
        {
            currentPlayer.Move(1);
            RefreshGame();
            Thread.Sleep(300);
        }
        resultMessage = board.Spaces[currentPlayer.Position].ExecuteAction(currentPlayer);
        RefreshGame();
    }

    private void ChangePosition()
    {
        int currentIndex = players.IndexOf(currentPlayer);
        currentPlayer = players[(currentIndex + 1) % players.Count];
        resultMessage = $"Current Player is now {currentPlayer.Token} - {currentPlayer.Name}";
    }

    public bool IsEnd()
    {
        int activePlayers = players.Count(p => p.IsActive);
        var allLaps = players.FirstOrDefault(p => p.Lap >= 3);
        if (activePlayers <= 1 || allLaps != null)
        {
            return true;
        }
        return false;
    }

    public void RefreshGame()
    {
        ui.DrawGame(resultMessage, dice.CurrentValue, currentPlayer);
    }
}
