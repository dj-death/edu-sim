#region Using

using System;
using System.Web;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Editors;
using System.Collections;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using System.IO;

#endregion

namespace Gizmox.WebGUI.Forms.Catalog.Extensions.Editors
{
    [Serializable()]
    public class FCKEditorSample : UserControl, IHostedApplication, IGatewayControl
    {
        public FCKEditorSample()
        {
            InitializeComponent();
        }



        #region Component Designer generated code

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            

            mobjFCKEditor = new FCKEditor();
            mobjFCKEditor.Dock = DockStyle.Fill;

            this.Load += new EventHandler(FCKEditorSample_Load);
            this.Controls.Add(mobjFCKEditor);

        }

        private void FCKEditorSample_Load(object sender, EventArgs e)
        {
            // Check if the FCKEditor resources directory exists.
            if (Directory.Exists(this.Context.Server.MapPath("/FCKeditor")))
            {
                // Set a sample text into the FCKEditor control.
                mobjFCKEditor.Value = "<b>This is the FCKEditor control...</b>";
            }
            else
            {
                // Create a new label contrl with a proper message.
                Label objLabel = new Label("No resources supplied for FCKEditor");
                objLabel.TextAlign = ContentAlignment.MiddleCenter;
                objLabel.Font = new Font(ThemeFonts.DefaultFont, FontStyle.Bold);
                objLabel.Dock = DockStyle.Fill;

                // Clear all controls and add label.
                this.Controls.Clear();
                this.Controls.Add(objLabel);
            }
        }

        private FCKEditor mobjFCKEditor = null;
        
        #endregion

        #region IHostedApplication Members

        public void InitializeApplication()
        {
        }

        public HostedToolBarElement[] GetToolBarElements()
        {
            ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Show", new IconResourceHandle("Show.gif"), "Show"));
            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
        }

        public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {          
            string strAction = (string)objButton.Tag;
            switch (strAction)
            {
                case "Show":
                    Link.Open(new GatewayReference(this, "Show"));
                    break;
            }
        }


        #endregion

        #region IGatewayControl Members

        public IGatewayHandler GetGatewayHandler(IContext objContext, string strAction)
        {
            HttpContext.Current.Response.Write(mobjFCKEditor.Text);

            return null;
        }

        #endregion
    }
}