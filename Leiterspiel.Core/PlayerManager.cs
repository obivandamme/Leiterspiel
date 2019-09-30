using System.Collections.Generic;

namespace Leiterspiel.Core
{
    using Interactors;

    public class PlayerManager : List<Player>
    {
        private int _currentPlayerNumber = -1;

        public void NextPlayer()
        {
            _currentPlayerNumber = (_currentPlayerNumber + 1) % Count;
        }
        
        public void AddPlayers(int numberOfPlayers)
        {
            for (var i = 0; i < numberOfPlayers; i++)
            {
                Add(new Player());
            }
        }

        public void PrintWinner(IOutput output)
        {
            output.Write($"Spieler {_currentPlayerNumber} hat gewonnen!!!! Gratulation. ");
        }

        public void PrintPlayerStatus(IOutput output)
        {
            output.Write($"Spieler {_currentPlayerNumber}: Position {this[_currentPlayerNumber].Position}. Gewürfelte Augenzahl: ");
        }

        public bool HasWinner(Board board)
        {
            return this[_currentPlayerNumber].HasWon(board.GetSize());
        }

        public void CalculateStep(Board board, int draw)
        {
            this[_currentPlayerNumber].Position = board.CalculateNewPosition(this[_currentPlayerNumber].Position + draw);
        }
    }
}