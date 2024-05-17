namespace Utility
{
    /// <summary>
    /// Summary description for Temperature.
    /// </summary>
    public class Temperature
	{
		public enum SystemOfMeasure { Fahrenheit = 0, Celsius, Kelvin, RanKine, Reaumer };

		private SystemOfMeasure _systemOfMeasure;
		public SystemOfMeasure Scale
		{
			get { return _systemOfMeasure; }
			set { _systemOfMeasure = value; }
		}

		private double _temperatureKelvin;
		public double Value
		{
			get { return Temperature.Convert(_temperatureKelvin, SystemOfMeasure.Kelvin, _systemOfMeasure); }
			set { this._temperatureKelvin = Temperature.Convert(value, _systemOfMeasure, SystemOfMeasure.Kelvin); }
		}

        #region Public Properties

        public static Temperature AbsoluteZero
		{
			get { return new Temperature(SystemOfMeasure.Kelvin, 0); }
		}

        public double InKelvin
        {
            get { return this._temperatureKelvin; }
        }

        public double InFarherheit
        {
            get { return Temperature.Convert(this._temperatureKelvin, SystemOfMeasure.Kelvin, SystemOfMeasure.Fahrenheit); }
        }

        public double InRanKine
        {
            get { return Temperature.Convert(this._temperatureKelvin, SystemOfMeasure.Kelvin, SystemOfMeasure.RanKine); }
        }

        public double InReaumer
        {
            get { return Temperature.Convert(this._temperatureKelvin, SystemOfMeasure.Kelvin, SystemOfMeasure.Reaumer); }
        }

        public double InCelsius
        {
            get { return Temperature.Convert(this._temperatureKelvin, SystemOfMeasure.Kelvin, SystemOfMeasure.Celsius); }
        }

        #endregion Public Properties

        #region Construction

        public Temperature()
			: this(SystemOfMeasure.Kelvin, 298.15F)
		{
			// SI temperature at standard state in Kelvin.
		}

		public Temperature(SystemOfMeasure systemOfMeasure)
			: this(systemOfMeasure, 298.15F)
		{
			// SI temperature at standard state.
		}

		public Temperature(double temperature)
			: this(SystemOfMeasure.Kelvin, temperature)
		{
		}

		public Temperature(SystemOfMeasure systemOfMeasure, double temperature)
		{
			_systemOfMeasure = systemOfMeasure;
			Value = temperature;
		}

        #endregion Construction


        #region Public Methods

        public static double Convert(Temperature temperature, SystemOfMeasure originSystem, SystemOfMeasure targetSystem)
		{
			return Temperature.Convert(temperature.Value, originSystem, targetSystem);
		}

        public static double Convert(double temperature, SystemOfMeasure originSystem, SystemOfMeasure targetSystem)
		{
			// Convert to Kelvin.
			double temperatureKelvin;
			switch (originSystem)
			{
				case SystemOfMeasure.Fahrenheit:
					temperatureKelvin = (5F / 9F) * (temperature - 32) + 273.15F;
					break;

				case SystemOfMeasure.Celsius:
					temperatureKelvin = temperature + 273.15F;
					break;

				case SystemOfMeasure.Kelvin:
					temperatureKelvin = temperature;
					break;

				case SystemOfMeasure.Reaumer:
					temperatureKelvin = (5F / 9F) * temperature + 273.15F;
					break;

				case SystemOfMeasure.RanKine:
					temperatureKelvin = temperature / 1.8F;
					break;

				default:
					throw new ArgumentOutOfRangeException("originSystem", originSystem, "Unsupported origin system of measure");
			}

			// Convert to the new system.
			double resultTemperature;
			switch (targetSystem)
			{
				case SystemOfMeasure.Fahrenheit:
					resultTemperature = 32F + (1.8F) * (temperatureKelvin - 273.15F);
					break;

				case SystemOfMeasure.Celsius:
					resultTemperature = temperatureKelvin - 273.15F;
					break;

				case SystemOfMeasure.Kelvin:
					resultTemperature = temperatureKelvin;
					break;

				case SystemOfMeasure.Reaumer:
					resultTemperature = (1.8F) * (temperatureKelvin - 273.15F);
					break;

				case SystemOfMeasure.RanKine:
					resultTemperature = temperatureKelvin * 1.8F;
					break;

				default:
					throw new ArgumentOutOfRangeException("originSystem", originSystem, "Unsupported target system of measure");
			}

			return resultTemperature;
		}

		public static string GetUnitAbbreviation(SystemOfMeasure systemOfMeasure)
		{
			switch (systemOfMeasure)
			{
				case SystemOfMeasure.Fahrenheit:
					return "°F";

				case SystemOfMeasure.Celsius:
					return "°C";

				case SystemOfMeasure.Kelvin:
					return "°K";

				case SystemOfMeasure.Reaumer:
					return "°Re";

				case SystemOfMeasure.RanKine:
					return "°Ra";

				default:
					throw new ArgumentOutOfRangeException("systemOfMeasure", systemOfMeasure, "Unsupported system of measure");
			}
		}

		// TODO: Add methods for adding/subracting temperatures.

		#endregion Public Methods
    }
}
