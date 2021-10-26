namespace DevIncubator_Autopark.Engines.Base
{
	public class CombustionEngine : Engine
	{
		public double EngineCapacity{ get; protected set; }
		public double FuelConsumptionPer100 { get; protected set; }

		public CombustionEngine(string typeName, float taxCoefficient)
			: base(typeName, taxCoefficient) { }

		public double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * 100 / FuelConsumptionPer100;
	}
}