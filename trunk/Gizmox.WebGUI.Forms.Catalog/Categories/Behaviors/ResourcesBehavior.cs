using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Reflection;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;


namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for ResourcesBehavior.
	/// </summary>

    [Serializable()]
    public class ResourcesBehavior : UserControl
	{
		private Gizmox.WebGUI.Forms.PictureBox mobjPictureAssembly;
		private Gizmox.WebGUI.Forms.PictureBox mobjPictureUrl;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ResourcesBehavior()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            this.mobjPictureAssembly.Image = new AssemblyResourceHandle(typeof(ResourcesBehavior).Assembly, "Resources.Images.Stone.jpg");
			this.mobjPictureUrl.Image = new UrlResourceHandle("http://www.visualwebgui.com/Portals/0/Graphs/Architecture.gif");

            mobjPictureAssembly.Click += new EventHandler(mobjPictureAssembly_Click);
		}

        void mobjPictureAssembly_Click(object sender, EventArgs e)
        {
            MouseEventArgs a = e as MouseEventArgs;

            MessageBox.Show(string.Format("{0},{1}",a.X,a.Y));
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
			this.mobjPictureAssembly = new Gizmox.WebGUI.Forms.PictureBox();
			this.mobjPictureUrl = new Gizmox.WebGUI.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// mobjPictureAssembly
			// 
			this.mobjPictureAssembly.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjPictureAssembly.ClientSize = new System.Drawing.Size(160, 272);
			this.mobjPictureAssembly.Image = null;
			this.mobjPictureAssembly.Location = new System.Drawing.Point(8, 8);
			this.mobjPictureAssembly.Name = "mobjPictureAssembly";
			this.mobjPictureAssembly.Size = new System.Drawing.Size(160, 272);
			this.mobjPictureAssembly.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
			this.mobjPictureAssembly.TabIndex = 0;
			// 
			// mobjPictureUrl
			// 
			this.mobjPictureUrl.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjPictureUrl.ClientSize = new System.Drawing.Size(456, 264);
			this.mobjPictureUrl.Image = null;
			this.mobjPictureUrl.Location = new System.Drawing.Point(192, 16);
			this.mobjPictureUrl.Name = "mobjPictureUrl";
			this.mobjPictureUrl.Size = new System.Drawing.Size(456, 264);
			this.mobjPictureUrl.SizeMode = Gizmox.WebGUI.Forms.PictureBoxSizeMode.StretchImage;
			this.mobjPictureUrl.TabIndex = 1;
			// 
			// ResourcesBehavior
			// 
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(672, 528);
			this.Controls.Add(this.mobjPictureUrl);
			this.Controls.Add(this.mobjPictureAssembly);
			this.Size = new System.Drawing.Size(672, 528);
			this.ResumeLayout(false);

		}
		#endregion

		

		


	}
}
