using NUnit.Framework;
using CabGenerator;

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
    }
}