using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for XamlBoxBehavior.
	/// </summary>

    [Serializable()]
    public class XamlBoxBehavior : UserControl
	{
        private XamlBox xamlBox1;




		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public XamlBoxBehavior()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            xamlBox1.Url = "Resources/Xaml/Sample.xaml";
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
            this.xamlBox1 = new Gizmox.WebGUI.Forms.XamlBox();
            this.SuspendLayout();
            // 
            // xamlBox1
            // 
            this.xamlBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.xamlBox1.ClientSize = new System.Drawing.Size(521, 521);
            this.xamlBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.xamlBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.xamlBox1.Location = new System.Drawing.Point(0, 0);
            this.xamlBox1.Name = "xamlBox1";
            this.xamlBox1.Path = "";
            this.xamlBox1.Resource = null;
            this.xamlBox1.Size = new System.Drawing.Size(521, 521);
            this.xamlBox1.TabIndex = 0;
            this.xamlBox1.Url = "";
            this.xamlBox1.Xaml = "";
            // 
            // XamlBoxBehavior
            // 
            this.ClientSize = new System.Drawing.Size(521, 407);
            this.Controls.Add(this.xamlBox1);
            this.Size = new System.Drawing.Size(521, 407);
            this.ResumeLayout(false);

		}
		#endregion



	}
}
