using DevIncubator_Autopark.Engines.Base;
using DevIncubator_Autopark.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DevIncubator_Autopark.VehicleEntity
{
    public class Vehicle : IComparable<Vehicle>, IComparer<Vehicle>
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxChange = 5d;
        private const double TaxCoefficient = 30d;

        public int Id { get; }
        public VehicleType VehicleType { get; }
        public AbstractEngine VehicleEngine { get; }
        public string Model { get; }
        public string LicensePlate { get; }
        public double Weight { get; }
        public int YearIssue { get; }
        public double Mileage { get; }
        public ColorType Color { get; }
        public double TankCapacity { get; }
        public List<Rent> Rents { get; } = new List<Rent>();

        public Vehicle() { }
        public Vehicle(int id, VehicleType vehicleType, AbstractEngine vehicleEngine, string model,
            string licensePlate, double weight, int yearIssue,
            double mileage, ColorType color, double tankCapacity)
        {
            Id = id;
            VehicleType = vehicleType;
            VehicleEngine = vehicleEngine;
            Model = model;
            LicensePlate = licensePlate;
            Weight = weight;
            YearIssue = yearIssue;
            Mileage = mileage;
            Color = color;
            TankCapacity = tankCapacity;
        }

        public int CompareTo(Vehicle other)
        {
            if (other is null)
                throw new ArgumentNullException(nameof(other), "Error, argument cannot be null");

            double thisTaxCoefficient = GetCalcTaxPerMonth();
            double otherTaxCoefficient = other.GetCalcTaxPerMonth();

            return thisTaxCoefficient.CompareTo(otherTaxCoefficient);
        }

        public int Compare([AllowNull] Vehicle x, [AllowNull] Vehicle y) => x.Model.CompareTo(y.Model);

        public double GetTotalIncome()
        {
            double totalIncome = 0.0d;

            foreach (var rent in Rents)
                totalIncome += rent.RentPrice;

            return totalIncome;
        }

        public double GetTotalProfit() => GetTotalIncome() - GetCalcTaxPerMonth();

        public double GetCalcTaxPerMonth() => (Weight * WeightCoefficient) + (VehicleType.TaxCoefficient * VehicleEngine.TaxCoefficient * TaxCoefficient) + TaxChange;

        public override string ToString() => $"{VehicleType}, {VehicleEngine.TypeName}, {Model}, {LicensePlate}, {Weight}, {YearIssue}, " +
            $"{Mileage}, {Color}, {TankCapacity}, {GetCalcTaxPerMonth():0.00}";

        public override bool Equals(object obj) => obj is Vehicle otherVehicle && VehicleType == otherVehicle.VehicleType && Model == otherVehicle.Model;
    }
}