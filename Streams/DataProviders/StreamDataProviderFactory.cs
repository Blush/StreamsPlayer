using Domain;

namespace Streams.DataProviders
{
	public class StreamDataProviderFactory : IDataProviderFactory
	{
		private readonly string url;
		private readonly int bufferSize;

		public StreamDataProviderFactory(string url, int bufferSize = 1024)
		{
			this.url = url;
			this.bufferSize = bufferSize;
		}

		public IStreamDataProvider CreateDataProvider()
		{
			return new StreamDataProvider(url, bufferSize);
		}
	}
}
