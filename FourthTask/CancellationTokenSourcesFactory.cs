namespace FourthTask
{
	public class CancellationTokenSourcesFactory
	{
		private Dictionary<string, CancellationTokenSource> _ctsDict = new();

		public CancellationTokenSourcesFactory() { }

		public CancellationTokenSource? GetCtsForService(string serviceName)
		{
			if (_ctsDict.TryGetValue(serviceName, out var cts))
			{
				return cts;
			}

			return null;
		}

		public void CancelCtsForService(string serviceName)
		{
			if (_ctsDict.TryGetValue(serviceName, out var cts))
			{
				cts.Cancel();
				_ctsDict.Remove(serviceName);
			}
		}

		public CancellationTokenSource CreateNewCtsForService(string serviceName)
		{
			var cts = new CancellationTokenSource();
			_ctsDict.Add(serviceName, cts);
			return cts;
		}
	}
}
