namespace Leiterspiel.Core
{
    using Leiterspiel.Core.Extensions;
    using Leiterspiel.Core.Interactors;

    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly Board _board;
        private readonly PlayerManager _playerManager;

        public Game(Board board, IInput input, IOutput output)
        {
            this._board = board;
            this._input = input;
            this._output = output;
            this._playerManager = new PlayerManager();
        }

        public void Start()
        {
            this.PrintWelcomeMessage();
            this.InitializePlayers();
            do
            {
                this._playerManager.NextPlayer();
                this.PlayStep();
            }
            while (!this.IsGameOver());
            this._playerManager.PrintWinner(this._output);
        }

        private void PrintWelcomeMessage()
        {
            this._board.PrintDescription(this._output);
            this._output.Write("Neues Leiterspiel. Geben Sie zuerst die Anzahl an Spielern ein. [2 .. 4]");
        }

        private void InitializePlayers()
        {
            this._playerManager.AddPlayers(this._input.Read());

        }

        private void PlayStep()
        {
            this._playerManager.CalculateStep(this._board, this.GetDraw());
            this._output.Write("");
        }

        private bool IsGameOver()
        {
            return this._playerManager.HasWinner(this._board);
        }

        private int GetDraw()
        {
            int draw;
            do
            {
                this._playerManager.PrintPlayerStatus(this._output);
                draw = this._input.Read();
            }
            while (!draw.IsValid());
            return draw;
        }
    }
}