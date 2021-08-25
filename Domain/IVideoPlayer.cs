using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
	public interface IVideoPlayer
	{
		event Action<Image> OnFrameReady;

		event Action<string> OnError;

		Task PlayAsync(string url, CancellationToken cancellationToken);

		void Stop();

		bool IsPlaying { get; }
	}
}
