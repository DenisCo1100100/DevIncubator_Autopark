namespace DevIncubator_Autopark.Engines.Base
{
	public class Engine
	{
		public string TypeName { get; }
		public double TaxCoefficient { get; }

		public Engine(string typeName, double taxCoefficient)
		{
			TypeName = typeName;
			TaxCoefficient = taxCoefficient;
		}
	}
}