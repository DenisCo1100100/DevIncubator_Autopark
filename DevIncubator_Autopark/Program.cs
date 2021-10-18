using System;

namespace DevIncubator_Autopark
{
	class Program
	{
		static void Main()
		{
			//1
			VehicleType[] vehicles = new VehicleType[]
			{
				new VehicleType("Bus", 1.2f),
				new VehicleType("Car"),
				new VehicleType("Rink", 1.5f),
				new VehicleType("Tractor", 1.2f)
			};

			//2, 5, 6
			float averageCoefficient = 0;
			for (int i = 0; i < vehicles.Length; i++)
			{
				vehicles[i].Display();

				averageCoefficient += vehicles[i].TaxCoefficient;
			}

			averageCoefficient /= vehicles.Length;
			Console.WriteLine($"Average tax coefficient = {averageCoefficient:0.00}");

			//3
			vehicles[^1].TaxCoefficient = 1.3f;

			//4
			float maxCoefficient = 0;
			for (int i = 0; i < vehicles.Length; i++)
			{
				if (vehicles[i].TaxCoefficient > maxCoefficient)
					maxCoefficient = vehicles[i].TaxCoefficient;
			}
			Console.WriteLine($"Maximum coefficient = {maxCoefficient}");

			//7
			foreach (var vehicle in vehicles)
				Console.WriteLine(vehicle);
		}
	}
}