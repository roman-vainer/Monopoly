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
        currentPlayer = players[Random.Shared.Next(players.Count)];
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
            if (currentPlayer.Position == 0 && i != steps - 1)
            {
                Thread.Sleep(2000);
                resultMessage = board.Spaces[currentPlayer.Position].ExecuteAction(currentPlayer);
            }
        }
        int endPosition = currentPlayer.Position;
        resultMessage = board.Spaces[endPosition].ExecuteAction(currentPlayer);
        ui.ShowResult(resultMessage);
        //RefreshGame();
        if (endPosition != currentPlayer.Position)
        {
            Thread.Sleep(2000);
            resultMessage = board.Spaces[currentPlayer.Position].ExecuteAction(currentPlayer);
            ui.ShowResult(resultMessage);
        }
    }

    private void ChangePosition()
    {
        int currentIndex = players.IndexOf(currentPlayer);

        do
        {
            currentIndex = (currentIndex + 1) % players.Count;
            currentPlayer = players[currentIndex];

            if (currentPlayer.IsActive && currentPlayer.SkipTurn)
            {
                currentPlayer.SkipTurn = false;
                resultMessage = 
                    $"\n=== ZUG AUSSETZEN ===\n" +
                    $"{currentPlayer.Name} muss diesen Zug aussetzen.";
                RefreshGame();
                Thread.Sleep(2000);
                continue;
            }
            if (currentPlayer.IsActive)
            {
                break;
            }


        } while (true);

        resultMessage = $"Jetzt ist {currentPlayer.Token} {currentPlayer.Name} am Zug.";
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
