using System.Collections.Generic;
using System.IO;

namespace DevIncubator_Autopark.Files
{
	class CsvHelper
	{
		public string Path { get; }
		public CsvHelper(string path)
		{
			Path = path;
		}

		public IEnumerable<List<string>> ReadCsvFile()
		{
            StreamReader reader = new StreamReader(Path);

            while (!reader.EndOfStream)
            {
                yield return ParseCsvFile(reader.ReadLine());
            }
        }

		public static List<string> ParseCsvFile(string data)
		{
			var listParse = new List<string>();
			var symb = new char[]
			{
				'\"', ','
			};

			foreach (var item in data.Split(symb))
			{
				listParse.Add(item);
			}

			return listParse;
		}
	}
}