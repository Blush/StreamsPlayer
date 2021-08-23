using Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.TestClasses
{
	public class TestDataProvider : IStreamDataProvider, IDisposable
	{
		private Stream stream;
		private readonly int bufferSize;

		public TestDataProvider(byte[] dataArray, int bufferSize = 1024)
		{
			stream = new MemoryStream(dataArray, false);
			this.bufferSize = bufferSize;
		}

		public async Task<int> ReadAsync(byte[] buffer, CancellationToken cancellationToken)
		{
			try
			{
				return await stream.ReadAsync(buffer, 0, bufferSize, cancellationToken);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public void Dispose()
		{
			if (stream != null)
			{
				stream.Dispose();
			}
		}


	}
}
