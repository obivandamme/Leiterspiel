namespace Leiterspiel
{
    using System;

    public class Game
    {
        private readonly Board board;
        private readonly PlayerManager playerManager;

        public Game(Board board)
        {
            this.board = board;
            this.playerManager = new PlayerManager();
        }

        public void Start()
        {
            this.PrintWelcomeMessage();
            this.InitializePlayers();
            do
            {
                this.playerManager.NextPlayer();
                this.PlayStep();
            }
            while (!this.IsGameOver());
            this.playerManager.PrintWinner();
        }

        private void PrintWelcomeMessage()
        {
            this.board.PrintDescription();
            Console.WriteLine("Neues Leiterspiel. Geben Sie zuerst die Anzahl an Spielern ein. [2 .. 4]");
        }

        private void InitializePlayers()
        {
            this.playerManager.AddPlayers(int.Parse(Console.ReadLine()));

        }

        private void PlayStep()
        {
            this.playerManager.CalculateStep(this.board, this.GetDraw());
            Console.WriteLine("");
        }

        private bool IsGameOver()
        {
            return this.playerManager.HasWinner(this.board);
        }

        private int GetDraw()
        {
            int draw;
            do
            {
                this.playerManager.PrintPlayerStatus();
                draw = int.Parse(Console.ReadLine());
            }
            while (!IsValid(draw));
            return draw;
        }

        private static bool IsValid(int draw)
        {
            return (draw >= 1 && draw <= 6);
        }
    }
}