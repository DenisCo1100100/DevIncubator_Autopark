using DevIncubator_Autopark.Engines.Base;
using System;

namespace DevIncubator_Autopark
{
	public class Vehicle : IComparable<Vehicle>
	{
		private const double WeightCoefficient = 0.0013d;
		private const double TaxChange = 5d;
		private const double TaxCoefficient = 30d;

		public VehicleType VehicleType { get; }
		public AbstractEngine VehicleEngine { get; }
		public string Model { get; }
		public string LicensePlate { get; }
		public double Weight { get; }
		public int YearIssue { get; }
		public double Mileage { get; }
		public ColorType Color { get; }
		public double TankCapacity { get; }

		public Vehicle() { }
		public Vehicle(VehicleType vehicleType, AbstractEngine vehicleEngine, string model, 
			string licensePlate, double weight, int yearIssue, 
			double mileage, ColorType color, double tankCapacity)
		{
			VehicleType = vehicleType;
			VehicleEngine = vehicleEngine;
			Model = model;
			LicensePlate = licensePlate;
			Weight = weight;
			YearIssue = yearIssue;
			Mileage = mileage;
			Color = color;
			TankCapacity = tankCapacity;
		}

		public int CompareTo(Vehicle other)
		{
			if (other is null)
				throw new ArgumentNullException(nameof(other), "Error, argument cannot be null");

			double thisTaxCoefficient = GetCalcTaxPerMonth();
			double otherTaxCoefficient = other.GetCalcTaxPerMonth();

			return thisTaxCoefficient.CompareTo(otherTaxCoefficient);
		}

		public double GetCalcTaxPerMonth() => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * VehicleEngine.TaxCoefficient * TaxCoefficient) + TaxChange;

		public override string ToString() => $"{VehicleType}, {VehicleEngine.TypeName}, {Model}, {LicensePlate}, {Weight}, {YearIssue}, " +
			$"{Mileage}, {Color}, {TankCapacity}, {GetCalcTaxPerMonth():0.00}";

		public override bool Equals(object obj)
		{
			return obj is Vehicle otherVehicle && VehicleType == otherVehicle.VehicleType && Model == otherVehicle.Model;
		}
	}
}