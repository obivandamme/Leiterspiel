namespace Leiterspiel
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = new Board();
            board.Load(args[0]);
            var game = new Game(board);
            game.Start();
        }
    }
}
