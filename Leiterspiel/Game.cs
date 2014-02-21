namespace Leiterspiel
{
    using System;

    public class Game
    {
        readonly Board board;

        private readonly PlayerManager playerManager;

        public Game(Board board)
        {
            this.board = board;
            this.playerManager = new PlayerManager();
        }

        public void Start()
        {
            this.Initialize();
            this.playerManager.NextPlayer();
            while (!this.PlayStep())
            {
                this.playerManager.NextPlayer();
            }
            this.playerManager.PrintWinner();
        }

        private void Initialize()
        {
            this.board.PrintDescription();
            this.PrintWelcomeMessage();
            this.playerManager.AddPlayers(int.Parse(Console.ReadLine()));
            
        }

        private void PrintWelcomeMessage()
        {
            Console.WriteLine("Neues Leiterspiel. Geben Sie zuerst die Anzahl an Spielern ein. [2 .. 4]");
        }

        private bool PlayStep()
        {
            this.playerManager.CalculateStep(this.board, this.GetDraw());
            Console.WriteLine();
            return this.playerManager.HasWon(this.board);
        }

        private int GetDraw()
        {
            int draw;
            do
            {
                this.playerManager.PrintPlayerStatus();
            }
            while (!int.TryParse(Console.ReadLine(), out draw) || !IsValid(draw));
            return draw;
        }

        private static bool IsValid(int draw)
        {
            return (draw >= 1 && draw <= 6);
        }
    }
}