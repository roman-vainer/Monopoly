using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;


namespace Monopoly;

public class Board
{
    // Kapselung: Setzen von außen verbieten 
    public List<Space> Spaces { get; }

    // Flexibel über Konstruktor steuerbar (Standard: 28) 
    public Board(int boardSize = 28)
    {
        Spaces = GenerateBoard(boardSize);
    }

    private List<Space> GenerateBoard(int size)
    {
        var list = new List<Space>(size);

        // 1. Start-Feld garantieren 
        list.Add(new StartSpace());

        // 2. Verfügbare Standard-Feldtypen definieren 
        Type[] spaceTypes = new Type[] { typeof(MoneySpace), typeof(EventSpace), typeof(PropertySpace) };
        var random = new Random();

        // 3. Restliche Felder dynamisch auffüllen 
        while (list.Count < size)
        {
            int randomIndex = random.Next(spaceTypes.Length); // KORREKTUR: Length statt Count
            Type selectedType = spaceTypes[randomIndex];

            // KORREKTUR: Instanziierung via Activator
            Space newSpace = (Space)System.Activator.CreateInstance(selectedType)!;
            list.Add(newSpace);
        }

        // 4. Nur die Felder NACH dem Start-Feld mischen 
        ShuffleInPlace(list, 1, list.Count - 1);
        return list;
    }

    private void ShuffleInPlace(List<Space> list, int startIndex, int count)
    {
        var random = new Random();
        for (int i = startIndex + count - 1; i > startIndex; i--)
        {
            int j = random.Next(startIndex, i + 1);
            (list[i], list[j]) = (list[j], list[i]); // Tupel-Schnittstelle zum Tauschen 
        }
    }

        //public List<Space> Spaces { set; get; }
        //public Board()
        //{
        //    Spaces = new List<Space>(28);
        //    {
        //        new MoneySpace(),
        //        new EventSpace(),
        //        new PropertySpace(),
        //   };

        //    Spaces.AddRange(Spaces);
        //    Spaces.AddRange(Spaces);
        //    Spaces.AddRange(Spaces);
        //    Spaces.Shuffle();

        //    Spaces[0] = new StartSpace();

        //}
    }