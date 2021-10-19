using System;

namespace DevIncubator_Autopark
{
	public class VehicleType
	{
		public VehicleType()
		{
			TypeName = "Vehicle";
			TaxCoefficient = 1f;
		}

		public VehicleType(string typeName, float taxCoefficient = 1f)
		{
			TypeName = typeName;
			TaxCoefficient = taxCoefficient;
		}

		public string TypeName { get; set; }
		public float TaxCoefficient { get; set; }

		public void Display()
		{
			Console.WriteLine($"TypeName = {TypeName}");
			Console.WriteLine($"TaxCoefficient = {TaxCoefficient}");
		}

		public override string ToString() => $"{TypeName}, \"{TaxCoefficient}\"";
	}
}