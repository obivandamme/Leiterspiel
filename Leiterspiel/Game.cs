namespace Leiterspiel
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        int CurrentPlayerNumber = -1;
        Player CurrentPlayer;
        List<Player> Players = new List<Player>();
        Board board;

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
            Console.WriteLine(string.Format("Spielbrett mit {0} Zeilen und {1} Spalten. Sieger ist, wer zuerst Feld {2} erreicht hat",
                this.board.Zeilen, this.board.Spalten, this.board.Zeilen * this.board.Spalten));

            Console.WriteLine("Neues Leiterspiel. Geben Sie zuerst die Anzahl an Spielern ein. [2 .. 4]");

            int NumberOfPlayers = int.Parse(Console.ReadLine());
            for (int i = 0; i < NumberOfPlayers; i++) this.Players.Add(new Player());
        }

        private void Finalize()
        {
            Console.WriteLine(string.Format("Spieler {0} hat gewonnen!!!! Gratulation. ", this.CurrentPlayerNumber));
            Console.ReadLine();
        }

        public void NextPlayer()
        {
            this.CurrentPlayerNumber = (this.CurrentPlayerNumber + 1) % this.Players.Count;
            this.CurrentPlayer = this.Players[this.CurrentPlayerNumber];
        }

        private bool PlayStep()
        {
            int draw = 0;
            string drawstring = "";
            do
            {
                Console.WriteLine(string.Format("Spieler {0}: Position {1}. Gewürfelte Augenzahl: ", this.CurrentPlayerNumber, this.CurrentPlayer.Position));
                drawstring = Console.ReadLine();

            } while (!int.TryParse(drawstring, out draw) || (draw < 1 || draw > 6));

            this.CalculateStep(draw);
            Console.WriteLine();
            return this.HasWon();
        }

        private void CalculateStep(int draw)
        {
            this.CurrentPlayer.Position = this.board.CalculateNewPosition(this.CurrentPlayer.Position + draw);
        }

        private bool HasWon()
        {
            return this.CurrentPlayer.Position >= this.board.Zeilen * this.board.Spalten;
        }
    }
}