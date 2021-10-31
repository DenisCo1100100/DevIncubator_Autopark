using System;

namespace DevIncubator_Autopark
{
	public class VehicleType
	{
		public VehicleType()
		{
			TypeName = "Vehicle";
			TaxCoefficient = 1d;
		}

		public VehicleType(string typeName, double taxCoefficient = 1d)
		{
			TypeName = typeName;
			TaxCoefficient = taxCoefficient;
		}

		public string TypeName { get; set; }
		public double TaxCoefficient { get; set; }

		public void Display()
		{
			Console.WriteLine($"TypeName = {TypeName}");
			Console.WriteLine($"TaxCoefficient = {TaxCoefficient}");
		}

		public override string ToString() => $"{TypeName}, \"{TaxCoefficient}\"";
	}
}