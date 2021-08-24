using Streams.DataProviders;
using Streams.Players.Mjpeg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPlayer
{
	public partial class Form1 : Form
	{
		private Stack<string> exampleUrls = new Stack<string>(new[]
		{   "http://86.127.235.69/mjpg/video.mjpg",
			"http://200.33.20.122:2007/axis-cgi/mjpg/video.cgi",
			"http://webcam1.lpl.org/axis-cgi/mjpg/video.cgi"
		});

		public Form1()
		{
			InitializeComponent();
			tbxStreamUrl.Text = exampleUrls.Pop();
		}

		private void btnAddStream_Click(object sender, EventArgs e)
		{
			string url = tbxStreamUrl.Text;
			if (string.IsNullOrWhiteSpace(url))
				return;

			MjpegPlayer player = null; ;
			PictureBox pictureBox = new PictureBox();
			pictureBox.Width = 800;
			pictureBox.Height = 600;
			pictureBox.BackColor = Color.AliceBlue;
			try
			{
				StreamDataProviderFactory providerFactory = new StreamDataProviderFactory(url);
				CancellationTokenSource tokenSource = new CancellationTokenSource();
				player = new MjpegPlayer(providerFactory, tokenSource.Token, 1024 * 1024);

				bool resized = false;
				player.OnFrameReady += (Image img) =>
				{
					pictureBox.Image = img;
					if(resized == false)
					{
						pictureBox.Invoke(new Action(() =>
						{
							pictureBox.Width = img.Width;
							pictureBox.Height = img.Height;
						}));
						resized = true;
					}
				};

				player.OnError += (string message) =>
				{
					lblMessage.Invoke(new Action(() => 
					{
						lblMessage.Text = $"Something went wrong and stream from URL {url} was stopped due to reasone: {message}";
						flPanPics.Controls.Remove(pictureBox);
					}));
				};

				pictureBox.DoubleClick += (object sender, EventArgs e) => 
				{
					player.Stop();
					flPanPics.Controls.Remove(pictureBox);
					lblMessage.Text = $"Removed stream from URL {url}";
				};
				flPanPics.Controls.Add(pictureBox);
				Task.Run(() => player.PlayAsync());
				
				lblMessage.Text = $"Stream {url} was added to play. Double click to the video to remove.";
				tbxStreamUrl.Text = exampleUrls.Any() ? exampleUrls.Pop() : String.Empty;
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
		}

		private void panAddStream_Resize(object sender, EventArgs e)
		{
			
		}
	}
}
