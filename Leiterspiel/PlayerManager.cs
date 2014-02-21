using System;
using System.Collections.Generic;

namespace Leiterspiel
{
    public class PlayerManager : List<Player>
    {
        int currentPlayerNumber = -1;

        Player CurrentPlayer
        {
            get
            {
                return this[currentPlayerNumber];
            }
        }

        public void NextPlayer()
        {
            this.currentPlayerNumber = (this.currentPlayerNumber + 1) % this.Count;
        }

        public void AddPlayers(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                this.Add(new Player());
            }
        }

        public void PrintWinner()
        {
            Console.WriteLine("Spieler {0} hat gewonnen!!!! Gratulation. ", this.currentPlayerNumber);
            Console.ReadLine();
        }

        public void PrintPlayerStatus()
        {
            Console.WriteLine("Spieler {0}: Position {1}. Gewürfelte Augenzahl: ", this.currentPlayerNumber, this.CurrentPlayer.Position);
        }

        public bool HasWinner(Board board)
        {
            return this.CurrentPlayer.HasWon(board.GetSize());
        }

        public void CalculateStep(Board board, int draw)
        {
            this.CurrentPlayer.Position = board.CalculateNewPosition(this.CurrentPlayer.Position + draw);
        }
    }
}
