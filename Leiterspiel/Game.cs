namespace Leiterspiel
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        int currentPlayerNumber = -1;
        Player currentPlayer;
        readonly List<Player> players = new List<Player>();
        readonly Board board;

        public Game(Board board)
        {
            this.board = board;
        }

        public void Start()
        {
            this.Initialize();
            this.NextPlayer();
            while (!this.PlayStep())
            {
                this.NextPlayer();
            }
            this.Finalize();
        }

        private void Initialize()
        {
            this.board.PrintDescription();

            Console.WriteLine("Neues Leiterspiel. Geben Sie zuerst die Anzahl an Spielern ein. [2 .. 4]");

            var numberOfPlayers = int.Parse(Console.ReadLine());
            for (var i = 0; i < numberOfPlayers; i++)
            {
                this.players.Add(new Player());
            }
        }

        private void Finalize()
        {
            Console.WriteLine("Spieler {0} hat gewonnen!!!! Gratulation. ", this.currentPlayerNumber);
            Console.ReadLine();
        }

        public void NextPlayer()
        {
            this.currentPlayerNumber = (this.currentPlayerNumber + 1) % this.players.Count;
            this.currentPlayer = this.players[this.currentPlayerNumber];
        }

        private bool PlayStep()
        {
            int draw;
            string drawstring;
            do
            {
                Console.WriteLine("Spieler {0}: Position {1}. Gewürfelte Augenzahl: ", this.currentPlayerNumber, this.currentPlayer.Position);
                drawstring = Console.ReadLine();

            } while (!int.TryParse(drawstring, out draw) || (draw < 1 || draw > 6));

            this.CalculateStep(draw);
            Console.WriteLine();
            return this.HasWon();
        }

        private void CalculateStep(int draw)
        {
            this.currentPlayer.Position = this.board.CalculateNewPosition(this.currentPlayer.Position + draw);
        }

        private bool HasWon()
        {
            return this.currentPlayer.HasWon(this.board.GetSize());
        }
    }
}