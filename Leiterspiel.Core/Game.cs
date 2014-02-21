namespace Leiterspiel.Core
{
    using Leiterspiel.Core.Interactors;

    public class Game
    {
        private readonly IInput input;
        private readonly IOutput output;
        private readonly Board board;
        private readonly PlayerManager playerManager;

        public Game(Board board, IInput input, IOutput output)
        {
            this.board = board;
            this.input = input;
            this.output = output;
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
            this.playerManager.PrintWinner(this.output);
        }

        private void PrintWelcomeMessage()
        {
            this.board.PrintDescription(this.output);
            this.output.Write("Neues Leiterspiel. Geben Sie zuerst die Anzahl an Spielern ein. [2 .. 4]");
        }

        private void InitializePlayers()
        {
            this.playerManager.AddPlayers(this.input.Read());

        }

        private void PlayStep()
        {
            this.playerManager.CalculateStep(this.board, this.GetDraw());
            this.output.Write("");
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
                this.playerManager.PrintPlayerStatus(this.output);
                draw = this.input.Read();
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