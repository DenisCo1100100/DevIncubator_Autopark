using System.Collections.Generic;

namespace DevIncubator_Autopark.VehicleEntity
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

        public static Vehicle GetVehicleMaxKilometrs(IReadOnlyList<Vehicle> vehicles)
        {
            var maxKilometrsVehicle = vehicles[0];
            double maxKilometrs = 0.0d;

            foreach (var vehicle in vehicles)
            {
                var fuelTank = vehicle.TankCapacity;
                var vehicleMaxKilometrs = vehicle.VehicleEngine.GetMaxKilometers(fuelTank);

                if (vehicleMaxKilometrs > maxKilometrs)
                {
                    maxKilometrsVehicle = vehicle;
                    maxKilometrs = vehicleMaxKilometrs;
                }
            }

            return maxKilometrsVehicle;
        }
    }
}
