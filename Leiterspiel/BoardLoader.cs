using System.Collections.Generic;

namespace Leiterspiel
{
    using System;
    using System.IO;
    using System.Linq;

    using Leiterspiel.Core;

    public class BoardLoader
    {
        public static Board Load(string filename)
        {
            var zeilen = 0;
            var spalten = 0;
            var moves = new Dictionary<int, int>();
            var lines = LoadFile(filename);

            foreach (var parts in from line in lines where line.IndexOf("=", StringComparison.Ordinal) >= 0 select line.Split('='))
            {
                switch (parts[0].Trim())
                {
                    case "Spalten":
                        spalten = int.Parse(parts[1].Trim());
                        break;
                    case "Zeilen":
                        zeilen = int.Parse(parts[1].Trim());
                        break;
                    case "Leiter":
                    case "Schlange":
                        var fields = parts[1].Split(',');
                        moves.Add(int.Parse(fields[0].Trim()), int.Parse(fields[1].Trim()));
                        break;
                }
            }

            return new Board(zeilen, spalten, moves);
        }

        private static IEnumerable<string> LoadFile(string filename)
        {
            using (TextReader f = File.OpenText(filename))
            {
                string line;
                while ((line = f.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
