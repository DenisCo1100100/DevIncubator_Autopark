using DevIncubator_Autopark.Engines.Base;

namespace DevIncubator_Autopark.Engines
{
	public class GasolineEngine : AbstractCombustionEngine
	{
		public GasolineEngine(double engineCapacity, double fuelConsumptionPer100)
			: base("Gasoline", 1d)
		{
			EngineCapacity = engineCapacity;
			FuelConsumptionPer100 = fuelConsumptionPer100;
		}
	}
}