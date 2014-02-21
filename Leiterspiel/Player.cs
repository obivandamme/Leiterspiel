namespace Leiterspiel
{
    public class Player
    {
        public int Position { get; set; }

        public bool HasWon(int boardSize)
        {
            return this.Position >= boardSize;
        }
    }
}