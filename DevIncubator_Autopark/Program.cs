using DevIncubator_Autopark.VehicleEntity;
using DevIncubator_Autopark.AllCollections;
using System;
using System.IO;

namespace DevIncubator_Autopark
{
    public class Program
    {
        private static readonly string DirectoryPath = @$"{Directory.GetCurrentDirectory()}\Files\";

        public static void Main()
        {
            var vehicleCollections = new Collections($"{DirectoryPath}vehicles.csv", $"{DirectoryPath}types.csv", $"{DirectoryPath}rents.csv");

            var vehicles = vehicleCollections.Vehicles;
            var stackVehicles = new MyStack<Vehicle>();

            for (int i = 0; i < vehicles.Count; i++)
            {
                stackVehicles.Push(vehicles[i]);
                Console.WriteLine($"{vehicles[i].Model} -> drove into the garage");
            }

            Console.WriteLine("\nThe garage is full...\n");

            int count = stackVehicles.Count - 1;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{stackVehicles.Pop().Model} -> left the garage");
            }

            Console.WriteLine("\nAuto shop orders:");

            new AutoRepairShop("orders.csv").Print();
        }
    }
}