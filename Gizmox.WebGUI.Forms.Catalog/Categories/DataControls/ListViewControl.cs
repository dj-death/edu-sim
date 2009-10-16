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
	/// Summary description for ListViewControl.
	/// </summary>

    [Serializable()]
    public class ListViewControl : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.ListView mobjListView;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnFrom;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSubject;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnReceived;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnSize;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnImportant;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnOpened;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnAttached;

		private RandomData mobjRandomData = null;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ListViewControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			mobjRandomData = new RandomData();

			for(int i=0;i<80;i++)
			{
				AddItem();
			}

			//this.mobjListView.ListViewItemSorter = new ListViewItemSorter(this.mobjListView);

            foreach (ColumnHeader objCol in this.mobjListView.Columns)
            {
                objCol.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }

			// Check events
			//this.mobjListView.SelectedIndexChanged+=new EventHandler(mobjListView_SelectedIndexChanged);
			//this.mobjListView.DoubleClick+=new EventHandler(mobjListView_DoubleClick);
		}



		private void mobjListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			MessageBox.Show("mobjListView_SelectedIndexChanged");
		}

		private void mobjListView_DoubleClick(object sender, EventArgs e)
		{
			MessageBox.Show("mobjListView_DoubleClick");
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

		private void AddItem()
		{
			ListViewItem objItem = null;
			
			if(mobjRandomData.GetBoolean())
			{
				objItem = this.mobjListView.Items.Add(GetIcon("ImportantMail.gif"));
			}
			else
			{
				objItem = this.mobjListView.Items.Add("");
			}
			if(mobjRandomData.GetBoolean())
			{
				objItem.SubItems.Add(GetIcon("OpenedMail.gif"));
			}
			else
			{
				objItem.SubItems.Add(GetIcon("ClosedMail.gif"));
			}
			if(mobjRandomData.GetBoolean())
			{
				objItem.SubItems.Add(GetIcon("AttachedMail.gif"));
			}
			else
			{
				objItem.SubItems.Add("");
			}
			objItem.SubItems.Add("This is a test message.");
			objItem.SubItems.Add("test@visualwebgui.com");
			
			objItem.SubItems.Add(mobjRandomData.GetDate().ToString());
			objItem.SubItems.Add(mobjRandomData.GetSize());

            if (mobjRandomData.GetBoolean())
            {
                objItem.UseItemStyleForSubItems = false;
                objItem.SubItems[2].BackColor = Color.Yellow;
            }

            if (mobjRandomData.GetBoolean())
            {
                objItem.UseItemStyleForSubItems = false;
                objItem.SubItems[4].BackColor = Color.LightGreen;
            }
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
			this.mobjListView = new Gizmox.WebGUI.Forms.ListView();
			this.mobjColumnFrom = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjColumnSubject = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjColumnReceived = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjColumnSize = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjColumnImportant = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjColumnOpened = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjColumnAttached = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// mobjListView
			// 
			this.mobjListView.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjListView.ClientSize = new System.Drawing.Size(578, 578);
			this.mobjListView.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																						  this.mobjColumnImportant,
																						  this.mobjColumnOpened,
																						  this.mobjColumnAttached,
																						  this.mobjColumnSubject,
																						  this.mobjColumnFrom,
																						  this.mobjColumnReceived,
																						  this.mobjColumnSize});
			this.mobjListView.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListView.Location = new System.Drawing.Point(0, 0);
			this.mobjListView.Name = "mobjListView";
			this.mobjListView.Size = new System.Drawing.Size(578, 578);
			this.mobjListView.TabIndex = 0;
			this.mobjListView.UseInternalPaging = true;
			// 
			// mobjColumnFrom
			// 
			this.mobjColumnFrom.Text = "From";
			this.mobjColumnFrom.Width = 150;
			// 
			// mobjColumnSubject
			// 
			this.mobjColumnSubject.Image = null;
			this.mobjColumnSubject.Text = "Subject";
			this.mobjColumnSubject.Width = 250;
			// 
			// mobjColumnReceived
			// 
			this.mobjColumnReceived.Image = null;
			this.mobjColumnReceived.Text = "Received";
			this.mobjColumnReceived.Width = 150;
			// 
			// mobjColumnSize
			// 
			this.mobjColumnSize.Image = null;
			this.mobjColumnSize.Text = "Size";
			this.mobjColumnSize.Width = 50;
			// 
			// mobjColumnImportant
			// 
			this.mobjColumnImportant.Image = null;
			this.mobjColumnImportant.Text = "";
			this.mobjColumnImportant.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
			this.mobjColumnImportant.Width = 20;
			this.mobjColumnImportant.Image = new IconResourceHandle("Headers.Important.gif");
			// 
			// mobjColumnOpened
			// 
			this.mobjColumnOpened.Image = null;
			this.mobjColumnOpened.Text = "";
			this.mobjColumnOpened.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
			this.mobjColumnOpened.Width = 20;
			this.mobjColumnOpened.Image = new IconResourceHandle("Headers.Opened.gif");
			// 
			// mobjColumnAttached
			// 
			this.mobjColumnAttached.Image = null;
			this.mobjColumnAttached.Text = "";
			this.mobjColumnAttached.Type = Gizmox.WebGUI.Forms.ListViewColumnType.Icon;
			this.mobjColumnAttached.Width = 20;
			this.mobjColumnAttached.Image = new IconResourceHandle("Headers.Attachment.gif");
			// 
			// ListViewControl
			// 
			this.ClientSize = new System.Drawing.Size(584, 528);
			this.Controls.Add(this.mobjListView);
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

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			HostedToolBarToggleButton objHostedToolBarToggleButton = null;

			string strAction = (string)objButton.Tag;
			switch(strAction)
			{
				case "AddItem":
					AddItem();
					break;
				case "RemoveItem":
					if(this.mobjListView.Items.Count>0)
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
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "ListView class");
                    break;
			}
		}

		#endregion


	}
}
