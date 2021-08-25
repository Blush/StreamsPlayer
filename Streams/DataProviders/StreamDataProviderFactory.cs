using Domain;

namespace Streams.DataProviders
{
	public class StreamDataProviderFactory : IDataProviderFactory
	{
		public StreamDataProviderFactory()
		{
		}

		public IStreamDataProvider CreateDataProvider(string url, int bufferSize = 1024)
		{
			return new StreamDataProvider(url, bufferSize);
		}
	}
}
