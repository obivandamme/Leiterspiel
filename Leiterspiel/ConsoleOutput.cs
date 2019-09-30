using System;

namespace Leiterspiel
{
    using Core.Interactors;

    public class ConsoleOutput: IOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
