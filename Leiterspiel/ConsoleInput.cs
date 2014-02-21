using System;

namespace Leiterspiel
{
    using Leiterspiel.Core;
    using Leiterspiel.Core.Interactors;

    public class ConsoleInput : IInput
    {
        public int Read()
        {
            return int.Parse(Console.ReadLine());
        }
    }
}
