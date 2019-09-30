namespace Leiterspiel.Core.Extensions
{
    internal static class IntegerExtensions
    {
        internal static bool IsValid(this int draw)
        {
            return (draw >= 1 && draw <= 6);
        }
    }
}
