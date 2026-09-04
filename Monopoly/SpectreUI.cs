using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace Monopoly;

public class SpectreUI : IUserInterface
{
    private LiveDisplayContext? liveContext;
    private int side;
    private Board board;
    private List<Player> players;
    private string message;
    private int diceValue;
    Player currentPlayer;

    public SpectreUI(Board board, List<Player> players)
    {
        this.board = board;
        this.players = players;
        message = "";
        diceValue = 0;
    }

    public void DrawGame(string message, int diceValue, Player currentPlayer)
    {
        this.message = message;
        this.diceValue = diceValue;
        this.currentPlayer = currentPlayer;

        if (liveContext != null)
        {
            liveContext.UpdateTarget(CreateScreen());
            liveContext.Refresh();
        }
    }

    public void StartLive(Action gameAction)
    {
        Console.OutputEncoding = Encoding.UTF8;
        AnsiConsole.Clear();
        AnsiConsole.Live(new Text(""))
            .AutoClear(false)
            .Start(context =>
            {
                liveContext = context;
                gameAction();
                liveContext = null;
            });
    }

    private Table DrawPlayers()
    {
        Table tabble = new Table();
        tabble.Title = new TableTitle("[bold]PLAYERS[/]");
        tabble.AddColumn("Player");
        tabble.AddColumn("Money");
        tabble.AddColumn("Position");
        tabble.AddColumn("Lap");
        tabble.AddColumn("Estates");
        foreach (var player in players)
        {
            string color = player.PlayerColor.ToMarkup();

            tabble.AddRow(
                $"[{color}]{player.Name}[/]",
                $"[{color}]{player.Money}[/]",
                $"[{color}]{player.Position}[/]",
                $"[{color}]{player.Lap}[/]",
                $"[{color}]{string.Join("\n", player.Estate.Select(e => e.Name))}[/]"
                );
        }
        tabble.Width = 65;
        return tabble;
    }

    private Grid CreateScreen()
    {
        FigletText title = new FigletText("MONOPOLY")
        .Centered()
        .Color(Color.Blue);

        Grid gameboard = DrawGameboard();
        Table playerTable = DrawPlayers();

        Grid mainGrid = new Grid();
        mainGrid.AddColumn();
        mainGrid.AddColumn();
        mainGrid.AddRow(gameboard, playerTable);

        Grid screen = new Grid();
        screen.AddColumn();
        screen.AddRow(title);
        screen.AddRow(mainGrid);

        return screen;
    }

    private Grid DrawGameboard()
    {
        side = board.Spaces.Count / 4 + 1;

        Grid topGrid = new Grid();
        for (int i = 0; i < side; i++)
        {
            topGrid.AddColumn();
        }
        IRenderable[] topCells = new IRenderable[side];
        for (int i = 0; i < side; i++)
        {
            topCells[i] = CreateSpasePanel(board.Spaces[i], i);
        }
        topGrid.AddRow(topCells);
        int index = side;

        Grid rightGrid = new Grid();
        rightGrid.AddColumn();

        for (int i = 1; i < side - 1; i++)
        {
            rightGrid.AddRow(CreateSpasePanel(board.Spaces[index], index));
            index++;
        }
        Grid bottomGrid = new Grid();
        for (int i = 0; i < side; i++)
        {
            bottomGrid.AddColumn();
        }
        IRenderable[] bottomCells = new IRenderable[side];

        for (int i = side - 1; i >= 0; i--)
        {
            bottomCells[i] = CreateSpasePanel(board.Spaces[index], index);
            index++;
        }
        bottomGrid.AddRow(bottomCells);

        Grid leftGrid = new Grid();
        leftGrid.AddColumn();

        for (int i = board.Spaces.Count - 1; i >= index; i--)
        {
            leftGrid.AddRow(CreateSpasePanel(board.Spaces[i], i));
        }
        Panel gameInfo = CreateGameInfo();

        Grid middleGrid = new Grid();
        middleGrid.AddColumn();
        middleGrid.AddColumn();
        middleGrid.AddColumn();
        middleGrid.AddRow(
            leftGrid,
            gameInfo,
            rightGrid
            );

        Grid boardGrid = new Grid();
        boardGrid.AddColumn();
        boardGrid.AddRow(topGrid);
        boardGrid.AddRow(middleGrid);
        boardGrid.AddRow(bottomGrid);

        return boardGrid;
    }

    private Panel CreateSpasePanel(Space space, int position)
    {
        string token = CreateTokenPosition(position);
        Panel panel;
        if (space is StartSpace)
        {
            panel = new Panel(
                Align.Center(
                    new Markup($"[bold green]{space.Name}[/]\n🏁\n" +
                        $"{token}"), VerticalAlignment.Middle
                    ).Height(3)
                );
        }
        else if (space is MoneySpace moneySpace)
        {
            panel = new Panel(
                Align.Center(
                    new Markup(
                        $"[yellow]{space.Name}[/]\n💰 " +
                        $"{moneySpace.Amount} €\n" +
                        $"{token}"), VerticalAlignment.Middle
                    ).Height(3)
                );
        }
        else if (space is EventSpace)
        {
            panel = new Panel(
                 Align.Center(
                      new Markup($"[purple]{space.Name}[/]\n❓\n" +
                         $"{token}"), VerticalAlignment.Middle
                      ).Height(3)
                 );
        }
        else if (space is EstateSpace estateSpace)
        {
            panel = new Panel(
                Align.Center(
                    new Markup($"[cyan]{space.Name}[/]\n🏠 " +
                        $"{estateSpace.Price} €\n" +
                        $"{token}"), VerticalAlignment.Middle
                    ).Height(3)
                );
        }
        else
        {
            panel = new Panel(space.Name);
        }
        panel.Header = new PanelHeader($"{position + 1}", Justify.Center);
        panel.Width = 14;
        panel.Height = 5;
        panel.Padding = new Padding(1, 0);
        return panel;
    }

    private string CreateTokenPosition(int position)
    {
        string token = "";

        foreach (var player in players)
        {
            if (player.Position == position)
            {
                token += player.Token;
            }
        }
        return token;
    }

    private Panel CreateGameInfo()
    {
        Markup content = new Markup(
            $"Curent Player: {currentPlayer.Token} {currentPlayer.Name}" +
            $"\U0001F3B2 \U0001F3B2 {diceValue}\n\n" +
            $"[bold]Message:[/]\n{message}"
            );
        Panel panel = new Panel(content);
        panel.Header = new PanelHeader("GAME INFO", Justify.Center);
        panel.Width = (side - 1) * 14 - 4;
        panel.Height = (side - 2) * 5;
        return panel;
    }

    internal void DrawFinalState(Player player)
    {
        Console.ReadLine();
    }
}
