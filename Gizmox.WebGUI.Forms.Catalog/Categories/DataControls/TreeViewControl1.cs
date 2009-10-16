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
	/// Summary description for TreeViewControl.
	/// </summary>

    [Serializable()]
    public class TreeViewControl1 : UserControl, IHostedApplication
	{


		private RandomData mobjRandomData = null;

		private int mintIndex = 1;

		private Gizmox.WebGUI.Forms.TreeView treeView1;
        private Gizmox.WebGUI.Forms.ImageList objImageList;
        private Gizmox.WebGUI.Forms.ImageList stateImageList;


		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public TreeViewControl1()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();


			mobjRandomData = new RandomData();

			this.AddNodes(this.treeView1.Nodes,10);

            
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

		private void AddNodes(TreeNodeCollection objNodes,int intCount)
		{
			for(int intIndex=0;intIndex<intCount;intIndex++)
			{
				this.AddNode(objNodes,intCount);
			}
		}
		private void AddNode(TreeNodeCollection objNodes,int intCount)
		{
			TreeNode objTreeNode = new TreeNode();
			objTreeNode.Label = "Node " + mintIndex.ToString();
			objTreeNode.Image = new IconResourceHandle("Folder.gif");
			objTreeNode.IsExpanded = false;
			objNodes.Add(objTreeNode);
			mintIndex++;

			if(intCount>1)
			{
				this.AddNodes(objTreeNode.Nodes,this.mobjRandomData.GetInteger(0,intCount-1));
			}

		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.objImageList = new Gizmox.WebGUI.Forms.ImageList();
            this.stateImageList = new Gizmox.WebGUI.Forms.ImageList();
			this.treeView1 = new Gizmox.WebGUI.Forms.TreeView();
			this.SuspendLayout();
            // 
            // objImageList
            // 
            objImageList.Images.Add("Folder", new IconResourceHandle("Folder.gif"));
            objImageList.Images.Add("Folders", new IconResourceHandle("Folders.gif"));
            objImageList.ImageSize = new System.Drawing.Size(16, 16);
            // 
            // stateImageList
            // 
            stateImageList.Images.Add("Add", new IconResourceHandle("Add.gif"));
            stateImageList.Images.Add("Remove", new IconResourceHandle("Remove.gif"));
            stateImageList.ImageSize = new System.Drawing.Size(16, 16);
            stateImageList.Images.SetKeyName(0, "Add.gif");
            stateImageList.Images.SetKeyName(1, "Remove.gif");
            // 
			// treeView1
			// 
			this.treeView1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.treeView1.ClientSize = new System.Drawing.Size(602, 602);
			this.treeView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(3, 3);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(602, 602);
			this.treeView1.TabIndex = 0;
            this.treeView1.CheckBoxes = true;
            this.treeView1.ImageKey = "Folder";
            this.treeView1.ImageList = objImageList;
            this.treeView1.SelectedImageKey = "Folders";
            this.treeView1.StateImageList = stateImageList;
			// 
			// TreeViewControl
			// 
			this.ClientSize = new System.Drawing.Size(608, 544);
			this.Controls.Add(this.treeView1);
			this.DockPadding.All = 3;
			this.Size = new System.Drawing.Size(608, 544);
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
			objElements.Add(new HostedToolBarButton("Add Node",new IconResourceHandle("Add.gif"),"AddNode"));
			objElements.Add(new HostedToolBarButton("Remove Node",new IconResourceHandle("Remove.gif"),"RemoveNode"));
			objElements.Add(new HostedToolBarButton("Clear Nodes",new IconResourceHandle("Clear.gif"),"ClearNodes"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Ensure Visible", new IconResourceHandle("EnsureVisible.gif"), "EnsureVisible"));
			objElements.Add(new HostedToolBarSeperator());
			objElements.Add(new HostedToolBarToggleButton("Show Lines",new IconResourceHandle("ShowLines.gif"),"ShowLines",true));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Show Path", new IconResourceHandle("Clear.gif"), "ShowPath"));
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
				case "AddNode":
					if(this.treeView1.SelectedNode!=null)
					{
						TreeNode objTreeNode = new TreeNode();
						objTreeNode.Label = "Node " + mintIndex.ToString();
						objTreeNode.Image = new IconResourceHandle("Folder.gif");
						objTreeNode.IsExpanded = false;
						this.treeView1.SelectedNode.Nodes.Add(objTreeNode);
						mintIndex++;
					}
					break;
				case "RemoveNode":
					if(this.treeView1.SelectedNode!=null)
					{
						if(this.treeView1.SelectedNode.Parent!=null)
						{
							this.treeView1.SelectedNode.Parent.Nodes.Remove(this.treeView1.SelectedNode);
						}
						else
						{
							this.treeView1.Nodes.Remove(this.treeView1.SelectedNode);
						}
					}
					break;
                case "EnsureVisible":
                    if (this.treeView1.SelectedNode != null)
                    {
                        this.treeView1.SelectedNode.EnsureVisible();
                    }
                    break;
				case "ClearNodes":
					if(this.treeView1.SelectedNode!=null)
					{
						this.treeView1.SelectedNode.Nodes.Clear();
					}
					break;
				
				case "ShowLines":
					objHostedToolBarToggleButton = objButton as HostedToolBarToggleButton;
					if(objHostedToolBarToggleButton!=null)
					{
						this.treeView1.ShowLines = objHostedToolBarToggleButton.Pushed;
					}
					break;
                case "ShowPath":
                    if (this.treeView1.SelectedNode != null)
                    {
                        MessageBox.Show(this.treeView1.SelectedNode.FullPath);
                    }
                    break;
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.treeView1);
                    objInspectorForm.ShowDialog();
                    break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "TreeView class");
                    break;
			}
		}

		#endregion
	}
}
