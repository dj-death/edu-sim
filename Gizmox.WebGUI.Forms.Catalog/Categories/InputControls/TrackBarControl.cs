using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.InputControls
{
	/// <summary>
	/// Summary description for TrackBarControl.
	/// </summary>

    [Serializable()]
    public class TrackBarControl : UserControl
	{
		private Gizmox.WebGUI.Forms.TrackBar mobjTrackBarRed1;
		private Gizmox.WebGUI.Forms.TrackBar mobjTrackBarGreen1;
		private Gizmox.WebGUI.Forms.TrackBar mobjTrackBarRed2;
		private Gizmox.WebGUI.Forms.TrackBar mobjTrackBarGreen2;
		private Gizmox.WebGUI.Forms.TrackBar mobjTrackBarBlue2;
		private Gizmox.WebGUI.Forms.TrackBar mobjTrackBarBlue1;
		private Gizmox.WebGUI.Forms.Panel panel1;
		private Gizmox.WebGUI.Forms.Panel panel2;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public TrackBarControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			UpdateValues();

		}

		private void mobjTrackBarRed2_ValueChanged(object sender, EventArgs e)
		{
			UpdateValues();
		}

		private void UpdateValues()
		{
			this.panel2.BackColor = Color.FromArgb(this.mobjTrackBarRed1.Value, this.mobjTrackBarGreen1.Value, this.mobjTrackBarBlue1.Value);
			this.panel1.BackColor = Color.FromArgb(this.mobjTrackBarRed2.Value, this.mobjTrackBarGreen2.Value, this.mobjTrackBarBlue2.Value);
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjTrackBarRed1 = new Gizmox.WebGUI.Forms.TrackBar();
			this.mobjTrackBarGreen1 = new Gizmox.WebGUI.Forms.TrackBar();
			this.mobjTrackBarRed2 = new Gizmox.WebGUI.Forms.TrackBar();
			this.mobjTrackBarGreen2 = new Gizmox.WebGUI.Forms.TrackBar();
			this.mobjTrackBarBlue2 = new Gizmox.WebGUI.Forms.TrackBar();
			this.mobjTrackBarBlue1 = new Gizmox.WebGUI.Forms.TrackBar();
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.panel2 = new Gizmox.WebGUI.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarRed1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarGreen1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarRed2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarGreen2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarBlue2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarBlue1)).BeginInit();
			this.SuspendLayout();
			// 
			// mobjTrackBarRed1
			// 
			this.mobjTrackBarRed1.Location = new System.Drawing.Point(25, 12);
			this.mobjTrackBarRed1.Maximum = 255;
			this.mobjTrackBarRed1.Name = "mobjTrackBarRed1";
			this.mobjTrackBarRed1.Size = new System.Drawing.Size(346, 45);
			this.mobjTrackBarRed1.TabIndex = 0;
			this.mobjTrackBarRed1.TickFrequency = 32;
			this.mobjTrackBarRed1.TickStyle = Gizmox.WebGUI.Forms.TickStyle.Both;
			this.mobjTrackBarRed1.Value = 255;
			this.mobjTrackBarRed1.ValueChanged += new System.EventHandler(this.mobjTrackBarRed2_ValueChanged);
			// 
			// mobjTrackBarGreen1
			// 
			this.mobjTrackBarGreen1.Location = new System.Drawing.Point(25, 76);
			this.mobjTrackBarGreen1.Maximum = 255;
			this.mobjTrackBarGreen1.Name = "mobjTrackBarGreen1";
			this.mobjTrackBarGreen1.Size = new System.Drawing.Size(346, 45);
			this.mobjTrackBarGreen1.TabIndex = 1;
			this.mobjTrackBarGreen1.TickFrequency = 32;
			this.mobjTrackBarGreen1.Value = 64;
			this.mobjTrackBarGreen1.ValueChanged += new System.EventHandler(this.mobjTrackBarRed2_ValueChanged);
			// 
			// mobjTrackBarRed2
			// 
			this.mobjTrackBarRed2.Location = new System.Drawing.Point(157, 207);
			this.mobjTrackBarRed2.Maximum = 255;
			this.mobjTrackBarRed2.Name = "mobjTrackBarRed2";
			this.mobjTrackBarRed2.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
			this.mobjTrackBarRed2.Size = new System.Drawing.Size(45, 222);
			this.mobjTrackBarRed2.TabIndex = 2;
			this.mobjTrackBarRed2.TickFrequency = 32;
			this.mobjTrackBarRed2.Value = 255;
			this.mobjTrackBarRed2.ValueChanged += new System.EventHandler(this.mobjTrackBarRed2_ValueChanged);
			// 
			// mobjTrackBarGreen2
			// 
			this.mobjTrackBarGreen2.Location = new System.Drawing.Point(245, 207);
			this.mobjTrackBarGreen2.Maximum = 255;
			this.mobjTrackBarGreen2.Name = "mobjTrackBarGreen2";
			this.mobjTrackBarGreen2.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
			this.mobjTrackBarGreen2.Size = new System.Drawing.Size(45, 222);
			this.mobjTrackBarGreen2.TabIndex = 3;
			this.mobjTrackBarGreen2.TickFrequency = 32;
			this.mobjTrackBarGreen2.TickStyle = Gizmox.WebGUI.Forms.TickStyle.Both;
			this.mobjTrackBarGreen2.Value = 100;
			this.mobjTrackBarGreen2.ValueChanged += new System.EventHandler(this.mobjTrackBarRed2_ValueChanged);
			// 
			// mobjTrackBarBlue2
			// 
			this.mobjTrackBarBlue2.Location = new System.Drawing.Point(326, 207);
			this.mobjTrackBarBlue2.Maximum = 255;
			this.mobjTrackBarBlue2.Name = "mobjTrackBarBlue2";
			this.mobjTrackBarBlue2.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
			this.mobjTrackBarBlue2.Size = new System.Drawing.Size(45, 222);
			this.mobjTrackBarBlue2.TabIndex = 4;
			this.mobjTrackBarBlue2.TickFrequency = 32;
			this.mobjTrackBarBlue2.TickStyle = Gizmox.WebGUI.Forms.TickStyle.TopLeft;
			this.mobjTrackBarBlue2.Value = 255;
			this.mobjTrackBarBlue2.ValueChanged += new System.EventHandler(this.mobjTrackBarRed2_ValueChanged);
			// 
			// mobjTrackBarBlue1
			// 
			this.mobjTrackBarBlue1.Location = new System.Drawing.Point(25, 139);
			this.mobjTrackBarBlue1.Maximum = 255;
			this.mobjTrackBarBlue1.Name = "mobjTrackBarBlue1";
			this.mobjTrackBarBlue1.Size = new System.Drawing.Size(346, 45);
			this.mobjTrackBarBlue1.TabIndex = 5;
			this.mobjTrackBarBlue1.TickFrequency = 32;
			this.mobjTrackBarBlue1.TickStyle = Gizmox.WebGUI.Forms.TickStyle.TopLeft;
			this.mobjTrackBarBlue1.Value = 255;
			this.mobjTrackBarBlue1.ValueChanged += new System.EventHandler(this.mobjTrackBarRed2_ValueChanged);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(379, 209);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(101, 222);
			this.panel1.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.Location = new System.Drawing.Point(379, 12);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(101, 172);
			this.panel2.TabIndex = 7;
			// 
			// Form2
			// 
			this.ClientSize = new System.Drawing.Size(533, 443);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.mobjTrackBarBlue1);
			this.Controls.Add(this.mobjTrackBarBlue2);
			this.Controls.Add(this.mobjTrackBarGreen2);
			this.Controls.Add(this.mobjTrackBarRed2);
			this.Controls.Add(this.mobjTrackBarGreen1);
			this.Controls.Add(this.mobjTrackBarRed1);
			this.Name = "Form2";
			this.Text = "Form2";
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarRed1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarGreen1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarRed2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarGreen2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarBlue2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mobjTrackBarBlue1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
