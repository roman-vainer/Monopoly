using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Monopoly;

public class Game {
    public int Size { get; }
    public List<Player> Players { get; }
    public Board Board { get; }
    public Dice Dice { get; }
    Player CurrentPlayer { get; set; }
    private static readonly Color[] colors = [Color.Blue, Color.Red, Color.Yellow, Color.Green];

    public Game(List<Player> players) {
        Players = players;
        Dice = new Dice();
        Board = new Board();
        Initialization();

    }

    private void Initialization() {
        CurrentPlayer = Players[new Random().Next(Players.Count)];
        for (int i = 0; i < Players.Count; i++) {
            Players[i].PlayerColor = colors[i];
        }
    }

    public void Start() {
        while (true) {
            DrawBoard();
            PlayTurn();
        }
    }

    private void PlayTurn() {
        int position = CurrentPlayer.GoTo(Dice.Roll(), Size);
        Board.Spaces[position].ExecuteAction(CurrentPlayer);
        int currentIndex = Players.IndexOf(CurrentPlayer);
        CurrentPlayer = Players[(currentIndex + 1) % Players.Count];
    }

    public void DrawBoard() {
        Console.Clear();
    }
}
