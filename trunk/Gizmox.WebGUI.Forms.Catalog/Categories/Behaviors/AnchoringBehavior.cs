using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for AnchoringBehavior.
	/// </summary>
	[Serializable()]
	public class AnchoringBehavior : UserControl
	{
		private Gizmox.WebGUI.Forms.Panel panel1;
		private Gizmox.WebGUI.Forms.Panel panel2;
		private Gizmox.WebGUI.Forms.Panel panel3;
		private Gizmox.WebGUI.Forms.Panel panel4;
		private Gizmox.WebGUI.Forms.Panel panel5;
		private Gizmox.WebGUI.Forms.Panel panel6;
		private Gizmox.WebGUI.Forms.Panel panel7;
		private Gizmox.WebGUI.Forms.Panel panel8;
		private Gizmox.WebGUI.Forms.Panel panel9;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public AnchoringBehavior()
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
                MessageBox.Show(string.Format("Left={0}\nRight={1}\nTop={2}\nBottom={3}\nWidth={4}\nHeight={5}", objPanel.Left, objPanel.Right, objPanel.Top, objPanel.Bottom, objPanel.Width, objPanel.Height));
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
			this.panel2 = new Gizmox.WebGUI.Forms.Panel();
			this.panel3 = new Gizmox.WebGUI.Forms.Panel();
			this.panel4 = new Gizmox.WebGUI.Forms.Panel();
			this.panel5 = new Gizmox.WebGUI.Forms.Panel();
			this.panel6 = new Gizmox.WebGUI.Forms.Panel();
			this.panel7 = new Gizmox.WebGUI.Forms.Panel();
			this.panel8 = new Gizmox.WebGUI.Forms.Panel();
			this.panel9 = new Gizmox.WebGUI.Forms.Panel();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel1.ClientSize = new System.Drawing.Size(96, 100);
			this.panel1.DockPadding.All = 0;
			this.panel1.DockPadding.Bottom = 0;
			this.panel1.DockPadding.Left = 0;
			this.panel1.DockPadding.Right = 0;
			this.panel1.DockPadding.Top = 0;
			this.panel1.Location = new System.Drawing.Point(24, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(96, 100);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel2.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel2.ClientSize = new System.Drawing.Size(112, 100);
			this.panel2.DockPadding.All = 0;
			this.panel2.DockPadding.Bottom = 0;
			this.panel2.DockPadding.Left = 0;
			this.panel2.DockPadding.Right = 0;
			this.panel2.DockPadding.Top = 0;
			this.panel2.Location = new System.Drawing.Point(152, 16);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(112, 100);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.panel3.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel3.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel3.ClientSize = new System.Drawing.Size(96, 100);
			this.panel3.DockPadding.All = 0;
			this.panel3.DockPadding.Bottom = 0;
			this.panel3.DockPadding.Left = 0;
			this.panel3.DockPadding.Right = 0;
			this.panel3.DockPadding.Top = 0;
			this.panel3.Location = new System.Drawing.Point(288, 16);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(96, 100);
			this.panel3.TabIndex = 2;
			// 
			// panel4
			// 
			this.panel4.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.panel4.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel4.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel4.ClientSize = new System.Drawing.Size(96, 100);
			this.panel4.DockPadding.All = 0;
			this.panel4.DockPadding.Bottom = 0;
			this.panel4.DockPadding.Left = 0;
			this.panel4.DockPadding.Right = 0;
			this.panel4.DockPadding.Top = 0;
			this.panel4.Location = new System.Drawing.Point(24, 272);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(96, 100);
			this.panel4.TabIndex = 3;
			// 
			// panel5
			// 
			this.panel5.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.panel5.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel5.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel5.ClientSize = new System.Drawing.Size(96, 108);
			this.panel5.DockPadding.All = 0;
			this.panel5.DockPadding.Bottom = 0;
			this.panel5.DockPadding.Left = 0;
			this.panel5.DockPadding.Right = 0;
			this.panel5.DockPadding.Top = 0;
			this.panel5.Location = new System.Drawing.Point(24, 136);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(96, 108);
			this.panel5.TabIndex = 4;
			// 
			// panel6
			// 
			this.panel6.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Left) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.panel6.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel6.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel6.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel6.ClientSize = new System.Drawing.Size(112, 108);
			this.panel6.DockPadding.All = 0;
			this.panel6.DockPadding.Bottom = 0;
			this.panel6.DockPadding.Left = 0;
			this.panel6.DockPadding.Right = 0;
			this.panel6.DockPadding.Top = 0;
			this.panel6.Location = new System.Drawing.Point(152, 136);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(112, 108);
			this.panel6.TabIndex = 5;
			// 
			// panel7
			// 
			this.panel7.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.panel7.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel7.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel7.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel7.ClientSize = new System.Drawing.Size(112, 100);
			this.panel7.DockPadding.All = 0;
			this.panel7.DockPadding.Bottom = 0;
			this.panel7.DockPadding.Left = 0;
			this.panel7.DockPadding.Right = 0;
			this.panel7.DockPadding.Top = 0;
			this.panel7.Location = new System.Drawing.Point(152, 272);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(112, 100);
			this.panel7.TabIndex = 6;
			// 
			// panel8
			// 
			this.panel8.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.panel8.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel8.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel8.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel8.ClientSize = new System.Drawing.Size(96, 108);
			this.panel8.DockPadding.All = 0;
			this.panel8.DockPadding.Bottom = 0;
			this.panel8.DockPadding.Left = 0;
			this.panel8.DockPadding.Right = 0;
			this.panel8.DockPadding.Top = 0;
			this.panel8.Location = new System.Drawing.Point(288, 136);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(96, 108);
			this.panel8.TabIndex = 7;
			// 
			// panel9
			// 
			this.panel9.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.panel9.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel9.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel9.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.panel9.ClientSize = new System.Drawing.Size(96, 100);
			this.panel9.DockPadding.All = 0;
			this.panel9.DockPadding.Bottom = 0;
			this.panel9.DockPadding.Left = 0;
			this.panel9.DockPadding.Right = 0;
			this.panel9.DockPadding.Top = 0;
			this.panel9.Location = new System.Drawing.Point(288, 272);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(96, 100);
			this.panel9.TabIndex = 8;
			// 
			// AnchoringBehavior
			// 
			this.ClientSize = new System.Drawing.Size(544, 576);
			this.Controls.Add(this.panel9);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(544, 576);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
