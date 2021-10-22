using System;

namespace DevIncubator_Autopark
{
	public class Vehicle : IComparable<Vehicle>
	{
		public VehicleType VehicleType { get; set; }
		public string Model { get; }
		public string LicensePlate { get; set; }
		public float Weight { get; set; }
		public int YearIssue { get; set; }
		public float Mileage { get; set; }
		public Color CarColor { get; set; }
		public float TankCapacity { get; set; }

		public Vehicle() { }
		public Vehicle(VehicleType vehicleType, string model, string licensePlate, float weight, int yearIssue, float mileage, Color carColor, float tankCapacity)
		{
			VehicleType = vehicleType;
			Model = model;
			LicensePlate = licensePlate;
			Weight = weight;
			YearIssue = yearIssue;
			Mileage = mileage;
			CarColor = carColor;
			TankCapacity = tankCapacity;
		}

		public int CompareTo(Vehicle other)
		{
			double thisTaxCoefficient = VehicleType.TaxCoefficient;
			double otherTaxCoefficient = other.VehicleType.TaxCoefficient;

			if (thisTaxCoefficient < otherTaxCoefficient)
				return -1;
			else
				return thisTaxCoefficient == otherTaxCoefficient ? 0 : 1;
		}

		public double GetCalcTaxPerMonth() => (Weight * 0.0013) + (VehicleType.TaxCoefficient * 30) + 5;

		public override string ToString() => $"{VehicleType}, {Model}, {LicensePlate}, {Weight}, {YearIssue}, {Mileage}, {CarColor}, {TankCapacity}, {this.GetCalcTaxPerMonth()}";
	}
}