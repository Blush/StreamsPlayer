namespace Streams.Players.Mjpeg
{
	public struct MjpegFramedata
	{
		public byte[] Buffer;
		public int CurrentBufferPos;
		public bool SignFound;

		public void Init(int frameBufferSize)
		{
			Buffer = new byte[frameBufferSize];
			Buffer[0] = MjpegMarkers.Sign;
			Buffer[1] = MjpegMarkers.Start;
			CurrentBufferPos = 2;
			SignFound = false;
		}

		public void Empty()
		{
			Buffer = null;
			CurrentBufferPos = 0;
			SignFound = false;
		}
	}
}
