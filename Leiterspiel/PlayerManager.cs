using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leiterspiel
{
    public class PlayerManager
    {
        int currentPlayerNumber = -1;
        Player currentPlayer;
        readonly List<Player> players = new List<Player>();

        public void NextPlayer()
        {
            this.currentPlayerNumber = (this.currentPlayerNumber + 1) % this.players.Count;
            this.currentPlayer = this.players[this.currentPlayerNumber];
        }

        public void AddPlayers(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                this.players.Add(new Player());
            }
        }

        public void PrintWinner()
        {
            Console.WriteLine("Spieler {0} hat gewonnen!!!! Gratulation. ", this.currentPlayerNumber);
            Console.ReadLine();
        }

        public void PrintPlayerStatus()
        {
            Console.WriteLine("Spieler {0}: Position {1}. Gewürfelte Augenzahl: ", this.currentPlayerNumber, this.currentPlayer.Position);
        }

        public bool HasWon(Board board)
        {
            return this.currentPlayer.HasWon(board.GetSize());
        }

        public void CalculateStep(Board board, int draw)
        {
            this.currentPlayer.Position = board.CalculateNewPosition(this.currentPlayer.Position + draw);
        }
    }
}
