using DevIncubator_Autopark.Engines;
using System;

namespace DevIncubator_Autopark
{
	public class Program
	{
		static void Main()
		{
			VehicleType[] vehicleTypes = new VehicleType[]
			{
				new VehicleType("Bus", 1.2d),
				new VehicleType("Car"),
				new VehicleType("Rink", 1.5d),
				new VehicleType("Tractor", 1.2d)
			};

			Vehicle[] vehicles = new Vehicle[]
			{
				new Vehicle(vehicleTypes[0], new GasolineEngine(2d, 8.1d), "Volkswagen Crafter", "5427 AX-7", 2022d, 2015, 376000, ColorType.Blue, 75d),
				new Vehicle(vehicleTypes[0], new GasolineEngine(2.18d, 8.5d), "Volkswagen Crafter", "6427 AA-7", 2500d, 2014, 227010, ColorType.White, 75d),
				new Vehicle(vehicleTypes[0], new ElectricalEngine(50d), "Electric Bus E321", "6785 BA-7", 12080d, 2019, 20451, ColorType.Grean, 150d),
				new Vehicle(vehicleTypes[1], new DieselEngine(1.6d, 7.2d), "Golf 5", "8682 AX-7", 1200d, 2006, 230451, ColorType.Gray, 55d),
				new Vehicle(vehicleTypes[1], new ElectricalEngine(25d), "Tesla Model S 70D", "E001 AA-7", 2200d, 2019, 10454, ColorType.White, 70d),
				new Vehicle(vehicleTypes[2], new DieselEngine(3.2d, 25d), "Hamm HD 12VV", null, 1200d, 2016, 122, ColorType.Yellow, 20d),
				new Vehicle(vehicleTypes[3], new DieselEngine(4.75d, 20.1d), "МТЗ Беларус-1025.4", "1145 AB-7", 1200d, 2020, 109, ColorType.Red, 135d)
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

			Console.WriteLine($"Max milage => {VehicleHelper.GetMaxVehicleByMileage(vehicles)}" +
				$"\nMin milage => {VehicleHelper.GetMinVehicleByMileage(vehicles)}");

			PrintEqualsVehicles(vehicles);

			Console.WriteLine($"\nVehicle that will travel the maximum distance on a full tank/battery:" +
				$"\n{VehicleHelper.GetVehicleMaxKilometrs(vehicles)}");
		}

		private static void PrintEqualsVehicles(Vehicle[] vehicles)
		{
			Console.WriteLine("\nEquals vehicles:");

			for (int i = 1; i < vehicles.Length; i++)
			{
				if (vehicles[i].Equals(vehicles[i - 1]))
					Console.WriteLine($"{vehicles[i]}\n{vehicles[i - 1]}");
			}
		}
	}
}