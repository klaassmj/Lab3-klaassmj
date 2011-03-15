using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(new DateTime(2010, 1, 1), new DateTime(2010, 1, 10), 2000);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForZeroDaySpread()
        {
            var target = new Flight(new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), 2000);
            Assert.AreEqual(200, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDaySpread()
        {
            var target = new Flight(new DateTime(2010, 1, 1), new DateTime(2010, 1, 2), 2000);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDaySpread()
        {
            var target = new Flight(new DateTime(2010, 1, 1), new DateTime(2010, 1, 3), 2000);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatHotelHasCorrectBasePriceForTenDaysSpread()
        {
            var target = new Flight(new DateTime(2010, 1, 1), new DateTime(2010, 1, 11), 2000);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatHotelThrowsOnBadNumberOfMiles()
        {
            var target = new Flight(new DateTime(2010, 1, 1), new DateTime(2010, 1, 1), -10);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatHotelThrowsOnBadDateRange()
        {
            var target = new Flight(new DateTime(2010, 1, 2), new DateTime(2010, 1, 1), 2000);
        }
	}
}
