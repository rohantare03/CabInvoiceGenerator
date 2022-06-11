using NUnit.Framework;
using CabGenerator;
using System.Collections.Generic;

namespace CabTestCases
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
        }
        /// <summary>
        /// UC1: Claculate the notmal ride fare
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <param name="output"></param>
        [Test]
        [TestCase(5, 3)]
        public void GivenTimeAndDistance_calculateFare(double distance, double time)
        {
            int expected = 53;
            Ride ride = new Ride(distance, time);
            Assert.AreEqual(expected, invoiceGenerator.TotalFareForSingleRideReturn(ride));
        }
        //TC1.1 : check for invalid distance
        [Test]
        public void GivenInvalidDistance_ThrowException()
        {
            Ride ride = new Ride(-1, 1);
            InvoiceGeneratorException invoiceGeneratorException = Assert.Throws<InvoiceGeneratorException>(() => invoiceGenerator.TotalFareForSingleRideReturn(ride));
            Assert.AreEqual(invoiceGeneratorException.type, InvoiceGeneratorException.ExceptionType.INVALID_DISTANCE);
        }
        //TC1.2 : check for invalid time
        [Test]
        public void GivenInvalidTime_ThrowException()
        {
            Ride ride = new Ride(1, -1);
            InvoiceGeneratorException invoiceGeneratorException = Assert.Throws<InvoiceGeneratorException>(() => invoiceGenerator.TotalFareForSingleRideReturn(ride));
            Assert.AreEqual(invoiceGeneratorException.type, InvoiceGeneratorException.ExceptionType.INVALID_TIME);
        }
        //<summary>
        //UC2: Checking for multiple rides and aggregate fare
        //</summary>
        [Test]
        public void GivenListOfRides_CalculateFareForMultipleRides()
        {
            Ride ride1 = new Ride(2, 2);
            Ride ride2 = new Ride(2, 1);

            List<Ride> rides = new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);
            Assert.AreEqual(43.0d, invoiceGenerator.TotalFareForMultipleRideReturn(rides));
        }
        //<summary>
        //UC3: Enhanced the fare by finding average fare, totalfare, number of rides
        //</summary>
        [Test]
        public void GivenListOfRides_GenerateInvoice()
        {
            Ride ride1 = new Ride(2, 2);
            Ride ride2 = new Ride(2, 1);

            List<Ride> rides = new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);
            Assert.AreEqual(43.0d, invoiceGenerator.TotalFareForMultipleRideReturn(rides));
            Assert.AreEqual(21.5d, invoiceGenerator.averagePerRide);
            Assert.AreEqual(2, invoiceGenerator.numOfRides);
        }
    }
}