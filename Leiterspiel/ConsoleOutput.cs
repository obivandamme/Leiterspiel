﻿using System;

namespace Leiterspiel
{
    using Leiterspiel.Core;
    using Leiterspiel.Core.Interactors;

    public class ConsoleOutput: IOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
