using System;

namespace DevIncubator_Autopark
{
	public class Program
	{
		static void Main()
		{
			VehicleType[] vehicleTypes = new VehicleType[]
			{
				new VehicleType("Bus", 1.2f),
				new VehicleType("Car"),
				new VehicleType("Rink", 1.5f),
				new VehicleType("Tractor", 1.2f)
			};

			Vehicle[] vehicles = new Vehicle[]
			{
				new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "5427 AX-7", 2022f, 2015, 376000, Color.Blue, 200f),
				new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "6427 AA-7", 2500f, 2014, 227010, Color.White, 200f),
				new Vehicle(vehicleTypes[0], "Electric Bus E321", "6785 BA-7", 12080f, 2019, 20451, Color.Grean, 200f),
				new Vehicle(vehicleTypes[1], "Golf 5", "8682 AX-7", 1200f, 2006, 230451, Color.Gray, 90f),
				new Vehicle(vehicleTypes[1], "Tesla Model S 70D", "E001 AA-7", 2200f, 2019, 10454, Color.White, 7000f),
				new Vehicle(vehicleTypes[2], "Hamm HD 12VV", null, 1200f, 2016, 122, Color.Yellow, 90f),
				new Vehicle(vehicleTypes[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200f, 2020, 109, Color.Red, 440f)
			};

			foreach (var vehicle in vehicles)
			{
				Console.WriteLine(vehicle);
			}

			Console.WriteLine();
			Array.Sort(vehicles);

			foreach (var vehicle in vehicles)
			{
				Console.WriteLine(vehicle);
			}

			Console.WriteLine();

			Console.WriteLine("Max milage =>" + GetMaxVehicleMilage(vehicles));
			Console.WriteLine("Min milage =>" + GetMinVehicleMilage(vehicles));
		}

		private static Vehicle GetMinVehicleMilage(Vehicle[] vehicles)
		{
			Vehicle minMilageVehicle = vehicles[0];

			for (int i = 1; i < vehicles.Length; i++)
			{
				if (minMilageVehicle.Mileage > vehicles[i].Mileage)
					minMilageVehicle = vehicles[i];
			}

			return minMilageVehicle;
		}

		private static Vehicle GetMaxVehicleMilage(Vehicle[] vehicles)
		{
			Vehicle maxMilageVehicle = vehicles[0];

			for (int i = 1; i < vehicles.Length; i++)
			{
				if (maxMilageVehicle.Mileage < vehicles[i].Mileage)
					maxMilageVehicle = vehicles[i];
			}

			return maxMilageVehicle;
		}
	}
}