using Utility;

namespace UtilityTests
{
    [TestClass]
    public class TemperatureTests
    {
        [TestMethod]
        public void TestDefaultConstruction()
        {
            Temperature temperature = new Temperature();
            Assert.AreEqual(Math.Round(temperature.Value, 2), 298.15);
        }

        [TestMethod]
        public void TestFahreheitDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Fahrenheit);
            Assert.AreEqual(Math.Round(temperature.Value, 2), 298.15);
        }

        [TestMethod]
        public void TestKelvinDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Kelvin);
            Assert.AreEqual(Math.Round(temperature.Value, 2), 298.15);
        }

        [TestMethod]
        public void TestCelsiusDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Celsius);
            Assert.AreEqual(Math.Round(temperature.Value, 2), 298.15);
        }

        [TestMethod]
        public void TestReaumerDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Reaumer);
            Assert.AreEqual(Math.Round(temperature.Value, 2), 298.15);
        }

        [TestMethod]
        public void TestRankineDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.RanKine);
            Assert.AreEqual(Math.Round(temperature.Value, 2), 298.15);
        }

        [TestMethod]
        public void TestKelvinConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Kelvin, 100.00);
            Assert.AreEqual(Math.Round(temperature.Value, 2), 100.00);
        }

        [TestMethod]
        public void TestConversions()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Kelvin, 100.00);
            Assert.AreEqual(Math.Round(temperature.Value, 2), 100.00);

        }

        [TestMethod]
        public void TestAbsoluteZero()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Kelvin, 0.00);
            Assert.AreEqual(Math.Round(temperature.Value, 2), -459.00);

        }
    }
}
