using DevIncubator_Autopark.VehicleEntity;
using DevIncubator_Autopark.AllCollections;
using System;
using System.IO;

namespace DevIncubator_Autopark
{
	public class Program
	{
		private static readonly string DirectoryPath = @$"{Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"))}\Files\";

		static void Main()
		{
			var vehicleCollections = new Collections($"{DirectoryPath}vehicles.csv", $"{DirectoryPath}types.csv", $"{DirectoryPath}rents.csv");

			var vehicles = vehicleCollections.Vehicles;
			var queueVehicles = new MyQueue<Vehicle>();

            for (int i = 0; i < vehicles.Count; i++)
            {
				queueVehicles.Enqueue(vehicles[i]);
                Console.WriteLine($"{vehicles[i].Model} -> vehicle queued up");
            }

			Console.WriteLine("\nTransport is washed...\n");

			int count = queueVehicles.Count;
			for (int i = 0; i < count; i++)
			{
				Console.WriteLine($"{queueVehicles.Dequeue().Model} -> washed");
			}
		}
	}
}