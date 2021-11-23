using DevIncubator_Autopark.Files;
using System;
using System.Collections.Generic;
using System.IO;

namespace DevIncubator_Autopark.AllCollections
{
    public class AutoRepairShop
    {
        private readonly string DirectoryPath = @$"{Directory.GetCurrentDirectory()}\Files\";
        private readonly Dictionary<string, int> Orders = new Dictionary<string, int>();

        public string FileName { get; }
        private List<string> _orders;

        public AutoRepairShop(string fileName)
        {
            FileName = fileName;

            CreateListOrders();
            CreateDictionary();
        }

        private void CreateListOrders()
        {
            var csvHelper = new CsvHelper(Path.Combine(DirectoryPath, FileName));
            _orders = new List<string>();

            foreach (var csvStrings in csvHelper.ReadCsvFile())
            {
                foreach (var itemStr in csvStrings)
                {
                    if (!int.TryParse(itemStr, out _))
                    {
                        _orders.Add(itemStr);
                    }
                }
            }
        }

        private void CreateDictionary()
        {
            foreach (var detail in _orders)
            {
                if (!Orders.TryAdd(detail, 1))
                {
                    Orders[detail]++;
                }
            }
        }

        public void Print()
        {
            foreach (var (key, value) in Orders)
                Console.WriteLine($"{key} - {value} шт.");
        }
    }
}