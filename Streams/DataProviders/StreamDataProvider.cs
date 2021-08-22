using Domain;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Streams.DataProviders
{
	public class StreamDataProvider : IStreamDataProvider, IDisposable
	{
		private HttpClient httpClient;
		private Stream stream;
		private readonly string url;
		private readonly int bufferSize;

		public StreamDataProvider(string url, int bufferSize = 1024)
		{
			httpClient = new HttpClient();
			this.url = url;
			this.bufferSize = bufferSize;
		}

		public async Task<int> ReadAsync(byte[] buffer, CancellationToken cancellationToken)
		{
			try
			{
				await Init();
				return await stream.ReadAsync(buffer, 0, bufferSize, cancellationToken);
			}
			catch(Exception ex)
			{
				throw;
			}
		}

		public void Dispose()
		{
			if( stream != null)
			{
				stream.Dispose();
			}

			if (httpClient != null)
			{
				httpClient.Dispose();
			}
		}

		private async Task Init()
		{
			if(stream == null)
				stream = await httpClient.GetStreamAsync(url);
		}
	}
}
