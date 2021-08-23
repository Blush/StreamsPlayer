using Domain;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Streams.Players.Mjpeg
{
	public class MjpegPlayer : IVideoPlayer
	{
		private readonly IDataProviderFactory providerFactory;
		private readonly CancellationToken cancellationToken;
		private readonly int frameBufferSize;
		private bool playVideo;

		public MjpegPlayer(IDataProviderFactory providerFactory, CancellationToken cancellationToken, int frameBufferSize)
		{
			this.providerFactory = providerFactory;
			this.cancellationToken = cancellationToken;
			this.frameBufferSize = frameBufferSize;
		}

		public event Action<Image> OnFrameReady;

		public async Task PlayAsync()
		{
			playVideo = true;
			byte[] buffer = new byte[1024 * 1024];
			var frame = new MjpegFramedata();
			using (IStreamDataProvider dataProvider = providerFactory.CreateDataProvider())
			{
				while (playVideo)
				{
					int dataLength = await dataProvider.ReadAsync(buffer, cancellationToken);
					ProcessData(frame, buffer, dataLength);
				}
			}
		}

		public void Stop()
		{
			playVideo = false;
		}

		public void ProcessData(MjpegFramedata frame, byte[] buffer, int bufferDataLength)
		{
			int bufferDataPos = 0;

			while (bufferDataPos < bufferDataLength - 1)
			{
				if (frame.Buffer == null)
				{
					FindMarkResult searhBeginingResult = FindSignedMark(buffer, frame.SignFound, MjpegMarkers.Start, bufferDataLength);

					if (searhBeginingResult.TargetFound == false)
					{
						//register if the last byte was the sign
						frame.SignFound = searhBeginingResult.SignFound;
						return;
					}

					frame.Init(frameBufferSize);

					if (searhBeginingResult.BufferIsOver)
					{
						return;
					}

					bufferDataPos = searhBeginingResult.Position + 1;
				}

				var searchEndingResult = FindSignedMark(buffer, frame.SignFound, MjpegMarkers.End, bufferDataLength, bufferDataPos);

				int copyLength = bufferDataLength - bufferDataPos;
				Array.Copy(buffer, bufferDataPos, frame.Buffer, frame.CurrentBufferPos, copyLength);
				frame.CurrentBufferPos = frame.CurrentBufferPos + copyLength;

				if (searchEndingResult.TargetFound)
				{
					FrameReady(frame);
					frame.Empty();
				}
			}
		}

		public FindMarkResult FindSignedMark(byte[] buffer, bool signFound, byte target, int dataLength, int startPosition = 0)
		{
			if(buffer == null)
			{
				throw new ArgumentNullException(nameof(buffer));
			}

			if(startPosition >= buffer.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(startPosition), $"The {nameof(startPosition)} ({startPosition}) is longer than the buffer length ({buffer.Length})");
			}

			if(dataLength > buffer.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(dataLength), $"The {nameof(dataLength)} ({dataLength}) is longer than the buffer length ({buffer.Length})");
			}

			int pos;
			for (pos = startPosition; pos < dataLength; pos++)
			{
				if (signFound)
				{
					if (buffer[pos] == target)
					{
						return new FindMarkResult { Position = pos, SignFound = signFound, TargetFound = true, BufferIsOver = pos == dataLength - 1 };
					}
					else
					{
						signFound = false;
					}
				}
				else
				{
					if(buffer[pos] == MjpegMarkers.Sign)
					{
						signFound = true;
					}
				}
			}
			return new FindMarkResult { Position = pos, SignFound = signFound, TargetFound = false, BufferIsOver = true };
		}

		public void FrameReady(MjpegFramedata frame)
		{
			if(OnFrameReady == null)
			{
				return;
			}

			Image img = null;

			using (var s = new MemoryStream(frame.Buffer, 0, frame.CurrentBufferPos))
			{
				try
				{
					img = Image.FromStream(s);
				}
				catch{}
			}

			Task.Run(() => OnFrameReady(img));
		}

	}
}
