using DevIncubator_Autopark.Engines.Base;

namespace DevIncubator_Autopark.Engines
{
	public class ElectricalEngine : Engine
	{
		public float ElectricityConsumption { get; }

		public ElectricalEngine(float electricityConsumption)
			: base("Electrical", 0.1f)
		{
			ElectricityConsumption = electricityConsumption;
		}

		public double GetMaxKilometers(double batterySize) => batterySize / ElectricityConsumption;
	}
}