using Utility;

namespace UtilityTests
{
    [TestClass]
    public class TemperatureTests
    {
        #region Test Default Construction

        [TestMethod]
        public void TestDefaultConstruction()
        {
            Temperature temperature = new Temperature();
            
            Assert.AreEqual(298.15, Math.Round(temperature.Value, 2));
        }

        [TestMethod]
        public void TestFahreheitDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Fahrenheit);
            
            Assert.AreEqual(298.15, Math.Round(temperature.Value, 2));
        }

        [TestMethod]
        public void TestKelvinDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Kelvin);
            
            Assert.AreEqual(298.15, Math.Round(temperature.Value, 2));
        }

        [TestMethod]
        public void TestCelsiusDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Celsius);
            
            Assert.AreEqual(298.15, Math.Round(temperature.Value, 2));
        }

        [TestMethod]
        public void TestReaumerDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Reaumer);
            
            Assert.AreEqual(298.15, Math.Round(temperature.Value, 2));
        }

        [TestMethod]
        public void TestRankineDefaultConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.RanKine);
            
            Assert.AreEqual(298.15, Math.Round(temperature.Value, 2));
        }

        #endregion Test Default Construction

        [TestMethod]
        public void TestKelvinConstruction()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Kelvin, 100.00);
            
            Assert.AreEqual(100.00, Math.Round(temperature.Value, 2));
        }

        [TestMethod]
        public void TestConversions()
        {
            Temperature temperature = new Temperature(Temperature.SystemOfMeasure.Celsius, 100.00);
            
            Assert.AreEqual(671.67, Math.Round(temperature.InRanKine, 2), "converting Celsius to RanKine");
            Assert.AreEqual(180, Math.Round(temperature.InReaumer, 2), "converting Celsius to Reaumer");
            Assert.AreEqual(212.00, Math.Round(temperature.InFarherheit, 2), "converting Celsius to Fahrenheit");
            Assert.AreEqual(373.15, Math.Round(temperature.InKelvin, 2), "converting Celsius to Kelvin");

            Assert.AreEqual(671.67, Math.Round(Temperature.Convert(temperature.Value, Temperature.SystemOfMeasure.Celsius, Temperature.SystemOfMeasure.RanKine), 2), "converting Celsius to RanKine");
            Assert.AreEqual(180, Math.Round(Temperature.Convert(temperature.Value, Temperature.SystemOfMeasure.Celsius, Temperature.SystemOfMeasure.Reaumer), 2), "converting Celsius to Reaumer");
            Assert.AreEqual(212.00, Math.Round(Temperature.Convert(temperature.Value, Temperature.SystemOfMeasure.Celsius, Temperature.SystemOfMeasure.Fahrenheit), 2), "converting Celsius to Fahrenheit");
            Assert.AreEqual(373.15, Math.Round(Temperature.Convert(temperature.Value, Temperature.SystemOfMeasure.Celsius, Temperature.SystemOfMeasure.Kelvin), 2), "converting Celsius to Kelvin");
        }

        [TestMethod]
        public void TestAbsoluteZero()
        {
            Temperature temperature = Temperature.AbsoluteZero;
            
            Assert.AreEqual(0.0, Math.Round(temperature.InKelvin, 2), 0.00, "absolute zero in Kelvin");
            Assert.AreEqual(-459.67, Math.Round(temperature.InFarherheit, 2), "absolute zero in Fahrenheit");
            Assert.AreEqual(0.00, Math.Round(temperature.InRanKine, 2), "absolute zero in RanKine");
            Assert.AreEqual(-273.15, Math.Round(temperature.InCelsius, 2), "absolute zero in Celsius");
            Assert.AreEqual(-491.67, Math.Round(temperature.InReaumer, 2), "absolute zero in Reaumer");
        }
    }
}
