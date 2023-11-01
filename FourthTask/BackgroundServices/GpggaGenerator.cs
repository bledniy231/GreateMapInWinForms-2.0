using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace FourthTask.BackgroundServices
{
	public class GpggaGenerator : BackgroundService
	{
		private static Random random = new();
		private readonly IServiceProvider _serviceProvider;
		private readonly NmeaParser _nmeaParser;
		private readonly CancellationTokenSource _cancellationTokenSource;

		public GpggaGenerator(
			IServiceProvider serviceProvider, 
			NmeaParser nmeaParser,
			CancellationTokenSourcesFactory ctsFactory)
		{
			_serviceProvider = serviceProvider;
			_nmeaParser = nmeaParser;
			_cancellationTokenSource = ctsFactory.CreateNewCtsForService(nameof(GpggaGenerator));
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			await Task.Delay(5000, stoppingToken); // Маркет начнёт двигаться не сразу же после запуска приложения

			while (!_cancellationTokenSource.Token.IsCancellationRequested)
			{
				if (_serviceProvider.GetService(typeof(MainForm)) is MainForm mainForm)
				{
					(double? latitude, double? longitude) = mainForm.GetMarkerCoordsFromGpggaOverlay();
					if (latitude == null || longitude == null)
					{
						return;
					}

					string gpgga = GenerateGpgga((double)latitude, (double)longitude);
					var result = _nmeaParser.ParseGpgga(gpgga);
					mainForm.SetNewMarkerCoordsForGpggaOverlay(result.Latitude, result.Longitude);
				}

				await Task.Delay(2000, stoppingToken);
			}
		}

		private string GenerateGpgga(double latitude, double longitude)
		{
			latitude += (random.NextDouble() - 0.5) * 0.0006;
			longitude += (random.NextDouble() - 0.5) * 0.0006;

			var latitudeStr = latitude > 0 
				? $"{latitude.ToString("F6", CultureInfo.InvariantCulture)},N" 
				: $"{(-latitude).ToString("F6", CultureInfo.InvariantCulture):F6},S";

			var longitudeStr = longitude > 0 
				? $"{longitude.ToString("F6", CultureInfo.InvariantCulture):F6},E" 
				: $"{(-longitude).ToString("F6", CultureInfo.InvariantCulture):F6},W";

			var utcTime = DateTime.UtcNow.ToString("HHmmss", CultureInfo.InvariantCulture);
			var horizontalDilution = random.NextDouble().ToString("F1", CultureInfo.InvariantCulture); // Горизонтальная дилетантность
			var altitude = random.Next(0, 100).ToString(); // Высота
			var geoidHeight = random.Next(-100, 100).ToString(); // Геоидная высота

			var gpggaMessage = $"$GPGGA,{utcTime},{latitudeStr},{longitudeStr},\"1\",\"4\",{horizontalDilution},{altitude},\"M\",{geoidHeight},\"M\",\"\",\"\"";
			var checksum = CalculateChecksum(gpggaMessage);

			return $"{gpggaMessage}*{checksum}";
		}

		private string CalculateChecksum(string sentence)
		{
			byte checksum = 0;
			foreach (var c in sentence)
			{
				if (c == '$')
				{
					// Начало сообщения
					checksum = 0;
				}
				else if (c == '*')
				{
					// Конец сообщения
					break;
				}
				else
				{
					// XOR байта с имеющимся контрольным значением
					checksum ^= (byte)c;
				}
			}
			return checksum.ToString("X2");
		}
	}
}
