using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Monopoly
{
    internal class GameEndCheck
    {

        // GameEndCheck guckt ob das Spiel zu Ende ist.
        // Konditionen:
        // - Ein beliebiger Spieler hat 3-mal hintereinander das Startfeld passiert (StartPassStreak >= 3)
        // - 3 beliebige Spieler haben kein Geld mehr (Money <= 0) oder sind nicht aktiv (IstAktiv == false)
        // Returned den Gewinner.
       
        public static Player? CheckEnd(List<Player> players)
        {
            if (players == null || players.Count == 0) return null;

            // Kondition 1: Ein Spieler ist 3-mal hintereinander über das Startfeld gelaufen
            var streakWinner = players.FirstOrDefault(p => p.StartPassStreak >= 3);
            if (streakWinner != null)
            {
                return streakWinner;
            }

            // Kondition 2: 3 beliebige Spieler haben kein Geld mehr oder sind nicht aktiv
            int bankruptCount = players.Count(p => p.Money <= 0 || !p.IsActive);
            if (bankruptCount >= 3)
            {
                // Spieler mit dem meisten Geld gewinnt
                var winner = players.OrderByDescending(p => p.Money).FirstOrDefault();
                return winner;
            }

            return null;
        }
    }
}
