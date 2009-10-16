using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
	/// <summary>
	/// Summary description for DataGridViewControl.
	/// </summary>

    [Serializable()]
    public class CustomDataGridViewControl : UserControl, IHostedApplication
	{
        private DataGridView dataGridView1;
        private DataGridViewButtonColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewComboBoxColumn Column3;
        private DataGridViewImageColumn Column4;
        private DataGridViewLinkColumn Column5;
        private DataGridViewTextBoxColumn Column6;


		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public CustomDataGridViewControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            // Add rows to dataGridView1.
            this.dataGridView1.Rows.Add("My Button1", true, "aaa1", new ImageResourceHandle("Background.jpg"), "My Link1", "My Text1");
            this.dataGridView1.Rows.Add("My Button2", false, "aaa2", new ImageResourceHandle("Background.jpg"), "My Link2", "My Text2");
            this.dataGridView1.Rows.Add("My Button3", true, "aaa3", new ImageResourceHandle("Background.jpg"), "My Link3", "My Text3");
            this.dataGridView1.Rows.Add("My Button4", false, "aaa1", new ImageResourceHandle("Background.jpg"), "My Link4", "My Text4");
            this.dataGridView1.Rows.Add("My Button5", true, "aaa2", new ImageResourceHandle("Background.jpg"), "My Link5", "My Text5");
		}

		#region Component Designer generated code
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
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.Column1 = new Gizmox.WebGUI.Forms.DataGridViewButtonColumn();
            this.Column2 = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.Column5 = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.Column6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(575, 200);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Buttons";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Check Boxes";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Combo Boxes";
            this.Column3.Items.AddRange(new object[] {
            "aaa1",
            "aaa2",
            "aaa3",
            "aaa4",
            "aaa5",
            "aaa6",
            "aaa7",
            "aaa8",
            "aaa9",
            "aaa10"});
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Images";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Links";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Text Boxes";
            this.Column6.Name = "Column6";

			// 
			// DataGridViewControl
			// 
			this.ClientSize = new System.Drawing.Size(640, 600);
			this.Controls.Add(this.dataGridView1);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(640, 600);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.IsRegistered)
            {
                MessageBox.Show(e.ColumnIndex.ToString() + " , " + e.RowIndex.ToString());
            }
        }

		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
			// TODO:  Add DataGridViewControl.InitializeApplication implementation
		}

		public HostedToolBarElement[] GetToolBarElements()
		{
			ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Copy", new IconResourceHandle("Copy.gif"), "Copy"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			string strAction = (string)objButton.Tag;
			switch(strAction)
			{
				case "Copy":
                    // Copy the clipboard content to the clipboard
                    Clipboard.SetDataObject(this.dataGridView1.GetClipboardContent(TextDataFormat.Html));
                    // Send to client and clear clipboard
                    Clipboard.Update(TextDataFormat.Html);
                    break;
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.dataGridView1);
                    objInspectorForm.ShowDialog();
                    break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "DataGridView class");
                    break;
			}
		}

		#endregion
	}
}
