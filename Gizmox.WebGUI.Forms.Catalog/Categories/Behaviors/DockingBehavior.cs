using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for DockingBehavior.
	/// </summary>

    [Serializable()]
    public class DockingBehavior : UserControl
	{
		private Gizmox.WebGUI.Forms.Panel panel1;
		private Gizmox.WebGUI.Forms.Splitter splitter1;
		private Gizmox.WebGUI.Forms.Panel panel2;
		private Gizmox.WebGUI.Forms.Splitter splitter2;
		private Gizmox.WebGUI.Forms.Panel panel3;
		private Gizmox.WebGUI.Forms.Splitter splitter3;
		private Gizmox.WebGUI.Forms.Panel panel4;
		private Gizmox.WebGUI.Forms.Splitter splitter4;
		private Gizmox.WebGUI.Forms.Panel panel5;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public DockingBehavior()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            foreach (Control objControl in this.Controls)
            {
                Panel objPanel = objControl as Panel;
                if (objPanel != null)
                {
                    objPanel.Click += new EventHandler(OnPanelClick);
                }
            }
		}

        private void OnPanelClick(object sender, EventArgs e)
        {
            Panel objPanel = sender as Panel;
            if (objPanel != null)
            {
                MessageBox.Show(string.Format("Left={0}\nRight={1}\nTop={2}\nBottom={3}\nWidth={4}\nHeight={5}", objPanel.Left, objPanel.Right, objPanel.Top, objPanel.Bottom,objPanel.Width,objPanel.Height));
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.splitter1 = new Gizmox.WebGUI.Forms.Splitter();
			this.panel2 = new Gizmox.WebGUI.Forms.Panel();
			this.splitter2 = new Gizmox.WebGUI.Forms.Splitter();
			this.panel3 = new Gizmox.WebGUI.Forms.Panel();
			this.splitter3 = new Gizmox.WebGUI.Forms.Splitter();
			this.panel4 = new Gizmox.WebGUI.Forms.Panel();
			this.splitter4 = new Gizmox.WebGUI.Forms.Splitter();
			this.panel5 = new Gizmox.WebGUI.Forms.Panel();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.panel1.BackColor = System.Drawing.Color.RosyBrown;
			this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel1.ClientSize = new System.Drawing.Size(200, 792);
			this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.panel1.DockPadding.All = 0;
			this.panel1.DockPadding.Bottom = 0;
			this.panel1.DockPadding.Left = 0;
			this.panel1.DockPadding.Right = 0;
			this.panel1.DockPadding.Top = 0;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 792);
			this.panel1.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.splitter1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.splitter1.ClientSize = new System.Drawing.Size(3, 792);
			this.splitter1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.splitter1.Location = new System.Drawing.Point(200, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 792);
			this.splitter1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.panel2.BackColor = System.Drawing.Color.Khaki;
			this.panel2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel2.ClientSize = new System.Drawing.Size(589, 120);
			this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.panel2.DockPadding.All = 0;
			this.panel2.DockPadding.Bottom = 0;
			this.panel2.DockPadding.Left = 0;
			this.panel2.DockPadding.Right = 0;
			this.panel2.DockPadding.Top = 0;
			this.panel2.Location = new System.Drawing.Point(203, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(589, 120);
			this.panel2.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.splitter2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.splitter2.ClientSize = new System.Drawing.Size(589, 3);
			this.splitter2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(203, 120);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(589, 3);
			this.splitter2.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.panel3.BackColor = System.Drawing.Color.PaleTurquoise;
			this.panel3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel3.ClientSize = new System.Drawing.Size(240, 669);
			this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
			this.panel3.DockPadding.All = 0;
			this.panel3.DockPadding.Bottom = 0;
			this.panel3.DockPadding.Left = 0;
			this.panel3.DockPadding.Right = 0;
			this.panel3.DockPadding.Top = 0;
			this.panel3.Location = new System.Drawing.Point(552, 123);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(240, 669);
			this.panel3.TabIndex = 4;
			// 
			// splitter3
			// 
			this.splitter3.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.splitter3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.splitter3.ClientSize = new System.Drawing.Size(3, 669);
			this.splitter3.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
			this.splitter3.Location = new System.Drawing.Point(549, 123);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(3, 669);
			this.splitter3.TabIndex = 5;
			// 
			// panel4
			// 
			this.panel4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.panel4.BackColor = System.Drawing.Color.LightPink;
			this.panel4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel4.ClientSize = new System.Drawing.Size(346, 100);
			this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
			this.panel4.DockPadding.All = 0;
			this.panel4.DockPadding.Bottom = 0;
			this.panel4.DockPadding.Left = 0;
			this.panel4.DockPadding.Right = 0;
			this.panel4.DockPadding.Top = 0;
			this.panel4.Location = new System.Drawing.Point(203, 580);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(346, 100);
			this.panel4.TabIndex = 6;
			// 
			// splitter4
			// 
			this.splitter4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.splitter4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.splitter4.ClientSize = new System.Drawing.Size(346, 3);
			this.splitter4.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
			this.splitter4.Location = new System.Drawing.Point(203, 577);
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(346, 3);
			this.splitter4.TabIndex = 7;
			// 
			// panel5
			// 
			this.panel5.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.panel5.BackColor = System.Drawing.Color.GreenYellow;
			this.panel5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel5.ClientSize = new System.Drawing.Size(346, 566);
			this.panel5.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.panel5.DockPadding.All = 0;
			this.panel5.DockPadding.Bottom = 0;
			this.panel5.DockPadding.Left = 0;
			this.panel5.DockPadding.Right = 0;
			this.panel5.DockPadding.Top = 0;
			this.panel5.Location = new System.Drawing.Point(203, 123);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(346, 566);
			this.panel5.TabIndex = 8;
			// 
			// DockingBehavior
			// 
			this.ClientSize = new System.Drawing.Size(792, 680);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.splitter4);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.splitter3);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(792, 680);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
