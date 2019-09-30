namespace Leiterspiel.Core
{
    public class Player
    {
        public int Position { get; set; }

        public bool HasWon(int boardSize)
        {
            return Position >= boardSize;
        }
    }
}