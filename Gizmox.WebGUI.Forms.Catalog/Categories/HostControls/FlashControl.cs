using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Web;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Hosts;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.HostControls
{
	/// <summary>
	/// Summary description for FlashControl.
	/// </summary>

    [Serializable()]
    public class FlashControl : UserControl
	{



		public FlashControl()
		{
			FlashBox objFlashBox = new FlashBox();
			objFlashBox.Movie = "../../../../../../Resources/Flash/FC_2_3_Column3D.swf";
			objFlashBox.AddParameter("FlashVars","&dataURL=../../../../../../Resources/Flash/FC_2_3_Column3D.xml");
            objFlashBox.AddParameter("quality", "high");
			objFlashBox.Dock = DockStyle.Fill;
			this.Controls.Add(objFlashBox);

		}



		#region Component Designer generated code

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>\b
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

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			

		}
		#endregion


	}
}
