using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabGenerator
{
    public class InvoiceGenerator
    {
        public int pricePerKilometer;
        public int pricePerMinute;
        public int MinimumFare;
        public int TotalFare;
        public InvoiceGenerator()
        {
            this.pricePerKilometer = 10;
            this.pricePerMinute = 1;
            this.MinimumFare = 5;
        }       
        public double TotalFareForSingleRideReturn(Ride ride)
        {
            if (ride.distance < 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
            }
            if (ride.time < 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.ExceptionType.INVALID_TIME, "Invalid Time");
            }
            return Math.Max(MinimumFare, ride.distance * pricePerKilometer + ride.time * pricePerMinute);
        }
    }
}
