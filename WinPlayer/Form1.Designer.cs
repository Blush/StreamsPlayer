
namespace WinPlayer
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panAddStream = new System.Windows.Forms.Panel();
			this.tbxStreamUrl = new System.Windows.Forms.TextBox();
			this.btnAddStream = new System.Windows.Forms.Button();
			this.flPanPics = new System.Windows.Forms.FlowLayoutPanel();
			this.panAddStream.SuspendLayout();
			this.SuspendLayout();
			// 
			// panAddStream
			// 
			this.panAddStream.Controls.Add(this.tbxStreamUrl);
			this.panAddStream.Controls.Add(this.btnAddStream);
			this.panAddStream.Dock = System.Windows.Forms.DockStyle.Top;
			this.panAddStream.Location = new System.Drawing.Point(0, 0);
			this.panAddStream.Name = "panAddStream";
			this.panAddStream.Size = new System.Drawing.Size(800, 24);
			this.panAddStream.TabIndex = 0;
			// 
			// tbxStreamUrl
			// 
			this.tbxStreamUrl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbxStreamUrl.Location = new System.Drawing.Point(0, 0);
			this.tbxStreamUrl.Name = "tbxStreamUrl";
			this.tbxStreamUrl.Size = new System.Drawing.Size(681, 23);
			this.tbxStreamUrl.TabIndex = 0;
			this.tbxStreamUrl.Text = "http://200.33.20.122:2007/axis-cgi/mjpg/video.cgi";
			// 
			// btnAddStream
			// 
			this.btnAddStream.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnAddStream.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnAddStream.Location = new System.Drawing.Point(681, 0);
			this.btnAddStream.Name = "btnAddStream";
			this.btnAddStream.Size = new System.Drawing.Size(119, 24);
			this.btnAddStream.TabIndex = 1;
			this.btnAddStream.Text = "Add stream";
			this.btnAddStream.UseVisualStyleBackColor = true;
			this.btnAddStream.Click += new System.EventHandler(this.btnAddStream_Click);
			// 
			// flPanPics
			// 
			this.flPanPics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flPanPics.Location = new System.Drawing.Point(0, 24);
			this.flPanPics.Name = "flPanPics";
			this.flPanPics.Size = new System.Drawing.Size(800, 426);
			this.flPanPics.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.flPanPics);
			this.Controls.Add(this.panAddStream);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panAddStream.ResumeLayout(false);
			this.panAddStream.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panAddStream;
		private System.Windows.Forms.TextBox tbxStreamUrl;
		private System.Windows.Forms.Button btnAddStream;
		private System.Windows.Forms.FlowLayoutPanel flPanPics;
	}
}

