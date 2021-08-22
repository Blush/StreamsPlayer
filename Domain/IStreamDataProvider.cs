using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
	public interface IStreamDataProvider: IDisposable
	{
		Task<int> ReadAsync(byte[] buffer, CancellationToken cancellationToken);
	}
}
