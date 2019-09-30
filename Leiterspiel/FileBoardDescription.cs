namespace Leiterspiel
{
    using System.Collections.Generic;
    using System.IO;

    public class FileBoardDescription : IBoardDescription
    {
        private readonly string _filename;

        public FileBoardDescription(string filename)
        {
            this._filename = filename;
        }

        public IEnumerable<string> Read()
        {
            using (TextReader f = File.OpenText(_filename))
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