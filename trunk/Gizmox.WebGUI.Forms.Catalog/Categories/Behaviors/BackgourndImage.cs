using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Gizmox.WebGUI.Common.Resources;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for BackgroundImage.
	/// </summary>

    [Serializable()]
    public class BackgroundImage : UserControl
	{
		private Gizmox.WebGUI.Forms.Panel mobjPanelNone;
		private Gizmox.WebGUI.Forms.Panel mobjPanelStrech;
		private Gizmox.WebGUI.Forms.Panel mobjPanelTile;
		private Gizmox.WebGUI.Forms.Panel mobjPanelCenter;
		private Gizmox.WebGUI.Forms.Panel mobjPanelZoom;
		private Gizmox.WebGUI.Forms.Label label1;
		private Gizmox.WebGUI.Forms.Label label2;
		private Gizmox.WebGUI.Forms.Label label3;
		private Gizmox.WebGUI.Forms.Label label4;
		private Gizmox.WebGUI.Forms.Label label5;
		private Gizmox.WebGUI.Forms.Panel panel6;
		private Gizmox.WebGUI.Forms.Label mobjLabelNone;
		private Gizmox.WebGUI.Forms.Label mobjLabelTile;
		private Gizmox.WebGUI.Forms.Label mobjLabelCenter;
		private Gizmox.WebGUI.Forms.Label mobjLabelStrech;
		private Gizmox.WebGUI.Forms.Label mobjLabelZoom;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public BackgroundImage()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			ImageResourceHandle objImage = new ImageResourceHandle("Background.jpg");
			
			this.mobjPanelCenter.BackgroundImage = objImage;
			this.mobjPanelCenter.BackgroundImageLayout = ImageLayout.Center;
			this.mobjPanelCenter.BorderColor = Color.Black;

			this.mobjPanelNone.BackgroundImage = objImage;
			this.mobjPanelNone.BackgroundImageLayout = ImageLayout.None;
			this.mobjPanelNone.BorderColor = Color.Black;

			this.mobjPanelStrech.BackgroundImage = objImage;
			this.mobjPanelStrech.BackgroundImageLayout = ImageLayout.Stretch;
			this.mobjPanelStrech.BorderColor = Color.Black;

			this.mobjPanelTile.BackgroundImage = objImage;
			this.mobjPanelTile.BackgroundImageLayout = ImageLayout.Tile;
			this.mobjPanelTile.BorderColor = Color.Black;

			this.mobjPanelZoom.BackgroundImage = objImage;
			this.mobjPanelZoom.BackgroundImageLayout = ImageLayout.Zoom;
			this.mobjPanelZoom.BorderColor = Color.Black;

			this.mobjLabelCenter.BackgroundImage = objImage;
			this.mobjLabelCenter.BackgroundImageLayout = ImageLayout.Center;
			this.mobjLabelCenter.BorderColor = Color.Black;

			this.mobjLabelNone.BackgroundImage = objImage;
			this.mobjLabelNone.BackgroundImageLayout = ImageLayout.None;
			this.mobjLabelNone.BorderColor = Color.Black;

			this.mobjLabelStrech.BackgroundImage = objImage;
			this.mobjLabelStrech.BackgroundImageLayout = ImageLayout.Stretch;
			this.mobjLabelStrech.BorderColor = Color.Black;
			this.mobjLabelStrech.Click+=new EventHandler(mobjLabelStrech_Click);

			this.mobjLabelTile.BackgroundImage = objImage;
			this.mobjLabelTile.BackgroundImageLayout = ImageLayout.Tile;
			this.mobjLabelTile.BorderColor = Color.Black;

			this.mobjLabelZoom.BackgroundImage = objImage;
			this.mobjLabelZoom.BackgroundImageLayout = ImageLayout.Zoom;
			this.mobjLabelZoom.BorderColor = Color.Black;

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
			this.mobjPanelNone = new Gizmox.WebGUI.Forms.Panel();
			this.mobjPanelStrech = new Gizmox.WebGUI.Forms.Panel();
			this.mobjPanelTile = new Gizmox.WebGUI.Forms.Panel();
			this.mobjPanelCenter = new Gizmox.WebGUI.Forms.Panel();
			this.mobjPanelZoom = new Gizmox.WebGUI.Forms.Panel();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.label2 = new Gizmox.WebGUI.Forms.Label();
			this.label3 = new Gizmox.WebGUI.Forms.Label();
			this.label4 = new Gizmox.WebGUI.Forms.Label();
			this.label5 = new Gizmox.WebGUI.Forms.Label();
			this.panel6 = new Gizmox.WebGUI.Forms.Panel();
			this.mobjLabelNone = new Gizmox.WebGUI.Forms.Label();
			this.mobjLabelTile = new Gizmox.WebGUI.Forms.Label();
			this.mobjLabelCenter = new Gizmox.WebGUI.Forms.Label();
			this.mobjLabelStrech = new Gizmox.WebGUI.Forms.Label();
			this.mobjLabelZoom = new Gizmox.WebGUI.Forms.Label();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// mobjPanelNone
			// 
			this.mobjPanelNone.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjPanelNone.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjPanelNone.ClientSize = new System.Drawing.Size(200, 168);
			this.mobjPanelNone.DockPadding.All = 0;
			this.mobjPanelNone.DockPadding.Bottom = 0;
			this.mobjPanelNone.DockPadding.Left = 0;
			this.mobjPanelNone.DockPadding.Right = 0;
			this.mobjPanelNone.DockPadding.Top = 0;
			this.mobjPanelNone.Location = new System.Drawing.Point(24, 48);
			this.mobjPanelNone.Name = "mobjPanelNone";
			this.mobjPanelNone.Size = new System.Drawing.Size(200, 168);
			this.mobjPanelNone.TabIndex = 0;
			this.mobjPanelNone.BorderStyle = BorderStyle.FixedSingle;
			// 
			// mobjPanelStrech
			// 
			this.mobjPanelStrech.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjPanelStrech.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjPanelStrech.ClientSize = new System.Drawing.Size(200, 168);
			this.mobjPanelStrech.DockPadding.All = 0;
			this.mobjPanelStrech.DockPadding.Bottom = 0;
			this.mobjPanelStrech.DockPadding.Left = 0;
			this.mobjPanelStrech.DockPadding.Right = 0;
			this.mobjPanelStrech.DockPadding.Top = 0;
			this.mobjPanelStrech.Location = new System.Drawing.Point(24, 248);
			this.mobjPanelStrech.Name = "mobjPanelStrech";
			this.mobjPanelStrech.Size = new System.Drawing.Size(200, 168);
			this.mobjPanelStrech.TabIndex = 1;
			this.mobjPanelStrech.BorderStyle = BorderStyle.FixedSingle;
			// 
			// mobjPanelTile
			// 
			this.mobjPanelTile.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjPanelTile.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjPanelTile.ClientSize = new System.Drawing.Size(200, 168);
			this.mobjPanelTile.DockPadding.All = 0;
			this.mobjPanelTile.DockPadding.Bottom = 0;
			this.mobjPanelTile.DockPadding.Left = 0;
			this.mobjPanelTile.DockPadding.Right = 0;
			this.mobjPanelTile.DockPadding.Top = 0;
			this.mobjPanelTile.Location = new System.Drawing.Point(256, 48);
			this.mobjPanelTile.Name = "mobjPanelTile";
			this.mobjPanelTile.Size = new System.Drawing.Size(200, 168);
			this.mobjPanelTile.TabIndex = 2;
			this.mobjPanelTile.BorderStyle = BorderStyle.FixedSingle;
			// 
			// mobjPanelCenter
			// 
			this.mobjPanelCenter.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjPanelCenter.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjPanelCenter.ClientSize = new System.Drawing.Size(200, 168);
			this.mobjPanelCenter.DockPadding.All = 0;
			this.mobjPanelCenter.DockPadding.Bottom = 0;
			this.mobjPanelCenter.DockPadding.Left = 0;
			this.mobjPanelCenter.DockPadding.Right = 0;
			this.mobjPanelCenter.DockPadding.Top = 0;
			this.mobjPanelCenter.Location = new System.Drawing.Point(488, 48);
			this.mobjPanelCenter.Name = "mobjPanelCenter";
			this.mobjPanelCenter.Size = new System.Drawing.Size(200, 168);
			this.mobjPanelCenter.TabIndex = 3;
			this.mobjPanelCenter.BorderStyle = BorderStyle.FixedSingle;
			// 
			// mobjPanelZoom
			// 
			this.mobjPanelZoom.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjPanelZoom.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjPanelZoom.ClientSize = new System.Drawing.Size(200, 168);
			this.mobjPanelZoom.DockPadding.All = 0;
			this.mobjPanelZoom.DockPadding.Bottom = 0;
			this.mobjPanelZoom.DockPadding.Left = 0;
			this.mobjPanelZoom.DockPadding.Right = 0;
			this.mobjPanelZoom.DockPadding.Top = 0;
			this.mobjPanelZoom.Location = new System.Drawing.Point(256, 248);
			this.mobjPanelZoom.Name = "mobjPanelZoom";
			this.mobjPanelZoom.Size = new System.Drawing.Size(200, 168);
			this.mobjPanelZoom.TabIndex = 4;
			this.mobjPanelZoom.BorderStyle = BorderStyle.FixedSingle;
			// 
			// label1
			// 
			this.label1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label1.ClientSize = new System.Drawing.Size(100, 16);
			this.label1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 5;
			this.label1.Text = "None";
			// 
			// label2
			// 
			this.label2.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label2.ClientSize = new System.Drawing.Size(100, 16);
			this.label2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label2.Location = new System.Drawing.Point(256, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Tile";
			// 
			// label3
			// 
			this.label3.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label3.ClientSize = new System.Drawing.Size(100, 16);
			this.label3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label3.Location = new System.Drawing.Point(488, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 7;
			this.label3.Text = "Center";
			// 
			// label4
			// 
			this.label4.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label4.ClientSize = new System.Drawing.Size(100, 16);
			this.label4.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label4.Location = new System.Drawing.Point(24, 224);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 8;
			this.label4.Text = "Strech";
			// 
			// label5
			// 
			this.label5.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label5.ClientSize = new System.Drawing.Size(100, 16);
			this.label5.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label5.Location = new System.Drawing.Point(256, 224);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 9;
			this.label5.Text = "Zoom";
			// 
			// panel6
			// 
			this.panel6.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.panel6.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.panel6.ClientSize = new System.Drawing.Size(736, 336);
			this.panel6.Controls.Add(this.mobjLabelZoom);
			this.panel6.Controls.Add(this.mobjLabelStrech);
			this.panel6.Controls.Add(this.mobjLabelCenter);
			this.panel6.Controls.Add(this.mobjLabelTile);
			this.panel6.Controls.Add(this.mobjLabelNone);
			this.panel6.DockPadding.All = 0;
			this.panel6.DockPadding.Bottom = 0;
			this.panel6.DockPadding.Left = 0;
			this.panel6.DockPadding.Right = 0;
			this.panel6.DockPadding.Top = 0;
			this.panel6.Location = new System.Drawing.Point(24, 448);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(736, 336);
			this.panel6.TabIndex = 10;
			// 
			// mobjLabelNone
			// 
			this.mobjLabelNone.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjLabelNone.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjLabelNone.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.mobjLabelNone.ClientSize = new System.Drawing.Size(168, 736);
			this.mobjLabelNone.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.mobjLabelNone.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelNone.Location = new System.Drawing.Point(0, 0);
			this.mobjLabelNone.Name = "mobjLabelNone";
			this.mobjLabelNone.Size = new System.Drawing.Size(168, 736);
			this.mobjLabelNone.TabIndex = 0;
			this.mobjLabelNone.Text = "None";
			this.mobjLabelNone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mobjLabelNone.BorderStyle = BorderStyle.FixedSingle;
			// 
			// mobjLabelTile
			// 
			this.mobjLabelTile.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjLabelTile.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjLabelTile.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.mobjLabelTile.ClientSize = new System.Drawing.Size(184, 736);
			this.mobjLabelTile.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
			this.mobjLabelTile.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelTile.Location = new System.Drawing.Point(552, 0);
			this.mobjLabelTile.Name = "mobjLabelTile";
			this.mobjLabelTile.Size = new System.Drawing.Size(184, 736);
			this.mobjLabelTile.TabIndex = 1;
			this.mobjLabelTile.Text = "Tile";
			this.mobjLabelTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mobjLabelTile.BorderStyle = BorderStyle.FixedSingle;
			// 
			// mobjLabelCenter
			// 
			this.mobjLabelCenter.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjLabelCenter.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjLabelCenter.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.mobjLabelCenter.ClientSize = new System.Drawing.Size(384, 104);
			this.mobjLabelCenter.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjLabelCenter.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelCenter.Location = new System.Drawing.Point(168, 0);
			this.mobjLabelCenter.Name = "mobjLabelCenter";
			this.mobjLabelCenter.Size = new System.Drawing.Size(384, 104);
			this.mobjLabelCenter.TabIndex = 2;
			this.mobjLabelCenter.Text = "Center";
			this.mobjLabelCenter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mobjLabelCenter.BorderStyle = BorderStyle.FixedSingle;
			// 
			// mobjLabelStrech
			// 
			this.mobjLabelStrech.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjLabelStrech.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjLabelStrech.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.mobjLabelStrech.ClientSize = new System.Drawing.Size(384, 104);
			this.mobjLabelStrech.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
			this.mobjLabelStrech.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelStrech.Location = new System.Drawing.Point(168, 232);
			this.mobjLabelStrech.Name = "mobjLabelStrech";
			this.mobjLabelStrech.Size = new System.Drawing.Size(384, 104);
			this.mobjLabelStrech.TabIndex = 3;
			this.mobjLabelStrech.Text = "Strech";
			this.mobjLabelStrech.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mobjLabelStrech.BorderStyle = BorderStyle.FixedSingle;
			// 
			// mobjLabelZoom
			// 
			this.mobjLabelZoom.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjLabelZoom.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjLabelZoom.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
			this.mobjLabelZoom.ClientSize = new System.Drawing.Size(384, 528);
			this.mobjLabelZoom.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjLabelZoom.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelZoom.Location = new System.Drawing.Point(168, 104);
			this.mobjLabelZoom.Name = "mobjLabelZoom";
			this.mobjLabelZoom.Size = new System.Drawing.Size(384, 528);
			this.mobjLabelZoom.TabIndex = 4;
			this.mobjLabelZoom.Text = "Zoom";
			this.mobjLabelZoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mobjLabelZoom.BorderStyle = BorderStyle.FixedSingle;
			// 
			// BackgroundImage
			// 
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(776, 832);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.mobjPanelZoom);
			this.Controls.Add(this.mobjPanelCenter);
			this.Controls.Add(this.mobjPanelTile);
			this.Controls.Add(this.mobjPanelStrech);
			this.Controls.Add(this.mobjPanelNone);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(776, 832);
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void mobjLabelStrech_Click(object sender, EventArgs e)
		{
            //FontDialog objFontDialog = new FontDialog();
            //objFontDialog.ShowDialog();
		}
	}
}
