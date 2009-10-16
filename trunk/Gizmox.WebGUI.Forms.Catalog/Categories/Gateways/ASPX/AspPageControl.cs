using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Hosts;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Gateways.ASPX
{
	/// <summary>
	/// Summary description for DateInputControls.
	/// </summary>

    [Serializable()]
    public class AspPageControl : UserControl, IHostedApplication
	{
        private MyAspPageBox mobjASPXBox = null;
        [Serializable()]
        public class MyAspPageBox : AspPageBox
        {

            protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
            {
                base.FireEvent(objEvent);

                if (objEvent.Type == "MessageBox")
                {
                    MessageBox.Show(objEvent["message"]);
                }
            }
        }
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public AspPageControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            mobjASPXBox = new MyAspPageBox();
            mobjASPXBox.Path = @"Categories\Gateways\ASPX\AspPageForm.aspx";
            mobjASPXBox.Dock = DockStyle.Fill;
            this.Controls.Add(mobjASPXBox);

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
			
		}
		#endregion

        #region IHostedApplication Members

        public void InitializeApplication()
        {
        }

        public HostedToolBarElement[] GetToolBarElements()
        {
            ArrayList objElements = new ArrayList();

            objElements.Add(new HostedToolBarButton("Test Client Invocation", new IconResourceHandle("Event.gif"), "InvokeClientMethod"));

            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
        }

        public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {            
            string strAction = (string)objButton.Tag;
            switch (strAction)
            {
                case "InvokeClientMethod":
             //       mobjASPXBox.InvokeClientMethod("ShowMessageFromServer", "Hii from server...");
                    break;
            }
        }

        #endregion
	}
}
