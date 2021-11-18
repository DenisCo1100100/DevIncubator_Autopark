using System;

namespace DevIncubator_Autopark
{
    public class Rent
    {
        public Rent(DateTime rentDate, double rentPrice)
        {
            RentDate = rentDate;
            RentPrice = rentPrice;
        }

        public DateTime RentDate { get; }
        public double RentPrice { get; }
    }
}