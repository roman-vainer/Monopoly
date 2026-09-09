using Spectre.Console;
namespace Monopoly;

public class Game
{
    private List<Player> players;
    private readonly Board board;
    private Dice dice;
    private static readonly Color[] colors = [Color.Red, Color.Yellow, Color.Green, Color.Blue];
    private Player currentPlayer;
    private string resultMessage = "";
    private readonly IUserInterface ui;

    //Erstellt und initialisiert ein neues Spiel.
    public Game(List<Player> players, int size)
    {
        this.players = players;
        dice = new Dice();
        board = new Board(size);
        ui = new SpectreUI(board, players);
        Initialization();

    }

    //Initialisiert den Startspieler, die Farben und die Spielfiguren.
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

    //Startet das Spiel und führt die Spielrunden aus.
    public void Start()
    {
        ui.StartLive(() =>
        {
            resultMessage =
                $"Jetzt ist {currentPlayer.Token} {currentPlayer.Name} am Zug.\n" +
                $"\nZum Würfeln beliebige Taste drücken...";
            RefreshGame();
            while (!IsEnd())
            {
                PlayTurn();
                if (!IsEnd())
                {
                    NextPlayer();
                }
            }
        });

        Player player = DetermineWinner();
        DrawFinalState(player);
    }

    //Führt einen vollständigen Spielzug aus.
    private void PlayTurn()
    {
        Console.ReadKey(true);
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
                Thread.Sleep(1000);
                resultMessage = board.Spaces[currentPlayer.Position].ExecuteAction(currentPlayer);
            }
        }
        int endPosition = currentPlayer.Position;
        resultMessage = board.Spaces[endPosition].ExecuteAction(currentPlayer);
        ui.ShowResult(resultMessage);
        while (endPosition != currentPlayer.Position && currentPlayer.Position != 0)
        {
            endPosition = currentPlayer.Position;
            Thread.Sleep(2000);
            resultMessage = board.Spaces[currentPlayer.Position].ExecuteAction(currentPlayer);
            ui.ShowResult(resultMessage);
        }
    }

    //Wechselt zum nächsten aktiven Spieler.
    private void NextPlayer()
    {
        int currentIndex = players.IndexOf(currentPlayer);

        do
        {
            currentIndex = (currentIndex + 1) % players.Count;
            currentPlayer = players[currentIndex];
            dice.CurrentValue = 0;

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

        resultMessage = $"Jetzt ist {currentPlayer.Token} {currentPlayer.Name} am Zug.\n" +
            $"Zum Würfeln beliebige Taste drücken...";
        RefreshGame();
    }

    //Prüft, ob das Spiel beendet ist.
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

    //Ermittelt den Gewinner des Spiels.
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

    //Aktualisiert die aktuelle Spielanzeige.
    private void RefreshGame()
    {
        ui.DrawGame(resultMessage, dice.CurrentValue, currentPlayer);
    }

    //Zeigt den Endzustand des Spiels an.
    private void DrawFinalState(Player player)
    {
        ui.DrawFinalState(player);
    }
}
