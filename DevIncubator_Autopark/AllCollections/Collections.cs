using System;
using DevIncubator_Autopark.Types;
using System.Collections.Generic;
using DevIncubator_Autopark.Files;
using DevIncubator_Autopark.VehicleEntity;
using DevIncubator_Autopark.Engines.Base;
using DevIncubator_Autopark.Engines;

namespace DevIncubator_Autopark.AllCollections
{
    public class Collections
    {
        public List<VehicleType> VehicleTypes { get; }
        public List<Vehicle> Vehicles { get; }

        public Collections(string vehicles, string types, string rents)
        {
            VehicleTypes = ParseVehicleTypes(types);
            Vehicles = ParseVehicles(vehicles);
            LoadRents(rents);
        }

        public List<VehicleType> ParseVehicleTypes(string inFile)
        {
            var vehicleTypes = new List<VehicleType>();
            var csvData = new CsvHelper(inFile).ReadCsvFile();

            foreach (var cvsString in csvData)
            {
                vehicleTypes.Add(CreateVehicleType(int.Parse(cvsString[0]), cvsString[1], double.Parse(cvsString[2])));
            }

            return vehicleTypes;
        }

        private VehicleType CreateVehicleType(int id, string name, double taxCoefficient) => new VehicleType(id, name, taxCoefficient);

        public List<Vehicle> ParseVehicles(string inFile)
        {
            var csvHelper = new CsvHelper(inFile);
            var vehicles = new List<Vehicle>();

            foreach (var csvString in csvHelper.ReadCsvFile())
            {
                vehicles.Add(CreateVehicle(csvString));
            }

            return vehicles;
        }

        public Vehicle CreateVehicle(IReadOnlyList<string> csvString)
        {
            int id = int.Parse(csvString[0]);
            var vehicleType = GetVehicleType(csvString[1]);
            string modelName = csvString[2];
            string licensePlate = csvString[3];
            double weight = double.Parse(csvString[4]);
            int yearIssue = int.Parse(csvString[5]);
            double milage = double.Parse(csvString[6]);
            Enum.TryParse(csvString[7], out ColorType color);

            AbstractEngine engine = csvString[8] switch
            {
                "Electrical" => new ElectricalEngine(double.Parse(csvString[10])),
                "Gasoline" => new GasolineEngine(double.Parse(csvString[9]), double.Parse(csvString[10])),
                "Diesel" => new DieselEngine(double.Parse(csvString[9]), double.Parse(csvString[10])),
                _ => null
            };

            double tankCapacity = double.Parse(csvString[11]);


            return new Vehicle(id, vehicleType, engine, modelName, licensePlate, weight, yearIssue, milage, color, tankCapacity);
        }

        private VehicleType GetVehicleType(string idType)
        {
            foreach (var vehicleType in VehicleTypes)
            {
                if (vehicleType.Id.Equals(int.Parse(idType)))
                    return vehicleType;
            }

            return new VehicleType();
        }

        public void LoadRents(string inFile)
        {
            var csvHelper = new CsvHelper(inFile);

            foreach (var csvString in csvHelper.ReadCsvFile())
            {
                CreateRent(csvString);
            }
        }

        private void CreateRent(IReadOnlyList<string> rentData)
        {
            int vehicleId = int.Parse(rentData[0]);
            DateTime rentTime = DateTime.Parse(rentData[1]);
            double rentPrice = double.Parse(rentData[2]);

            foreach (var vehicle in Vehicles)
            {
                if (vehicle.Id == vehicleId)
                {
                    vehicle.Rents.Add(new Rent(rentTime, rentPrice));
                }
            }
        }

        public void InsertVehicle(int index, Vehicle v)
        {
            if (index < 0 || index > Vehicles.Count - 1)
                Vehicles.Add(v);
            else
                Vehicles.Insert(index, v);
        }

        public bool Delete(int index)
        {
            if (index < 0 || Vehicles.Count < index)
            {
                return false;
            }

            Vehicles.RemoveAt(index);

            return true;
        }

        public double SumTotalProfit()
        {
            double totalProfit = 0;
            Vehicles.ForEach(vehicle => totalProfit += vehicle.GetTotalProfit());

            return totalProfit;
        }

        public void Print()
        {
            Console.WriteLine($"{"ID",-5}{"Type",-10}{"Model name",-25}{"Number",-15}{"Weight(kg)",-15}" +
                              $"{"Year",-10}{"Mileage",-10}{"Color",-10}{"Income",-10}{"Tax",-10}{"Profit",-10}");

            foreach (var vehicle in Vehicles)
            {
                Console.WriteLine($"{vehicle.Id,-5}" +
                                  $"{vehicle.VehicleType.TypeName,-10}" +
                                  $"{vehicle.Model,-25}" +
                                  $"{vehicle.LicensePlate,-15}" +
                                  $"{vehicle.Weight,-15}" +
                                  $"{vehicle.YearIssue,-10}" +
                                  $"{vehicle.Mileage,-10}" +
                                  $"{vehicle.Color,-10}" +
                                  $"{vehicle.GetTotalIncome(),-10:0.00}" +
                                  $"{vehicle.GetCalcTaxPerMonth(),-10:0.00}" +
                                  $"{vehicle.GetTotalProfit(),-10:0.00}");
            }

            Console.WriteLine($"Total: {SumTotalProfit(),120:0.00}");
        }

        public void Sort(IComparer<Vehicle> comparator) => Vehicles.Sort(comparator);
    }
}