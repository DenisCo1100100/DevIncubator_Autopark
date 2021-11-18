using System;

namespace DevIncubator_Autopark.Types
{
    public class VehicleType
    {
        public int Id { get; }

        public VehicleType()
        {
            TypeName = "Vehicle";
            TaxCoefficient = 1d;
        }

        public VehicleType(int id, string typeName, double taxCoefficient = 1d)
        {
            Id = id;
            TypeName = typeName;
            TaxCoefficient = taxCoefficient;
        }

        public string TypeName { get; set; }
        public double TaxCoefficient { get; set; }

        public void Display()
        {
            Console.WriteLine($"TypeName = {TypeName}");
            Console.WriteLine($"TaxCoefficient = {TaxCoefficient}");
        }

        public override string ToString() => $"{TypeName}, \"{TaxCoefficient}\"";
    }
}