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


		public List<List<string>> ReadCsvFile()
		{
			var listCsvString = new List<List<string>>();

			using (StreamReader reader = new StreamReader(Path))
			{
				while (!reader.EndOfStream)
				{
					listCsvString.Add(ParseCsvFile(reader.ReadLine()));
				}
			}

			return listCsvString;
		}

		public static List<string> ParseCsvFile(string data)
		{
			var listParse = new List<string>();

			foreach (var item in data.Split(','))
			{
				listParse.Add(item);
			}

			return listParse;
		}
	}
}