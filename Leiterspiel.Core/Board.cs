namespace Leiterspiel.Core
{
    using System.Collections.Generic;

    using Leiterspiel.Core.Interactors;

    public class Board
    {
        private readonly int _rows;
        private readonly int _columns;
        private readonly Dictionary<int, int> _moves;

        public Board(int rows, int columns, Dictionary<int, int> moves)
        {
            _rows = rows;
            _columns = columns;
            _moves = moves;
        }

        public int CalculateNewPosition(int oldPosition)
        {
            return _moves.TryGetValue(oldPosition, out var j) ? j : oldPosition;
        }

        public void PrintDescription(IOutput output)
        {
            output.Write($"Spielbrett mit {_rows} Zeilen und {_columns} Spalten. Sieger ist, wer zuerst Feld {GetSize()} erreicht hat");
        }

        public int GetSize()
        {
            return _rows * _columns;
        }
    }
}