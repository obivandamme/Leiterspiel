namespace Leiterspiel
{
    using Leiterspiel.Core;

    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(BoardLoader.Load(args[0]), new ConsoleInput(), new ConsoleOutput());
            game.Start();
        }
    }
}
