using Streams.DataProviders;
using Streams.Players.Mjpeg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPlayer
{
	public partial class Form1 : Form
	{
		private MjpegPlayer player;
		public Form1()
		{
			InitializeComponent();

			//http://86.127.235.69/mjpg/video.mjpg
			//http://200.33.20.122:2007/axis-cgi/mjpg/video.cgi
			//http://webcam1.lpl.org/axis-cgi/mjpg/video.cgi
			StreamDataProviderFactory providerFactory = new StreamDataProviderFactory("http://200.33.20.122:2007/axis-cgi/mjpg/video.cgi");
			CancellationTokenSource tokenSource = new CancellationTokenSource();
			player = new MjpegPlayer(providerFactory, tokenSource.Token, 1024*1024);

			player.OnFrameReady += Player_OnFrameReady;
			Task.Run(async () => await player.PlayAsync());
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);


		}

		private void Player_OnFrameReady(Image obj)
		{
			pictureBox1.Image = obj;
		}
	}
}
