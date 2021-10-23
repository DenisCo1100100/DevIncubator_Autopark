using System;

namespace DevIncubator_Autopark
{
	public class Vehicle : IComparable<Vehicle>
	{
		private const float WeightCoefficient = 0.0013f;
		private const float TaxChange = 5f;
		private const float TaxCoefficient = 30f;

		public VehicleType VehicleType { get; set; }
		public string Model { get; }
		public string LicensePlate { get; set; }
		public float Weight { get; set; }
		public int YearIssue { get; set; }
		public float Mileage { get; set; }
		public ColorType Color { get; set; }
		public float TankCapacity { get; set; }

		public Vehicle() { }
		public Vehicle(VehicleType vehicleType, string model, string licensePlate, float weight, int yearIssue, float mileage, ColorType color, float tankCapacity)
		{
			VehicleType = vehicleType;
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

		public double GetCalcTaxPerMonth() => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * TaxCoefficient) + TaxChange;

		public override string ToString() => $"{VehicleType}, {Model}, {LicensePlate}, {Weight}, {YearIssue}, {Mileage}, {Color}, {TankCapacity}, {GetCalcTaxPerMonth():0.00}";
	}
}