using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DialogForms.Forms
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>

    [Serializable()]
    public class TreeTestForm : Form
	{
		private Gizmox.WebGUI.Forms.TreeView treeView1;
        private Gizmox.WebGUI.Forms.WorkspaceTabs workspaceTabs1;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab1;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab2;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab3;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab4;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab5;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab6;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab7;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public TreeTestForm()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
			TreeNode objRoot = new TreeNode("Root");
			treeView1.Nodes.Add(objRoot);
			for(int i=1;i<5;i++)
			{
				TreeNode objNode = new TreeNode("Node"+i.ToString());
				objRoot.Nodes.Add(objNode);

			}			
			treeView1.AfterSelect+=new TreeViewEventHandler(treeView1_AfterSelect);			
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

		#region Form Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.treeView1 = new Gizmox.WebGUI.Forms.TreeView();
            this.workspaceTabs1 = new Gizmox.WebGUI.Forms.WorkspaceTabs();
            this.workspaceTab1 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.workspaceTab2 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.workspaceTab3 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.workspaceTab4 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.workspaceTab5 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.workspaceTab6 = new Gizmox.WebGUI.Forms.WorkspaceTab();
            this.workspaceTab7 = new Gizmox.WebGUI.Forms.WorkspaceTab();
			this.workspaceTabs1.SuspendLayout();
			this.SuspendLayout();
			// 
			// treeView1
			// 
			this.treeView1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.treeView1.ClientSize = new System.Drawing.Size(336, 232);
			this.treeView1.Location = new System.Drawing.Point(16, 16);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(336, 232);
			this.treeView1.TabIndex = 0;
			// 
			// workspaceTabs1
			// 
			this.workspaceTabs1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTabs1.ClientSize = new System.Drawing.Size(648, 280);
            this.workspaceTabs1.Controls.Add(this.workspaceTab1);
			this.workspaceTabs1.Controls.Add(this.workspaceTab2);
			this.workspaceTabs1.Controls.Add(this.workspaceTab3);
			this.workspaceTabs1.Controls.Add(this.workspaceTab4);
			this.workspaceTabs1.Controls.Add(this.workspaceTab5);
			this.workspaceTabs1.Controls.Add(this.workspaceTab6);
			this.workspaceTabs1.Controls.Add(this.workspaceTab7);
			this.workspaceTabs1.Location = new System.Drawing.Point(16, 272);
			this.workspaceTabs1.Name = "workspaceTabs1";
			this.workspaceTabs1.SelectedIndex = 0;
			this.workspaceTabs1.Size = new System.Drawing.Size(648, 280);
			this.workspaceTabs1.TabIndex = 1;
			this.workspaceTabs1.CloseClick += new System.EventHandler(this.tabControl1_CloseClick);
			// 
            // workspaceTab1
			// 
            this.workspaceTab1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.workspaceTab1.ClientSize = new System.Drawing.Size(100, 100);
            this.workspaceTab1.Location = new System.Drawing.Point(4, 22);
            this.workspaceTab1.Name = "workspaceTab1";
            this.workspaceTab1.Size = new System.Drawing.Size(100, 100);
            this.workspaceTab1.TabIndex = 0;
            this.workspaceTab1.Text = "workspaceTab1";
			// 
			// tabPage2
			// 
			this.workspaceTab2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab2.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab2.Location = new System.Drawing.Point(4, 22);
			this.workspaceTab2.Name = "tabPage2";
			this.workspaceTab2.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab2.TabIndex = 1;
			this.workspaceTab2.Text = "tabPage2";
			// 
			// tabPage3
			// 
			this.workspaceTab3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab3.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab3.Location = new System.Drawing.Point(4, 22);
			this.workspaceTab3.Name = "tabPage3";
			this.workspaceTab3.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab3.TabIndex = 2;
			this.workspaceTab3.Text = "tabPage3";
			// 
			// tabPage4
			// 
			this.workspaceTab4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab4.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab4.Location = new System.Drawing.Point(4, 22);
			this.workspaceTab4.Name = "tabPage4";
			this.workspaceTab4.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab4.TabIndex = 3;
			this.workspaceTab4.Text = "tabPage4";
			// 
			// tabPage5
			// 
			this.workspaceTab5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab5.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab5.Location = new System.Drawing.Point(4, 22);
			this.workspaceTab5.Name = "tabPage5";
			this.workspaceTab5.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab5.TabIndex = 4;
			this.workspaceTab5.Text = "tabPage5";
			// 
			// tabPage6
			// 
			this.workspaceTab6.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab6.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab6.Location = new System.Drawing.Point(4, 22);
			this.workspaceTab6.Name = "tabPage6";
			this.workspaceTab6.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab6.TabIndex = 5;
			this.workspaceTab6.Text = "tabPage6";
			// 
			// tabPage7
			// 
			this.workspaceTab7.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab7.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab7.Location = new System.Drawing.Point(4, 22);
			this.workspaceTab7.Name = "tabPage7";
			this.workspaceTab7.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab7.TabIndex = 6;
			this.workspaceTab7.Text = "tabPage7";
			// 
			// TreeTestForm
			// 
			this.ClientSize = new System.Drawing.Size(800, 614);
			this.Controls.Add(this.workspaceTabs1);
			this.Controls.Add(this.treeView1);
			this.Size = new System.Drawing.Size(800, 614);
			this.workspaceTabs1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			e.Node.Nodes.Clear();			
		}

		private void tabControl1_CloseClick(object sender, System.EventArgs e)
		{
			if(workspaceTabs1.SelectedItem!=null)
			{
				workspaceTabs1.TabPages.Remove(workspaceTabs1.SelectedItem);
			}
		}		
	}
}