using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly DateTime StartDate = new DateTime(2009, 11, 1);
        private readonly DateTime EndDate = new DateTime(2009, 11, 30);
        private readonly DateTime StartDateSameDay = new DateTime(2009, 11, 1);
        private readonly DateTime EndDateSameDay = new DateTime(2009, 11, 2);
        private readonly DateTime StartDate2Day = new DateTime(2009, 11, 1);
        private readonly DateTime EndDate2Day = new DateTime(2009, 11, 3);
        private readonly DateTime StartDate10Day = new DateTime(2009, 11, 1);
        private readonly DateTime EndDate10Day = new DateTime(2009, 11, 11);
        private readonly int miles = 25;
        [Test()]
        public void TestThatFlightnitializes()
        {
            var target = new Flight(StartDate, EndDate, miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {

            var target = new Flight(StartDateSameDay, EndDateSameDay, 25);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            var target = new Flight(StartDate2Day, EndDate2Day, 100);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlight()
        {
            var target = new Flight(StartDate10Day, EndDate10Day, 500);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadLength()
        {
            new Flight(StartDate, EndDate, -5);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(EndDate, StartDate, 5);
        }

        [Test()]
        public void TestThatEqualsWorks()
        {
            Flight f1 = new Flight(StartDate, EndDate, 10);
            Flight f2 = new Flight(StartDate, EndDate, 10);
            Assert.AreEqual(f1, f2);
        }
	}
}
