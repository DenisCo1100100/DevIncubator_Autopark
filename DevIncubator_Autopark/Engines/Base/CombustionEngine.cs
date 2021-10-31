namespace DevIncubator_Autopark.Engines.Base
{
	public class CombustionEngine : Engine
	{
		private const double OneHundredPercent = 100d;

		public double EngineCapacity{ get; protected set; }
		public double FuelConsumptionPer100 { get; protected set; }

		public CombustionEngine(string typeName, double taxCoefficient)
			: base(typeName, taxCoefficient) { }

		public double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * OneHundredPercent / FuelConsumptionPer100;
	}
}