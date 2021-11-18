using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DevIncubator_Autopark.Files
{
    public class CsvHelper
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

            data = ChangeDataFormat(data);

            foreach (var dataStr in data.Split(';'))
            {
                listParse.Add(dataStr);
            }

            return listParse;
        }

        private static string ChangeDataFormat(string data)
        {
            data = data.Replace(',', ';');
            Regex regex = new Regex("(?<=['\"])([0-9]*[;]?[0-9])(?=['\"])");

            foreach (var item in regex.Matches(data))
            {
                data = data.Replace(item.ToString(), item.ToString().Replace(';', ','));
            }

            return data.Replace("\"", "");
        }
    }
}