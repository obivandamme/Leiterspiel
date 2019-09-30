using System;

namespace Leiterspiel
{
    using Core.Interactors;

    public class ConsoleInput : IInput
    {
        public int Read()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
