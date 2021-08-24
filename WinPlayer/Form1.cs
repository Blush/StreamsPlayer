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
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnActivated(EventArgs e)
		{
			base.OnActivated(e);


		}

		private void btnAddStream_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(tbxStreamUrl.Text))
				return;

			MjpegPlayer player = null; ;
			PictureBox pictureBox = new PictureBox();
			try
			{
				StreamDataProviderFactory providerFactory = new StreamDataProviderFactory(tbxStreamUrl.Text);
				CancellationTokenSource tokenSource = new CancellationTokenSource();
				player = new MjpegPlayer(providerFactory, tokenSource.Token, 1024 * 1024);

				player.OnFrameReady += (Image img) => { pictureBox.Image = img; };
				pictureBox.DoubleClick += (object sender, EventArgs e) => { player.Stop(); flPanPics.Controls.Remove(pictureBox); };

				flPanPics.Controls.Add(pictureBox);
				Task.Run(async () => await player.PlayAsync());
			}
			catch(Exception ex)
			{
				if(pictureBox != null && flPanPics.Contains(pictureBox))
				{
					flPanPics.Controls.Remove(pictureBox);
				}

				if(player?.IsPlaying == true)
				{
					player.Stop();
				}

				MessageBox.Show(ex.Message);
			}


			//http://86.127.235.69/mjpg/video.mjpg
			//http://200.33.20.122:2007/axis-cgi/mjpg/video.cgi
			//http://webcam1.lpl.org/axis-cgi/mjpg/video.cgi

		}

	}
}
