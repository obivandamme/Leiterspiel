namespace Leiterspiel
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(args[0]);
            Game game = new Game(board);
        }
    }
}
