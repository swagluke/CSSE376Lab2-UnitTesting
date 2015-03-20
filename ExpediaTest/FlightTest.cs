using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private DateTime startDate = new DateTime(2015, 03, 18);
        private DateTime endDate = new DateTime(2015, 03, 20);
        private int Miles = 7050;
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(startDate,endDate,Miles);
            Assert.IsNotNull(target);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadstartendDate()
        {
            startDate = new DateTime(2015, 03, 20);
            endDate = new DateTime(2015, 03, 18);
            new Flight(startDate, endDate, Miles);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadmiles()
        {
            Miles = -7050;
            new Flight(startDate, endDate, Miles);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayTrip()
        {
            startDate = new DateTime(2015, 03, 19);
            endDate = new DateTime(2015, 03, 20);
            var target = new Flight(startDate, endDate, Miles);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayTrip()
        {
            startDate = new DateTime(2015, 03, 19);
            endDate = new DateTime(2015, 03, 29);
            var target = new Flight(startDate, endDate, Miles);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneYearTrip()
        {
            startDate = new DateTime(2014, 03, 19);
            endDate = new DateTime(2015, 03, 19);
            var target = new Flight(startDate, endDate, Miles);
            Assert.AreEqual(7500, target.getBasePrice());
        }
	}
}
