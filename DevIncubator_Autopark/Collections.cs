using DevIncubator_Autopark.Types;
using System.Collections.Generic;
using DevIncubator_Autopark.Files;
using DevIncubator_Autopark.VehicleEntity;

namespace DevIncubator_Autopark
{
	class Collections
	{
		public List<VehicleType> VehicleTypes { get; }
		public List<Vehicle> Vehicles { get; }

		public Collections(string vehicles, string types, string rents)
		{
			Vehicles = ParseVehicles(vehicles);
			VehicleTypes = ParseVehicleTypes(types);
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
			var csvData = new CsvHelper(inFile).ReadCsvFile();
			var vehicles = new List<Vehicle>();

			foreach (var csvString in csvData)
			{
				vehicles.Add(CreateVehicle(csvString));
			}
		}

		public Vehicle CreateVehicle(IReadOnlyList<string> csvString)
		{
		}

		private VehicleType GetVehicleType(int idType)
		{

			foreach (var vehicleType in VehicleTypes)
				if (vehicleType.Id.Equals(idType))
					return vehicleType;

			return new VehicleType();
		}

		public void LoadRents(string inFile)
		{

		}

		public void InsertVehicle(int index, Vehicle v)
		{

		}

		public int Delete(int index)
		{

		}

		public double SumTotalProfit()
		{
			
		}

		public void Print()
		{

		}

		public void Sort(IComparer<Vehicle> comparator)
		{

		}
	}
}