using System;
using System.Collections.Generic;
using System.Text;


namespace Monopoly;

public class Board {
    private readonly int size;
    public List<Space> Spaces { get; }

    public Board(int size) {
        this.size = size;
        Spaces = CreateSpaces();

    }

    private List<Space> CreateSpaces() {
        var spaces = new List<Space>();
        Random random = new Random();
        for (int i = 0; i < size - 1; i++) {
            int rdm = random.Next(1, 4);

            spaces.Add(rdm switch
            {
                1 => new EventSpace(),
                2 => new MoneySpace(random.Next(1,6) * 100),
                3 => new EstateSpace(),
                _=> throw new Exception()
            });
        }
        spaces = spaces.Shuffle().ToList();
        spaces.Insert(0, new StartSpace());
        return spaces;
    }
}