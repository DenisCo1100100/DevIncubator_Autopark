using DevIncubator_Autopark.Engines.Base;

namespace DevIncubator_Autopark.Engines
{
    public class DieselEngine : AbstractCombustionEngine
    {
        public DieselEngine(double engineCapacity, double fuelConsumptionPer100)
            : base("Diesel", 1.2d)
        {
            EngineCapacity = engineCapacity;
            FuelConsumptionPer100 = fuelConsumptionPer100;
        }
    }
}