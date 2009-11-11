using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Dialogs;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Catalog;
using System.Collections.Generic;
using System.Reflection;
using EduSim.CoreFramework.Common;

namespace EduSim.WebGUI.UI
{
	/// <summary>
	/// Summary description for ListViewControl.
	/// </summary>

    [Serializable()]
    public class EsimXmlListControl : BaseUserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.ListView mobjListView;

        private Gizmox.WebGUI.Forms.BindingNavigator bindingNavigator1;
        private Gizmox.WebGUI.Forms.BindingSource bindingSource1;

        private DataSet listDataSet = null;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

        public EsimXmlListControl(EsimMainForm esimMainForm)
            : base(esimMainForm)
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            mobjListView.DataSource = listDataSet.Tables[0];

            bindingSource1.DataSource = mobjListView.Items;

            foreach (ColumnHeader objCol in this.mobjListView.Columns)
            {
                objCol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

			// Check events
            this.mobjListView.SelectedIndexChanged += new EventHandler(mobjListView_SelectedIndexChanged);
            this.mobjListView.DoubleClick += new EventHandler(mobjListView_DoubleClick);
        }



		private void mobjListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			//MessageBox.Show("mobjListView_SelectedIndexChanged");
		}

        private void mobjListView_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = ((((Gizmox.WebGUI.Forms.Component)((sender as ListView).SelectedItem)).Tag) as DataRowView).Row;
            MainForm.SelectCategory(typeof(EsimXmlEditControl), new object [] {EsimMainForm, row} ) ;
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
            components = new Container();
            this.bindingNavigator1 = new Gizmox.WebGUI.Forms.BindingNavigator(this.components);
            this.bindingSource1 = new Gizmox.WebGUI.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.Size = new System.Drawing.Size(505, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.BindingSource = bindingSource1;
            this.bindingNavigator1.AddStandardItems();
            this.bindingNavigator1.ButtonClick += new ToolBarButtonClickEventHandler(bindingNavigator1_ToolBarButtonClickEventHandler);

            this.mobjListView = new Gizmox.WebGUI.Forms.ListView();

            int CurrentPage = 0, count;

            listDataSet = CoreDatabaseHelper.GetODSData(EsimMainForm.TableName, 100, EsimMainForm.PrimaryKeyName, null, false, 
                ref CurrentPage, out count, null);

            ColumnHeader[] columnHeader = AddColumns();
            this.SuspendLayout();
			// 
			// mobjListView
			// 
			this.mobjListView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjListView.ClientSize = new System.Drawing.Size(578, 578);

            this.mobjListView.Columns.AddRange(columnHeader);

			this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListView.Location = new System.Drawing.Point(0, 0);
			this.mobjListView.Name = "mobjListView";
			this.mobjListView.Size = new System.Drawing.Size(578, 578);
			this.mobjListView.TabIndex = 0;
			this.mobjListView.UseInternalPaging= true;

            this.Controls.Add(this.bindingNavigator1);
            this.Size = new System.Drawing.Size(576, 648);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.bindingNavigator1.ResumeLayout();
            
            this.ClientSize = new System.Drawing.Size(584, 528);
			this.Controls.Add(this.mobjListView);
			this.DockPadding.All = 3;
			this.Size = new System.Drawing.Size(584, 528);
			this.ResumeLayout(false);

		}

        private ColumnHeader[] AddColumns()
        {
            DataTable table = listDataSet.Tables[0];

            List<ColumnHeader> columnHeaders = new List<ColumnHeader>();
            foreach(DataColumn column in table.Columns)
            {
                foreach (EsimDataEntry dataEntry in EsimMainForm.EsimDataEntries)
                {
                    if (dataEntry.Name.Equals(column.Caption))
                    {
                        columnHeaders.Add(new ColumnHeader(column.Caption, column.Caption, 20));
                    }
                    else
                    {
                        //columnHeaders.Add(new ColumnHeader(column.Caption, column.Caption, 0));
                    }
                }
            }

            return columnHeaders.ToArray();
        }
		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
		}

		public HostedToolBarElement[] GetToolBarElements()
		{
			ArrayList objElements = new ArrayList();
			objElements.Add(new HostedToolBarButton("Columns",new IconResourceHandle("Columns.gif"),"Columns"));
			objElements.Add(new HostedToolBarButton("Sorting",new IconResourceHandle("Sorting.gif"),"Sorting"));
			objElements.Add(new HostedToolBarSeperator());
			objElements.Add(new HostedToolBarToggleButton("CheckBoxes",new IconResourceHandle("CheckBoxes.gif"),"CheckBoxes"));
			objElements.Add(new HostedToolBarToggleButton("MultiSelect",new IconResourceHandle("MultiSelect.gif"),"MultiSelect"));
			objElements.Add(new HostedToolBarSeperator());
			objElements.Add(new HostedToolBarButton("Add Item",new IconResourceHandle("NewItem.gif"),"AddItem"));
			objElements.Add(new HostedToolBarButton("Remove Item",new IconResourceHandle("RemoveItem.gif"),"RemoveItem"));
			objElements.Add(new HostedToolBarButton("Clear Items",new IconResourceHandle("Clear.gif"),"ClearItems"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		#endregion

        private void bindingNavigator1_ToolBarButtonClickEventHandler(object objButton, ToolBarButtonClickEventArgs objEvent)
        {
            if (bindingNavigator1.AddNewItem == objEvent.Button)
            {
                MainForm.SelectCategory(typeof(EsimXmlEditControl), new object[] { EsimMainForm, null });
            }
            if (bindingNavigator1.DeleteItem == objEvent.Button)
            {
                Type type = Type.GetType(EsimMainForm.HandlerClass);
                MethodInfo miHandler = type.GetMethod(EsimMainForm.DeleteEvent, BindingFlags.Public | BindingFlags.Static);

                miHandler.Invoke(null, new object[] { EsimMainForm, mobjListView.SelectedItem.SubItems[0].Text });
            }
        }

        #region IHostedApplication Members


        public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {
            HostedToolBarToggleButton objHostedToolBarToggleButton = null;

            string strAction = (string)objButton.Tag;
            switch (strAction)
            {
                case "RemoveItem":
                    if (this.mobjListView.Items.Count > 0)
                    {
                        if (this.mobjListView.SelectedItem != null)
                        {
                            this.mobjListView.SelectedItem.Remove();
                        }
                    }
                    break;
                case "ClearItems":
                    this.mobjListView.Items.Clear();
                    break;
                case "Columns":
                    ListViewColumnOptions objListViewColumnOptions = new ListViewColumnOptions(this.mobjListView);
                    objListViewColumnOptions.ShowDialog();
                    break;
                case "Sorting":
                    ListViewSortingOptions objListViewSortingOptions = new ListViewSortingOptions(this.mobjListView);
                    objListViewSortingOptions.ShowDialog();
                    break;
                case "CheckBoxes":
                    objHostedToolBarToggleButton = objButton as HostedToolBarToggleButton;
                    if (objHostedToolBarToggleButton != null)
                    {
                        this.mobjListView.CheckBoxes = objHostedToolBarToggleButton.Pushed;
                    }
                    break;
                case "MultiSelect":
                    objHostedToolBarToggleButton = objButton as HostedToolBarToggleButton;
                    if (objHostedToolBarToggleButton != null)
                    {
                        this.mobjListView.MultiSelect = objHostedToolBarToggleButton.Pushed;
                    }
                    break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "ListView class");
                    break;
            }
        }

        #endregion
    }
}
