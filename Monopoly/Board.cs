using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;


namespace Monopoly;

public class Board
{
    public List<Space> Spaces { set; get; }
    //public Player players { get; set; }
    //public Board(Player players)
    //{
    //    SetList();
    //}
    public Board()
    {
        Spaces = new List<Space>()
        {
            new MoneySpace(),
            new StartSpace(),
            new EventSpace(),
       };


        Spaces.AddRange(Spaces);
        Spaces.AddRange(Spaces);

        //Spaces.Shuffle();

        //Spaces[0] = new StartSpace();

        Console.WriteLine($"{Spaces.Count}");
    }
}