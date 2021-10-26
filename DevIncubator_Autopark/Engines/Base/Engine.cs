namespace DevIncubator_Autopark.Engines.Base
{
	public class Engine
	{
		public string TypeName { get; }
		public float TaxCoefficient { get; }

		public Engine(string typeName, float taxCoefficient)
		{
			TypeName = typeName;
			TaxCoefficient = taxCoefficient;
		}
	}
}