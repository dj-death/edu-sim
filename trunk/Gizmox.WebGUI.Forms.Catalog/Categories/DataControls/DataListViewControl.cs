using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Dialogs;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
	/// <summary>
    /// Summary description for DataListViewControl.
	/// </summary>

    [Serializable()]
    public class DataListViewControl : UserControl, IHostedApplication
	{
        private DatabaseData mobjDatabaseData;
        private string mstrTableName = "Customers";
		private Gizmox.WebGUI.Forms.ListView mobjDataListView;

		

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public DataListViewControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            LoadGrid();

            
            
		}

        private void LoadGrid()
        {
            this.mobjDataListView.Columns.Clear();

            // Initialize dataGridView1 data source
            mobjDatabaseData = new DatabaseData();
            mobjDatabaseData.LoadTable(mstrTableName);


            this.mobjDataListView.DataMember =  "Customers";
            this.mobjDataListView.DataSource = mobjDatabaseData;
         
           
            foreach (ColumnHeader objCol in this.mobjDataListView.Columns)
            {
                objCol.Width = mobjDataListView.Width / 6;
            }
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

       

		private string GetIcon(string strName)
		{
			return (new IconResourceHandle(strName)).ToString();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjDataListView = new Gizmox.WebGUI.Forms.ListView();
            
			this.SuspendLayout();
			// 
            // mobjDataListView
			// 
			this.mobjDataListView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjDataListView.ClientSize = new System.Drawing.Size(578, 578);
			this.mobjDataListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjDataListView.Location = new System.Drawing.Point(0, 0);
			this.mobjDataListView.Name = "mobjDataListView";
			this.mobjDataListView.Size = new System.Drawing.Size(578, 578);
			this.mobjDataListView.TabIndex = 0;
			this.mobjDataListView.UseInternalPaging = true;
			// 
            // DataListViewControl
			// 
			this.ClientSize = new System.Drawing.Size(584, 528);
			this.Controls.Add(this.mobjDataListView);
			this.DockPadding.All = 3;
			this.Size = new System.Drawing.Size(584, 528);
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
			
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Change DataSource", new IconResourceHandle("MultiSelect.gif"), "ChangeDataSource"));//pintel
            
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			string strAction = (string)objButton.Tag;
			switch(strAction)
			{
                case "ChangeDataSource":
                    if (mstrTableName == "Customers")
                        mstrTableName = "Employees";
                    else
                        mstrTableName = "Customers";

                    LoadGrid();
                    break;

                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.mobjDataListView);
                    objInspectorForm.ShowDialog();
                    break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "ListView class");
                    break;
			}
		}

		#endregion


	}
}
