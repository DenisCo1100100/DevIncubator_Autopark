using System;

namespace DevIncubator_Autopark
{
	public class Program
	{
		static void Main()
		{
			VehicleType[] vehicles = new VehicleType[]
			{
				new VehicleType("Bus", 1.2f),
				new VehicleType("Car"),
				new VehicleType("Rink", 1.5f),
				new VehicleType("Tractor", 1.2f)
			};

			for (int i = 0; i < vehicles.Length; i++)
			{
				vehicles[i].Display();
			}

			Console.WriteLine($"Average tax coefficient = {ColculateAverageCoefficient(vehicles):0.00}");

			vehicles[^1].TaxCoefficient = 1.3f;

			Console.WriteLine($"Maximum coefficient = {ColculateMaxCoefficient(vehicles)}");

			foreach (var vehicle in vehicles)
				Console.WriteLine(vehicle);
		}

		private static float ColculateAverageCoefficient(VehicleType[] vehicles)
		{
			float averageCoefficient = 0;
			for (int i = 0; i < vehicles.Length; i++)
			{
				averageCoefficient += vehicles[i].TaxCoefficient;
			}

			return averageCoefficient / vehicles.Length;
		}

		private static float ColculateMaxCoefficient(VehicleType[] vehicles)
		{
			float maxCoefficient = 0;
			for (int i = 0; i < vehicles.Length; i++)
			{
				if (vehicles[i].TaxCoefficient > maxCoefficient)
					maxCoefficient = vehicles[i].TaxCoefficient;
			}

			return maxCoefficient;
		}
	}
}