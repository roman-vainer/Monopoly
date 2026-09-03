using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Monopoly;

public class Game {
    public int Size { get; }
    public List<Player> players;
    private Board board;
    private Dice dice;
    private Player currentPlayer;
    private static readonly Color[] colors = [Color.Red, Color.Yellow, Color.Green, Color.Blue];
    private string message = "";
    private readonly SpectreUI ui;


    public Game(List<Player> players, int size) {
        this.players = players;
        Size = size;
        dice = new Dice();
        board = new Board(size);
        Initialization();
        ui = new SpectreUI(board, players);

    }

    private void Initialization() {
        currentPlayer = players[new Random().Next(players.Count)];
        for (int i = 0; i < players.Count; i++) {
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

    public void Start() {
        DrawBoard();
        Console.ReadLine();
        while (!IsEnd()) {
            
            PlayTurn();
            DrawBoard();
            Console.ReadLine();
            ChangePosition();
            DrawBoard();
            Console.ReadLine();
        }
        Player player = DetermineWinner();
        DrawFinalState(player);

    }

    private void DrawFinalState(Player player) {
        ui.DrawFinalState(player);
    }

    private Player DetermineWinner() {
        Player player = null;
        decimal money = 0;
        foreach (Player currentPlayer in players) {
            if (currentPlayer.IsActive && currentPlayer.Money > money) {
                money = currentPlayer.Money;
                player = currentPlayer;
            }
        }
        return player;
    }


    public void PlayTurn() {
        int steps = dice.Roll();
        int position = currentPlayer.GoTo(steps);
        message = board.Spaces[position].ExecuteAction(currentPlayer);

        

    }

    private void ChangePosition() {
        int currentIndex = players.IndexOf(currentPlayer);
        currentPlayer = players[(currentIndex + 1) % players.Count];
        message = $"Current Player is now {currentPlayer.Token} - {currentPlayer.Name}";
    }

    // IsEnd guckt ob das Spiel zu Ende ist.
    // Konditionen:
    // - Ein beliebiger Spieler hat 3-mal hintereinander das Startfeld passiert (StartPassStreak >= 3)
    // - 3 beliebige Spieler haben kein Geld mehr (Money <= 0) oder sind nicht aktiv (IstAktiv == false)
    // Returned den Gewinner.

    public bool IsEnd() {
        int activePlayers = players.Count(p => p.IsActive);
        var allLaps = players.FirstOrDefault(p => p.Lap >= 3);
        if (activePlayers <= 1 || allLaps != null) {
            return true;
        }
        return false;
    }

    public void DrawBoard() {
        ui.DrawGame(message, dice.CurrentValue, currentPlayer);
    }
}
