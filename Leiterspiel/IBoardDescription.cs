namespace Leiterspiel
{
    using System.Collections.Generic;

    public interface IBoardDescription
    {
        IEnumerable<string> Read();
    }
}