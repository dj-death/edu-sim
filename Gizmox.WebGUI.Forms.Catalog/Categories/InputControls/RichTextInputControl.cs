using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.InputControls
{
	/// <summary>
	/// Summary description for RichTextInputControl.
	/// </summary>

    [Serializable()]
    public class RichTextInputControl : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.RichTextBox richTextBox1;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public RichTextInputControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            this.richTextBox1.Html = "<b>test</b>";

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
			this.richTextBox1 = new Gizmox.WebGUI.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.richTextBox1.ClientSize = new System.Drawing.Size(506, 506);
			this.richTextBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.richTextBox1.Html = "";
			this.richTextBox1.Location = new System.Drawing.Point(3, 3);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(506, 506);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "richTextBox1";
			// 
			// RichTextInputControl
			// 
			this.ClientSize = new System.Drawing.Size(512, 568);
			this.Controls.Add(this.richTextBox1);
			this.DockPadding.All = 3;
			this.Size = new System.Drawing.Size(512, 568);
			this.ResumeLayout(false);

		}
		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
		}

		public HostedToolBarElement[] GetToolBarElements()
		{
			ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Show", new IconResourceHandle("Show.gif"), "Show"));
            objElements.Add(new HostedToolBarButton("Print", new IconResourceHandle("Print.gif"), "Print"));
            objElements.Add(new HostedToolBarButton("Font", new IconResourceHandle("Font.gif"), "Font"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			string strAction = (string)objButton.Tag;
			switch(strAction)
			{
				case "Show":
					MessageBox.Show(this.richTextBox1.Html);
					break;
                case "Print":
                    this.richTextBox1.Print();
                    break;
                case "Font":
                    FontDialog objFont = new FontDialog();
                    objFont.Closed += new EventHandler(FontDialog_Closed);
                    objFont.ShowDialog();
                    break;
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.richTextBox1);
                    objInspectorForm.ShowDialog();
                    break;
			}
		}

        void FontDialog_Closed(object sender, EventArgs e)
        {
            FontDialog objFont = (FontDialog)sender;
            if (objFont.Font!=null)
            {
                this.richTextBox1.SelectionFont = objFont.Font;
            }
        }

		#endregion
	}
}
