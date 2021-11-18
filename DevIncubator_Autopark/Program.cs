using DevIncubator_Autopark.Engines;
using DevIncubator_Autopark.Types;
using DevIncubator_Autopark.VehicleEntity;
using System;
using System.IO;

namespace DevIncubator_Autopark
{
    public class Program
    {
        private static readonly string DirectoryPath = @$"{Directory.GetCurrentDirectory()}\Files\";

        static void Main()
        {
            var vehicleCollections = new Collections($"{DirectoryPath}vehicles.csv", $"{DirectoryPath}types.csv", $"{DirectoryPath}rents.csv");
            vehicleCollections.Print();

            var vehicle = new Vehicle(1, vehicleCollections.VehicleTypes[1], new DieselEngine(3.2d, 50d), "Dodge Chalenger", "3422 AV-4", 3000d, 2018, 30000, ColorType.Black, 70d);

            vehicleCollections.InsertVehicle(-1, vehicle);

            vehicleCollections.Delete(1);
            vehicleCollections.Delete(1);

            vehicleCollections.Print();
            vehicleCollections.Sort(new VehicleComparer());
            vehicleCollections.Print();
        }
    }
}