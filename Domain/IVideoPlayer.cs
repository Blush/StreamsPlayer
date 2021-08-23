using System;
using System.Drawing;
using System.Threading.Tasks;

namespace Domain
{
	public interface IVideoPlayer
	{
		event Action<Image> OnFrameReady;

		Task PlayAsync();

		void Stop();
	}
}
