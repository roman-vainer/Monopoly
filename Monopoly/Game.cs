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
    private static readonly Color[] colors = [Color.Blue, Color.Red, Color.Yellow, Color.Green];
    private string message = "";
    SpectreUI ui;


    public Game(List<Player> players, int size) {
        this.players = players;
        Size = size;
        dice = new Dice();
        board = new Board(size);
        ui = new SpectreUI();
        Initialization();

    }

    private void Initialization() {
        currentPlayer = players[new Random().Next(players.Count)];
        for (int i = 0; i < players.Count; i++) {
            players[i].PlayerColor = colors[i];
        }
    }

    public void Start() {
        while (true) {
            DrawBoard();
            PlayTurn();
            Console.ReadLine();
        }
    }

    public void PlayTurn() {
        int position = currentPlayer.GoTo(dice.Roll());
        message = board.Spaces[position].ExecuteAction(currentPlayer);
        int currentIndex = players.IndexOf(currentPlayer);
        currentPlayer = players[(currentIndex + 1) % players.Count];
    }

    public void DrawBoard() {
        ui.DrawGame(board, players, message, dice.CurrentValue);
    }
}
