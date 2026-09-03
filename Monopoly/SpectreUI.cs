using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;


namespace Monopoly;

public class SpectreUI : IUserInterface {
    public void DisplayMessage(string message) {
    }

    public void DrawGame(Board board, List<Player> players, string message, int diceValue) {
        Console.OutputEncoding = Encoding.UTF8;
        AnsiConsole.Clear();
        DrawTitel();
        Grid gameBoard = DrawGameboard(board);
        Table playerTable = DrawPlayers(players);

        Grid mainGrid = new Grid();
        mainGrid.AddColumn();
        mainGrid.AddColumn();
        mainGrid.AddRow(gameBoard, playerTable);
        AnsiConsole.Write(mainGrid);
    }

    private Table DrawPlayers(List<Player> players) {
        Table tabble = new Table();
        tabble.Title = new TableTitle("[bold]PLAYERS[/]");
        tabble.AddColumn("Player");
        tabble.AddColumn("Money");
        tabble.AddColumn("Position");
        tabble.AddColumn("Lap");
        //tabble.AddColumn("Estates");
        foreach (var player in players) {
            string color = player.PlayerColor.ToMarkup();

            tabble.AddRow(
                $"[{color}]{player.Name}[/]",
                $"{player.Money}",
                $"{player.Position}",
                $"{player.Lap}"
                //$"{player.Estate}"
                );
        }
        tabble.Width = 65;
        return tabble;
    }

    private void DrawTitel() {
        AnsiConsole.Write(
            new FigletText("MONOPOLY")
            .Centered()
            .Color(Color.Blue));
    }

    private Grid DrawGameboard(Board board) {

        int side = board.Spaces.Count / 4 + 1;

        IRenderable[,] cells = new IRenderable[side, side];

        for (int row = 0; row < side; row++) {
            for (int column = 0; column < side; column++) {
                cells[row, column] = new Text("");
            }
        }
        int index = 0;
        for (int column = 0; column < side; column++) {
            cells[0, column] = CreateSpasePanel(board.Spaces[index], index);
            index++;
        }

        for (int row = 1; row < side; row++) {
            cells[row, side - 1] = CreateSpasePanel(board.Spaces[index], index);
            index++;
        }

        for (int column = side - 2; column >= 0; column--) {
            cells[side - 1, column] = CreateSpasePanel(board.Spaces[index], index);
            index++;
        }
        for (int row = side - 2; row > 0; row--) {
            cells[row, 0] = CreateSpasePanel(board.Spaces[index], index);
            index++;
        }

        Grid grid = new Grid();

        for (int i = 0; i < side; i++) {
            grid.AddColumn();
        }

        for (int row = 0; row < side; row++) {
            IRenderable[] rowCells = new IRenderable[side];
            for (int column = 0; column < side; column++) {
                rowCells[column] = cells[row, column];
            }
            grid.AddRow(rowCells);
        }
        return grid;
    }

    private Panel CreateSpasePanel(Space space, int position) {
        Panel panel;
        if (space is StartSpace) {
            panel = new Panel(
                new Markup($"[bold green]{space.Name}[/]"));
        } else if (space is MoneySpace moneySpace) {
            panel = new Panel(
                new Markup(
                    $"[yellow]{space.Name}[/]\n{moneySpace.Amount} €"));
        } else if (space is EventSpace) {
            panel = new Panel(
                new Markup($"[purple]{space.Name}[/]\n[bold purple]?[/]"));
        } else if (space is EstateSpace estateSpace) {
            panel = new Panel(
                new Markup($"[cyan]{space.Name}[/]\n{estateSpace.Price} €"));
        } else {
            panel = new Panel(space.Name);
        }
        panel.Header = new PanelHeader($"{position + 1}");
        panel.Width = 14;
        panel.Height = 5;
        panel.Padding = new Padding(1, 0);
        return panel;
    }

    internal void DrawFinalState(Player player)
    {
        Console.ReadLine();
    }
}
