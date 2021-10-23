using System.Collections.Generic;

namespace DevIncubator_Autopark
{
	public static class VehicleHelper
	{
		public static Vehicle GetMaxVehicleByMileage(IReadOnlyList<Vehicle> vehicles)
		{
			var maxMilageVehicle = vehicles[0];

			foreach (var vehicle in vehicles)
			{
				if (maxMilageVehicle.Mileage < vehicle.Mileage)
					maxMilageVehicle = vehicle;
			}

			return maxMilageVehicle;
		}

		public static Vehicle GetMinVehicleByMileage(IReadOnlyList<Vehicle> vehicles)
		{
			var minMilageVehicle = vehicles[0];

			foreach (var vehicle in vehicles)
			{
				if (minMilageVehicle.Mileage > vehicle.Mileage)
					minMilageVehicle = vehicle;
			}

			return minMilageVehicle;
		}
	}
}
