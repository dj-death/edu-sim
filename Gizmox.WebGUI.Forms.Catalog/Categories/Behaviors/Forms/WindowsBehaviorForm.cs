using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors.Forms
{
	/// <summary>
	/// Summary description for WindowsBehaviorForm.
	/// </summary>

    [Serializable()]
    public class WindowsBehaviorForm : Gizmox.WebGUI.Forms.Form
	{
		private WindowsBehavior panel1;
		private Gizmox.WebGUI.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		private Timer mobjTimer = null;

		public WindowsBehaviorForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			mobjTimer = new Timer();
			mobjTimer.Tick+=new EventHandler(mobjTimer_Tick);
			mobjTimer.Interval = 300;

            
			
		}

        protected override bool IsWindowSized
        {
            get
            {
                return true;
            }
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors.WindowsBehavior();
			this.button1 = new Gizmox.WebGUI.Forms.Button();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel1.ClientSize = new System.Drawing.Size(496, 496);
			this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(496, 496);
			this.panel1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button1.ClientSize = new System.Drawing.Size(75, 23);
			this.button1.Location = new System.Drawing.Point(296, 304);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// WindowsBehaviorForm
			// 
			this.ClientSize = new System.Drawing.Size(496, 390);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel1);
			this.Size = new System.Drawing.Size(496, 390);
			this.Text = "SearchForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Thank you for clicking me","",MessageBoxButtons.OK,MessageBoxIcon.Information,new EventHandler(DoClose));
		}

		private void DoClose(object sender,EventArgs e)
		{
			this.Close();
			//mobjTimer.Start();
		}

		private void mobjTimer_Tick(object sender, EventArgs e)
		{
			//mobjTimer.Stop();
			
		}
	}
}
