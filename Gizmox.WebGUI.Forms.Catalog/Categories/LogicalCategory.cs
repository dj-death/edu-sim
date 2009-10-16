using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories
{
	/// <summary>
	/// Summary description for LogicalCategory.
	/// </summary>

    [Serializable()]
    public class LogicalCategory : UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;
        private ListView                        mobjListView            = null;  
        private LogicalCategoryNode             mobjLogicalCategoryNode = null;    

		public LogicalCategory()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();
		}

		public LogicalCategory(LogicalCategoryNode objLogicalCategoryNode)
		{
            // Set global logical category node
            mobjLogicalCategoryNode = objLogicalCategoryNode;

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
            this.mobjListView   = new ListView();

            this.SuspendLayout();

            //
            // mobjListView
            //
            this.mobjListView.Dock = DockStyle.Fill;
            this.mobjListView.View = View.List;
            this.mobjListView.Columns.Add(new ColumnHeader("Category Items"));
            this.mobjListView.MultiSelect = false;

            // Add all the current logical node's subitems to the list
            foreach (TreeNode objTreeNode in mobjLogicalCategoryNode.Nodes)
            {
                // Create and add the list view item
                CategoryNode objCategoryNode = objTreeNode.Tag as CategoryNode;
                ListViewItem objListViewItem = new ListViewItem(objCategoryNode.Text);

                objListViewItem.Tag     = objTreeNode;
                objListViewItem.SmallImage   = new IconResourceHandle("Folder.gif"); 

                this.mobjListView.Items.Add(objListViewItem); 
            }

            // Attach double-click event
            this.mobjListView.DoubleClick += new EventHandler(mobjListView_DoubleClick);

            // Add controls
            this.Controls.Add(this.mobjListView);

            this.ResumeLayout(false);
		}

        /// <summary>
        /// Handles the DoubleClick event and navigates into this category
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        void mobjListView_DoubleClick(object sender, EventArgs e)
        {
            // Check if selected-item exists
            if (mobjListView.SelectedItem!=null)
            {
                // Get and select the matching treenode item
                TreeNode objTreeNode = mobjListView.SelectedItem.Tag as TreeNode;

                if (objTreeNode != null)
                {
                    // Ensure visibility of this treenode item
                    objTreeNode.EnsureVisible();
                    objTreeNode.TreeView.SelectedNode = objTreeNode;
                }
            }
        }

		#endregion
	}
}
