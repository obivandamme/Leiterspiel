namespace Leiterspiel
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Board
    {
        public int Zeilen { get; set; }
        public int Spalten { get; set; }
        
        readonly Dictionary<int, int> moves = new Dictionary<int, int>();

        public int CalculateNewPosition(int oldposition)
        {
            int j;
            return this.moves.TryGetValue(oldposition, out j) ? j : oldposition;
        }

        public void Load(string filename)
        {
            using (TextReader f = File.OpenText(filename))
            {
                string line;
                while ((line = f.ReadLine()) != null)
                {
                    if (line.IndexOf("=", StringComparison.Ordinal) >= 0)
                    {
                        var parts = line.Split('=');
                        if (parts[0].Trim() == "Spalten") this.Spalten = int.Parse(parts[1].Trim());
                        if (parts[0].Trim() == "Zeilen") this.Zeilen = int.Parse(parts[1].Trim());
                        if (parts[0].Trim() == "Leiter" || parts[0].Trim() == "Schlange")
                        {
                            var fields = parts[1].Split(',');
                            this.moves.Add(int.Parse(fields[0].Trim()), int.Parse(fields[1].Trim()));
                        }
                    }
                }
            }
        }

        public void PrintDescription()
        {
            Console.WriteLine("Spielbrett mit {0} Zeilen und {1} Spalten. Sieger ist, wer zuerst Feld {2} erreicht hat",
                this.Zeilen, this.Spalten, this.GetSize());
        }

        public int GetSize()
        {
            return this.Zeilen * this.Spalten;
        }
    }
}