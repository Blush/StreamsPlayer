
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
			this.flPanPics = new System.Windows.Forms.FlowLayoutPanel();
			this.btnAddStream = new System.Windows.Forms.Button();
			this.tbxStreamUrl = new System.Windows.Forms.TextBox();
			this.lblMessage = new System.Windows.Forms.Label();
			this.panAddStream = new System.Windows.Forms.Panel();
			this.panAddStream.SuspendLayout();
			this.SuspendLayout();
			// 
			// flPanPics
			// 
			this.flPanPics.AutoScroll = true;
			this.flPanPics.AutoSize = true;
			this.flPanPics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flPanPics.Location = new System.Drawing.Point(0, 72);
			this.flPanPics.Name = "flPanPics";
			this.flPanPics.Size = new System.Drawing.Size(982, 386);
			this.flPanPics.TabIndex = 1;
			// 
			// btnAddStream
			// 
			this.btnAddStream.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddStream.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnAddStream.Location = new System.Drawing.Point(863, 0);
			this.btnAddStream.Name = "btnAddStream";
			this.btnAddStream.Size = new System.Drawing.Size(119, 23);
			this.btnAddStream.TabIndex = 1;
			this.btnAddStream.Text = "Add stream";
			this.btnAddStream.UseVisualStyleBackColor = true;
			this.btnAddStream.Click += new System.EventHandler(this.btnAddStream_Click);
			// 
			// tbxStreamUrl
			// 
			this.tbxStreamUrl.Location = new System.Drawing.Point(0, 0);
			this.tbxStreamUrl.Name = "tbxStreamUrl";
			this.tbxStreamUrl.Size = new System.Drawing.Size(863, 23);
			this.tbxStreamUrl.TabIndex = 0;
			// 
			// lblMessage
			// 
			this.lblMessage.Location = new System.Drawing.Point(0, 26);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Padding = new System.Windows.Forms.Padding(3);
			this.lblMessage.Size = new System.Drawing.Size(982, 43);
			this.lblMessage.TabIndex = 4;
			this.lblMessage.Text = "Enter stream URL into the text box and press the \"Add stream\"";
			// 
			// panAddStream
			// 
			this.panAddStream.Controls.Add(this.lblMessage);
			this.panAddStream.Controls.Add(this.tbxStreamUrl);
			this.panAddStream.Controls.Add(this.btnAddStream);
			this.panAddStream.Dock = System.Windows.Forms.DockStyle.Top;
			this.panAddStream.Location = new System.Drawing.Point(0, 0);
			this.panAddStream.Name = "panAddStream";
			this.panAddStream.Size = new System.Drawing.Size(982, 72);
			this.panAddStream.TabIndex = 0;
			this.panAddStream.Resize += new System.EventHandler(this.panAddStream_Resize);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(982, 458);
			this.Controls.Add(this.flPanPics);
			this.Controls.Add(this.panAddStream);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panAddStream.ResumeLayout(false);
			this.panAddStream.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.FlowLayoutPanel flPanPics;
		private System.Windows.Forms.Button btnAddStream;
		private System.Windows.Forms.TextBox tbxStreamUrl;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Panel panAddStream;
	}
}

