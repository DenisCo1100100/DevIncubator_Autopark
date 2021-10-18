using System;

namespace DevIncubator_Autopark
{
	class VehicleType
	{
		private string _typeName;
		private float _taxCoefficient;

		public VehicleType()
		{
			_typeName = "Vehicle";
			_taxCoefficient = 1f;
		}

		public VehicleType(string typeName, float taxCoefficient = 1f)
		{
			_typeName = typeName;
			_taxCoefficient = taxCoefficient;
		}

		public string TypeName 
		{
			get => _typeName;
			set => _typeName = value;
		}

		public float TaxCoefficient 
		{
			get => _taxCoefficient;
			set => _taxCoefficient = value;
		}

		public void Display()
		{
			Console.WriteLine($"TypeName = {_typeName}");
			Console.WriteLine($"TaxCoefficient = {_taxCoefficient}");
		}

		public override string ToString() => $"{_typeName}, \"{_taxCoefficient}\"";
	}
}
