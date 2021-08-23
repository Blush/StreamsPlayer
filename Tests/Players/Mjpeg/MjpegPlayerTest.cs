using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using NUnit.Framework;
using Streams.DataProviders;
using Streams.Players.Mjpeg;
using Moq;
using Tests.TestClasses;
using System.Drawing;
using System.IO;

namespace Tests.Players.Mjpeg
{
	public class MjpegPlayerTest
	{
		private const byte DataByte = 0xD7;
		//byte[] dataArray = new[] { DataByte, DataByte, MjpegMarkers.Sign, MjpegMarkers.Start, DataByte, DataByte, MjpegMarkers.Sign, MjpegMarkers.End, DataByte };

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void FindSignedMark_FoundBeginning()
		{
			var dataArray = GetDataArray(2, 3);
			var player = GetPlayer(dataArray, 1024);

			Assert.IsNotNull(player);

			var result = player.FindSignedMark(dataArray, false, MjpegMarkers.Start, dataArray.Length, 0);
			Assert.AreEqual(true, result.TargetFound);
			Assert.AreEqual(false, result.BufferIsOver);
			Assert.AreEqual(3, result.Position);
		}

		[Test]
		public void FindSignedMark_FoundEnding()
		{
			var dataArray = GetDataArray(2, 3);
			var player = GetPlayer(dataArray, 1024);

			Assert.IsNotNull(player);

			var result = player.FindSignedMark(dataArray, false, MjpegMarkers.End, dataArray.Length, 0);
			Assert.AreEqual(true, result.TargetFound);
			Assert.AreEqual(false, result.BufferIsOver);
			Assert.AreEqual(dataArray.Length - 3, result.Position);
		}


		[Test]
		public async Task ProcessData_FoundEnding()
		{
			var dataArray = GetDataArray(2, 3);
			var player = GetPlayer(dataArray, 1024);

			Assert.IsNotNull(player);

			MjpegFramedata frame = new MjpegFramedata();

			int counter = 0;

			player.OnFrameReady += (Image image) => 			{
				counter++;
				player.Stop();
				Assert.IsNotNull(image);
			};

			await player.PlayAsync();

			Assert.AreEqual(1, counter);
			Assert.IsFalse(player.IsPlaying);

			//Thread.Sleep(100);
			//Assert.AreEqual(true, result.TargetFound);
			//Assert.AreEqual(false, result.BufferIsOver);
			//Assert.AreEqual(7, result.Position);
		}

		private void Player_OnFrameReady(Image obj)
		{
			throw new NotImplementedException();
		}

		private byte[] GetDataArray(int addNoiseAtBegining = 0, int addNoiseAtEnding = 0)
		{
			Bitmap bmp = new Bitmap(1,1);
			bmp.SetPixel(0,0, Color.Black);
			return GetDataArray(bmp, addNoiseAtBegining, addNoiseAtEnding);
		}

		private byte[] GetDataArray(Image image, int addNoiseAtBegining = 0, int addNoiseAtEnding = 0)
		{
			byte[] imageArr;
			using (MemoryStream ms = new MemoryStream())
			{
				image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
				imageArr = ms.ToArray();
			}

			if (addNoiseAtBegining + addNoiseAtEnding == 0)
			{
				return imageArr;
			}

			var noisedArr = new byte[imageArr.Length + addNoiseAtBegining + addNoiseAtEnding];

			Array.Fill(noisedArr, DataByte, 0, addNoiseAtBegining);
			Array.Copy(imageArr, 0, noisedArr, addNoiseAtBegining, imageArr.Length);
			Array.Fill(noisedArr, DataByte, addNoiseAtBegining + imageArr.Length, addNoiseAtEnding);
			return noisedArr;
		}

		private IDataProviderFactory GetProviderFactory(byte[] dataArray, int bufferSize)
		{
			Mock<IDataProviderFactory> mockFactory = new Mock<IDataProviderFactory>();
			mockFactory.Setup(it => it.CreateDataProvider()).Returns(new TestDataProvider(dataArray, bufferSize));
			return mockFactory.Object;
		}

		private MjpegPlayer GetPlayer(byte[] dataArray, int bufferSize)
		{
			IDataProviderFactory providerFactory = GetProviderFactory(dataArray, bufferSize);
			return GetPlayer(providerFactory, bufferSize);
		}

		private MjpegPlayer GetPlayer(IDataProviderFactory providerFactory, int bufferSize)
		{
			CancellationToken cancellationToken = CancellationToken.None;
			return new MjpegPlayer(providerFactory, cancellationToken, bufferSize);
		}
	}
}
