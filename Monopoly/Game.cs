using Spectre.Console;
namespace Monopoly;

public class Game
{
    private List<Player> players;
    private readonly Board board;
    private readonly Dice dice;
    private static readonly Color[] colors = [Color.Red, Color.Yellow, Color.Green, Color.Blue];
    private Player currentPlayer;
    private string resultMessage = "";
    private readonly IUserInterface ui;

    public Game(List<Player> players, int size)
    {
        this.players = players;
        dice = new Dice();
        board = new Board(size);
        ui = new SpectreUI(board, players);
        Initialization();

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
            if(currentPlayer.Position == 0 && i != steps - 1)
            {
                Thread.Sleep(2000);
                resultMessage = board.Spaces[currentPlayer.Position].ExecuteAction(currentPlayer);
            }
        }
        int endPosition = currentPlayer.Position;
        resultMessage = board.Spaces[endPosition].ExecuteAction(currentPlayer);
        RefreshGame();
        if(endPosition != currentPlayer.Position)
        {
            Thread.Sleep(2000);
            resultMessage = board.Spaces[currentPlayer.Position].ExecuteAction(currentPlayer);
            RefreshGame();
        }
    }

    private void ChangePosition()
    {
        int currentIndex = players.IndexOf(currentPlayer);
        currentPlayer = players[(currentIndex + 1) % players.Count];
        if (!currentPlayer.IsActive)
        {
            currentIndex = players.IndexOf(currentPlayer);
            currentPlayer = players[(currentIndex + 1) % players.Count];
        }

        if (currentPlayer.SkipTurn)
        {
            currentPlayer.SkipTurn = false;
            currentIndex = players.IndexOf(currentPlayer);
            currentPlayer = players[(currentIndex + 1) % players.Count];
        }
        resultMessage = $"Current Player is now {currentPlayer.Token} - {currentPlayer.Name}";
    }

    private bool IsEnd()
    {
        int activePlayers = players.Count(p => p.IsActive);
        var allLaps = players.FirstOrDefault(p => p.Lap >= 3);
        if (activePlayers <= 1 || allLaps != null)
        {
            return true;
        }
        return false;
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
    private void RefreshGame()
    {
        ui.DrawGame(resultMessage, dice.CurrentValue, currentPlayer);
    }
    private void DrawFinalState(Player player)
    {
        ui.DrawFinalState(player);
    }
}
