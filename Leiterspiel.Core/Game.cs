namespace Leiterspiel.Core
{
    using Extensions;
    using Interactors;

    public class Game
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly Board _board;
        private readonly PlayerManager _playerManager;

        public Game(Board board, IInput input, IOutput output)
        {
            _board = board;
            _input = input;
            _output = output;
            _playerManager = new PlayerManager();
        }

        public void Start()
        {
            PrintWelcomeMessage();
            InitializePlayers();
            do
            {
                _playerManager.NextPlayer();
                PlayStep();
            }
            while (!IsGameOver());
            _playerManager.PrintWinner(_output);
        }

        private void PrintWelcomeMessage()
        {
            _board.PrintDescription(_output);
            _output.Write("Neues Leiterspiel. Geben Sie zuerst die Anzahl an Spielern ein. [2 .. 4]");
        }

        private void InitializePlayers()
        {
            _playerManager.AddPlayers(_input.Read());

        }

        private void PlayStep()
        {
            _playerManager.CalculateStep(_board, GetDraw());
            _output.Write("");
        }

        private bool IsGameOver()
        {
            return _playerManager.HasWinner(_board);
        }

        private int GetDraw()
        {
            int draw;
            do
            {
                _playerManager.PrintPlayerStatus(_output);
                draw = _input.Read();
            }
            while (!draw.IsValid());
            return draw;
        }
    }
}