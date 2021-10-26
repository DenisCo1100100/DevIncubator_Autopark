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
				new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "5427 AX-7", 2022f, 2015, 376000, ColorType.Blue, 200f),
				new Vehicle(vehicleTypes[0], "Volkswagen Crafter", "6427 AA-7", 2500f, 2014, 227010, ColorType.White, 200f),
				new Vehicle(vehicleTypes[0], "Electric Bus E321", "6785 BA-7", 12080f, 2019, 20451, ColorType.Grean, 200f),
				new Vehicle(vehicleTypes[1], "Golf 5", "8682 AX-7", 1200f, 2006, 230451, ColorType.Gray, 90f),
				new Vehicle(vehicleTypes[1], "Tesla Model S 70D", "E001 AA-7", 2200f, 2019, 10454, ColorType.White, 7000f),
				new Vehicle(vehicleTypes[2], "Hamm HD 12VV", null, 1200f, 2016, 122, ColorType.Yellow, 90f),
				new Vehicle(vehicleTypes[3], "МТЗ Беларус-1025.4", "1145 AB-7", 1200f, 2020, 109, ColorType.Red, 440f)
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
		}
	}
}