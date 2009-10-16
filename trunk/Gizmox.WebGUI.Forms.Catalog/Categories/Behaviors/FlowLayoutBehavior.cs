using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for FlowLayoutBehavior.
	/// </summary>

    [Serializable()]
    public class FlowLayoutBehavior : UserControl
	{
		private Gizmox.WebGUI.Forms.FlowLayoutPanel flowLayoutPanel1;
		private Gizmox.WebGUI.Forms.Button button1;
		private Gizmox.WebGUI.Forms.Button button2;
		private Gizmox.WebGUI.Forms.Button button3;
		private Gizmox.WebGUI.Forms.Panel panel1;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public FlowLayoutBehavior()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
			this.flowLayoutPanel1 = new Gizmox.WebGUI.Forms.FlowLayoutPanel();
			this.button1 = new Gizmox.WebGUI.Forms.Button();
			this.button2 = new Gizmox.WebGUI.Forms.Button();
			this.button3 = new Gizmox.WebGUI.Forms.Button();
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.flowLayoutPanel1.ClientSize = new System.Drawing.Size(520, 520);
			this.flowLayoutPanel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.FlowDirection = Gizmox.WebGUI.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(520, 520);
			this.flowLayoutPanel1.TabIndex = 0;
			this.flowLayoutPanel1.WrapContents = true;
			// 
			// button1
			// 
			this.button1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button1.ClientSize = new System.Drawing.Size(75, 23);
			this.button1.Location = new System.Drawing.Point(16, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			// 
			// button2
			// 
			this.button2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button2.ClientSize = new System.Drawing.Size(75, 23);
			this.button2.Location = new System.Drawing.Point(112, 32);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "button2";
			// 
			// button3
			// 
			this.button3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.button3.ClientSize = new System.Drawing.Size(75, 23);
			this.button3.Location = new System.Drawing.Point(208, 32);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "button3";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.PeachPuff;
			this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel1.BorderColor = System.Drawing.Color.Bisque;
			this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel1.ClientSize = new System.Drawing.Size(200, 100);
			this.panel1.Location = new System.Drawing.Point(32, 136);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 100);
			this.panel1.TabIndex = 4;
			// 
			// FlowLayoutBehavior
			// 
			this.ClientSize = new System.Drawing.Size(520, 584);
			this.flowLayoutPanel1.Controls.Add(this.panel1);
			this.flowLayoutPanel1.Controls.Add(this.button3);
			this.flowLayoutPanel1.Controls.Add(this.button2);
			this.flowLayoutPanel1.Controls.Add(this.button1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Size = new System.Drawing.Size(520, 584);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
