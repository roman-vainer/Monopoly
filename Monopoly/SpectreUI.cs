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
        DrawGameboard(board);
    }

    private void DrawTitel() {
        AnsiConsole.Write(
            new FigletText("MONOPOLY")
            .Centered()
            .Color(Color.Blue));
    }

    private void DrawGameboard(Board board) {

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
        AnsiConsole.Write(grid);
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
}
