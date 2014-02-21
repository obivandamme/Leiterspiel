namespace Leiterspiel.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Leiterspiel.Core.Interactors;

    public class Board
    {
        public int Zeilen { get; private set; }
        public int Spalten { get; private set; }
        
        readonly Dictionary<int, int> moves = new Dictionary<int, int>();

        public Board(int zeilen, int spalten, Dictionary<int, int> moves)
        {
            this.Zeilen = zeilen;
            this.Spalten = spalten;
            this.moves = moves;
        }

        public int CalculateNewPosition(int oldposition)
        {
            int j;
            return this.moves.TryGetValue(oldposition, out j) ? j : oldposition;
        }

        public void PrintDescription(IOutput output)
        {
            output.Write(string.Format(
                    "Spielbrett mit {0} Zeilen und {1} Spalten. Sieger ist, wer zuerst Feld {2} erreicht hat",
                    this.Zeilen,
                    this.Spalten,
                    this.GetSize()));
        }

        public int GetSize()
        {
            return this.Zeilen * this.Spalten;
        }
    }
}