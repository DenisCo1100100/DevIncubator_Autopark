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
				new VehicleType("Bus", 1.2f),
				new VehicleType("Car"),
				new VehicleType("Rink", 1.5f),
				new VehicleType("Tractor", 1.2f)
			};

			Vehicle[] vehicles = new Vehicle[]
			{
				new Vehicle(vehicleTypes[0], new GasolineEngine(2d, 8.1d), "Volkswagen Crafter", "5427 AX-7", 2022f, 2015, 376000, ColorType.Blue, 200f),
				new Vehicle(vehicleTypes[0], new GasolineEngine(2.18d, 8.5d), "Volkswagen Crafter", "6427 AA-7", 2500f, 2014, 227010, ColorType.White, 200f),
				new Vehicle(vehicleTypes[0], new ElectricalEngine(50d), "Electric Bus E321", "6785 BA-7", 12080f, 2019, 20451, ColorType.Grean, 200f),
				new Vehicle(vehicleTypes[1], new DieselEngine(1.6d, 7.2d), "Golf 5", "8682 AX-7", 1200f, 2006, 230451, ColorType.Gray, 90f),
				new Vehicle(vehicleTypes[1], new ElectricalEngine(25d), "Tesla Model S 70D", "E001 AA-7", 2200f, 2019, 10454, ColorType.White, 7000f),
				new Vehicle(vehicleTypes[2], new DieselEngine(3.2d, 25d), "Hamm HD 12VV", null, 1200f, 2016, 122, ColorType.Yellow, 90f),
				new Vehicle(vehicleTypes[3], new DieselEngine(4.75d, 20.1d), "МТЗ Беларус-1025.4", "1145 AB-7", 1200f, 2020, 109, ColorType.Red, 440f)
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

			Console.WriteLine($"Max milage => {VehicleHelper.GetMaxVehicleByMileage(vehicles)} " +
							 $"\nMin milage => {VehicleHelper.GetMinVehicleByMileage(vehicles)}");

			PrintEqualsVehicles(vehicles);
		}

		public static void PrintEqualsVehicles(Vehicle[] vehicles)
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