using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Catalog.Categories.DialogForms.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DialogForms
{
	/// <summary>
	/// Summary description for MiscellaneousForms.
	/// </summary>

    [Serializable()]
    public class MiscellaneousForms : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.Button mobjButtonFontDialog;
		private Gizmox.WebGUI.Forms.Button mobjButtonSearchDialog;
		private Gizmox.WebGUI.Forms.Button mobjButtonColorDialog;

        private ColorDialog mobjColorDialog = new ColorDialog();
        private FontDialog mobjFontDialog = new FontDialog();
        private SearchForm mobjSearchForm = new SearchForm();

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        #region IHostedApplication Members

        public void InitializeApplication()
        {
        }

        public HostedToolBarElement[] GetToolBarElements()
        {
            ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Font Dialog Properties", new IconResourceHandle("Properties.gif"), "FontDialogProperties"));
            objElements.Add(new HostedToolBarButton("Search Dialog Properties", new IconResourceHandle("Properties.gif"), "SearchDialogProperties"));
            objElements.Add(new HostedToolBarButton("Color Dialog Properties", new IconResourceHandle("Properties.gif"), "ColorDialogProperties"));
            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
        }

        public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {
            InspectorForm objInspectorForm = null;

            string strAction = (string)objButton.Tag;

            switch (strAction)
            {
                case "FontDialogProperties":
                    objInspectorForm = new InspectorForm();
                    objInspectorForm.SetObjects(this.mobjFontDialog);
                    objInspectorForm.ShowDialog();
                    break;

                case "SearchDialogProperties":
                    objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.mobjSearchForm);
                    objInspectorForm.ShowDialog();
                    break;

                case "ColorDialogProperties":
                    objInspectorForm = new InspectorForm();
                    objInspectorForm.SetObjects(this.mobjColorDialog);
                    objInspectorForm.ShowDialog();
                    break;

            }
        }

        #endregion


		public MiscellaneousForms()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
			this.mobjButtonFontDialog = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonSearchDialog = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonColorDialog = new Gizmox.WebGUI.Forms.Button();
			this.SuspendLayout();
			// 
			// mobjButtonFontDialog
			// 
			this.mobjButtonFontDialog.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjButtonFontDialog.ClientSize = new System.Drawing.Size(136, 23);
			this.mobjButtonFontDialog.Location = new System.Drawing.Point(16, 24);
			this.mobjButtonFontDialog.Name = "mobjButtonFontDialog";
			this.mobjButtonFontDialog.Size = new System.Drawing.Size(136, 23);
			this.mobjButtonFontDialog.TabIndex = 0;
			this.mobjButtonFontDialog.Text = "Font Dialog";
			this.mobjButtonFontDialog.Click += new System.EventHandler(this.mobjButtonFontDialog_Click);
			// 
			// mobjButtonSearchDialog
			// 
			this.mobjButtonSearchDialog.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjButtonSearchDialog.ClientSize = new System.Drawing.Size(136, 23);
			this.mobjButtonSearchDialog.Location = new System.Drawing.Point(16, 64);
			this.mobjButtonSearchDialog.Name = "mobjButtonSearchDialog";
			this.mobjButtonSearchDialog.Size = new System.Drawing.Size(136, 23);
			this.mobjButtonSearchDialog.TabIndex = 1;
			this.mobjButtonSearchDialog.Text = "Search Dialog";
			this.mobjButtonSearchDialog.Click += new System.EventHandler(this.mobjButtonSearchDialog_Click);
			// 
			// mobjButtonTest
			// 
			this.mobjButtonColorDialog.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjButtonColorDialog.ClientSize = new System.Drawing.Size(136, 23);
			this.mobjButtonColorDialog.Location = new System.Drawing.Point(16, 104);
			this.mobjButtonColorDialog.Name = "mobjButtonTest";
			this.mobjButtonColorDialog.Size = new System.Drawing.Size(136, 23);
			this.mobjButtonColorDialog.TabIndex = 2;
			this.mobjButtonColorDialog.Text = "Color Dialog";
			this.mobjButtonColorDialog.Click += new System.EventHandler(this.mobjButtonTest_Click);
			// 
			// MiscellaneousForms
			// 
			this.ClientSize = new System.Drawing.Size(648, 592);
			this.Controls.Add(this.mobjButtonColorDialog);
			this.Controls.Add(this.mobjButtonSearchDialog);
			this.Controls.Add(this.mobjButtonFontDialog);
			this.Size = new System.Drawing.Size(648, 592);
			this.ResumeLayout(false);

		}
		#endregion

		private void mobjButtonFontDialog_Click(object sender, System.EventArgs e)
		{
			mobjFontDialog.ShowDialog();
		}

		private void mobjButtonSearchDialog_Click(object sender, System.EventArgs e)
		{
			mobjSearchForm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			mobjSearchForm.Show();
		}

		private void mobjButtonTest_Click(object sender, System.EventArgs e)
		{
            mobjColorDialog.ShowDialog();
		}
	}
}
