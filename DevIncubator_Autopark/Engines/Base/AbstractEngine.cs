namespace DevIncubator_Autopark.Engines.Base
{
	public abstract class AbstractEngine
	{
		public string TypeName { get; }
		public double TaxCoefficient { get; }

		public AbstractEngine(string typeName, double taxCoefficient)
		{
			TypeName = typeName;
			TaxCoefficient = taxCoefficient;
		}

		public abstract double GetMaxKilometers(double fuelTank);
	}
}