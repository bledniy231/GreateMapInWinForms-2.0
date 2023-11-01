using System.Globalization;

namespace FourthTask
{
	public class NmeaParser
	{
		public (double Latitude, double Longitude) ParseGpgga(string nmeaSentence)
		{
			if (!nmeaSentence.StartsWith("$GPGGA"))
			{
				throw new ArgumentException("Invalid NMEA sentence format");
			}

			string[] parts = nmeaSentence.Split(',');

			if (parts.Length < 7)
			{
				throw new ArgumentException("Invalid GPGGA sentence format");
			}

			double latitude = ParseLatitude(parts[2], parts[3]);
			double longitude = ParseLongitude(parts[4], parts[5]);

			return (latitude, longitude);
		}

		private double ParseLatitude(string value, string hemisphere)
		{
			double latitude = double.Parse(value, CultureInfo.InvariantCulture);
			if (hemisphere == "S")
			{
				latitude = -latitude;
			}

			return latitude;
		}

		private double ParseLongitude(string value, string hemisphere)
		{
			double longitude = double.Parse(value, CultureInfo.InvariantCulture);
			if (hemisphere == "W")
			{
				longitude = -longitude;
			}

			return longitude;
		}
	}
}
