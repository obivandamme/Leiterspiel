namespace Leiterspiel
{
    using Leiterspiel.Core;

    class Program
    {
        static void Main(string[] args)
        {
            var boardDescription = new FileBoardDescription(args[0]);
            var loader = new BoardLoader(boardDescription);
            var game = new Game(loader.Load(), new ConsoleInput(), new ConsoleOutput());
            game.Start();
        }
    }
}
