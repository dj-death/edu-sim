using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.IO;
using System.Web;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Catalog.Categories.Gateways.Controls;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Gateways
{


	/// <summary>
	/// Summary description for LogicalCategory.
	/// </summary>

    [Serializable()]
    public class GraphGeneratingGateway : UserControl	
	{


		public GraphGeneratingGateway()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			PieControl objPieControl = new PieControl();
			objPieControl.Dock = DockStyle.Fill;
			objPieControl.Values = new int[]{10,20,30,15,5,20};
			objPieControl.Labels = new string[]{"Fish","Meat","Milk","Cookies","Wine","Eggs"};
			this.Controls.Add(objPieControl);
		}






		#region Component Designer generated code

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

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
