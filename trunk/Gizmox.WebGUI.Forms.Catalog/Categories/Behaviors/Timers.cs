using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for Timers.
	/// </summary>

    [Serializable()]
    public class Timers : UserControl
	{
		private Gizmox.WebGUI.Forms.Label label1;
		private Gizmox.WebGUI.Forms.ProgressBar progressBar1;
		private Gizmox.WebGUI.Forms.Timer timer1;

		private int mintNumber = 0;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public Timers()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();
			this.timer1.Tick+=new EventHandler(timer1_Tick);
			this.timer1.Interval = 500;
			this.timer1.Start();
			

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

			this.timer1.Stop();

			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.progressBar1 = new Gizmox.WebGUI.Forms.ProgressBar();
			this.timer1 = new Gizmox.WebGUI.Forms.Timer();
			this.SuspendLayout();

			//
			// timer1
			//
			this.timer1.Interval = 2000;

			// 
			// label1
			// 
			this.label1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label1.ClientSize = new System.Drawing.Size(120, 15);
			this.label1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "ProgressBar Control:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(24, 40);
			this.progressBar1.Size = new System.Drawing.Size(544, 25);
			this.progressBar1.Maximum = 100;
			this.progressBar1.Minimum = 0;
			this.progressBar1.Value = 0;

			// 
			// TextInputControlsCategory
			// 
			this.ClientSize = new System.Drawing.Size(656, 656);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.label1);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(656, 656);
			this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, EventArgs e)
		{
			mintNumber+=5;
			if(mintNumber>100)
			{
				mintNumber=0;
			}
			this.progressBar1.Value = mintNumber;
			
		}
	}
}
