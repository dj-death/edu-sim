using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Dialogs;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
	/// <summary>
	/// Summary description for ListViewControlViews.
	/// </summary>

    [Serializable()]
    public class ListViewControlViews : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.ListView mobjListView;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader3;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader4;


		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ListViewControlViews()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

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
			this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader3 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader4 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// mobjListView
			// 
			this.mobjListView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjListView.ClientSize = new System.Drawing.Size(578, 578);
			this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																						  this.columnHeader1,
																						  this.columnHeader2,
																						  this.columnHeader3,
																						  this.columnHeader4});
			this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListView.Location = new System.Drawing.Point(3, 3);
			this.mobjListView.Name = "mobjListView";
			this.mobjListView.Size = new System.Drawing.Size(578, 578);
			this.mobjListView.TabIndex = 0;
			this.mobjListView.UseInternalPaging = true;
            this.mobjListView.DoubleClick += new EventHandler(mobjListView_DoubleClick);
            this.mobjListView.ItemCheck += new ItemCheckHandler(mobjListView_ItemCheck);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Image = null;
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 200;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Image = null;
			this.columnHeader2.Text = "Size";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Image = null;
			this.columnHeader3.Text = "Type";
			this.columnHeader3.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Image = null;
			this.columnHeader4.Text = "Modified";
			this.columnHeader4.Width = 150;
			// 
			// ListViewControlViews
			// 
			this.ClientSize = new System.Drawing.Size(584, 528);
			this.Controls.Add(this.mobjListView);
			this.DockPadding.All = 3;
			this.Size = new System.Drawing.Size(584, 528);
			this.ResumeLayout(false);

		}

        void mobjListView_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
        {
            
        }

        void mobjListView_DoubleClick(object sender, EventArgs e)
        {
            
        }
		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
            ContextMenu a = new ContextMenu();
            a.MenuItems.Add(new MenuItem("Test1"));
            a.MenuItems.Add(new MenuItem("Test2"));
            a.MenuItems.Add(new MenuItem("Test3"));
            a.MenuItems.Add(new MenuItem("Test4"));
            a.MenuItems.Add(new MenuItem("Test5"));
			DirectoryInfo objDir = new DirectoryInfo(this.Context.Config.GetDirectory("Icons"));
			foreach(FileInfo objFile in objDir.GetFiles("*.gif"))
			{
				ListViewItem objItem = this.mobjListView.Items.Add(objFile.Name);
				objItem.SmallImage = new IconResourceHandle(objFile.Name);
                objItem.LargeImage = new IconResourceHandle(objFile.Name);
				objItem.SubItems.Add(objFile.Length.ToString());
				objItem.SubItems.Add(objFile.Extension);
				objItem.SubItems.Add(objFile.LastWriteTime.ToString());
                objItem.ContextMenu = a;
			}
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
            objElements.Add(new HostedToolBarToggleButton("Large Icons View", new IconResourceHandle("IconsView.gif"), "LargeIconsView", "Views"));
            objElements.Add(new HostedToolBarToggleButton("Small Icons View", new IconResourceHandle("IconsView.gif"), "SmallIconsView", "Views"));
			objElements.Add(new HostedToolBarToggleButton("List View",new IconResourceHandle("ListView.gif"),"ListView","Views"));
			HostedToolBarToggleButton objDetailsView = new HostedToolBarToggleButton("Details View",new IconResourceHandle("DetailsView.gif"),"DetailsView","Views");
			objDetailsView.Pushed = true;
			objElements.Add(objDetailsView);
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			HostedToolBarToggleButton objHostedToolBarToggleButton = null;

			string strAction = (string)objButton.Tag;
			switch(strAction)
			{
				case "SmallIconsView":
					this.mobjListView.View = View.SmallIcon;
					break;
                case "LargeIconsView":
                    this.mobjListView.View = View.LargeIcon;
                    break;
				case "DetailsView":
					this.mobjListView.View = View.Details;
					break;
				case "ListView":
					this.mobjListView.View = View.List;
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
					if(objHostedToolBarToggleButton!=null)
					{
						this.mobjListView.CheckBoxes = objHostedToolBarToggleButton.Pushed;
					}
					break;
				case "MultiSelect":
					objHostedToolBarToggleButton = objButton as HostedToolBarToggleButton;
					if(objHostedToolBarToggleButton!=null)
					{
						this.mobjListView.MultiSelect = objHostedToolBarToggleButton.Pushed;
					}
					break;
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.mobjListView);
                    objInspectorForm.ShowDialog();
                    break;
			}
		}

		#endregion
	}
}
