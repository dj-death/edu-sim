using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Reflection;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.ActionControls
{
	/// <summary>
	/// Summary description for ToolBarControl.
	/// </summary>

    [Serializable()]
    public class ToolBarControl : UserControl
	{
		private Gizmox.WebGUI.Forms.ToolBar mobjToolBar;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ToolBarControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            ImageList objImageList = new ImageList();
            objImageList.Images.Add("Copy", new IconResourceHandle("Copy.gif"));
            objImageList.Images.Add("Add", new IconResourceHandle("Add.gif"));
            objImageList.Images.Add("Clear", new IconResourceHandle("Clear.gif"));
            objImageList.Images.Add("Close", new IconResourceHandle("Delete.gif"));
            objImageList.ImageSize = new Size(32, 32);
            this.mobjToolBar.ImageList = objImageList;
            this.mobjToolBar.MenuHandle = false;
            this.mobjToolBar.DragHandle = false;
            this.mobjToolBar.TextAlign = ToolBarTextAlign.Right;
            ToolBarButton objTestButton = new ToolBarButton("Test", "Test");

            // This will call the window.open method on the client without 
            // having to create a server callback.
            objTestButton.RegisterClientAction("open", "http://www.google.com");
            this.mobjToolBar.Buttons.Add(objTestButton);
			this.mobjToolBar.Buttons.Add(new ToolBarButton("Disabled","Disabled"));

            ContextMenu objDropDownMenu = new ContextMenu();         
            objDropDownMenu.MenuItems.Add(new MenuItem("Test1"));
            objDropDownMenu.MenuItems.Add(new MenuItem("Test2"));
            objDropDownMenu.MenuItems.Add(new MenuItem("Test3"));

            ToolBarButton objToolBarButton = new ToolBarButton("Drop", "Drop");
            objToolBarButton.Style = ToolBarButtonStyle.DropDownButton;
            objToolBarButton.DropDownMenu = objDropDownMenu;

            this.mobjToolBar.Buttons.Add(objToolBarButton);

            objToolBarButton.MenuClick += new MenuEventHandler(ToolBarButton_MenuClick);

            this.mobjToolBar.Buttons.Add(new ToolBarButton("Test2", "Test2"));

			this.mobjToolBar.Buttons[1].Enabled = false;
            this.mobjToolBar.Buttons[0].ImageKey = "Copy";
            this.mobjToolBar.Buttons[1].ImageKey = "Add";
            this.mobjToolBar.Buttons[2].ImageKey = "Close";
            this.mobjToolBar.Buttons[3].ImageKey = "Copy";

            


			this.mobjToolBar.ButtonClick+=new ToolBarButtonClickEventHandler(mobjToolBar_ButtonClick);
		}

        void ToolBarButton_MenuClick(object objSource, MenuItemEventArgs objArgs)
        {
            MessageBox.Show((string)objArgs.MenuItem.Text);
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
			this.mobjToolBar = new Gizmox.WebGUI.Forms.ToolBar();
			this.SuspendLayout();
			// 
			// mobjToolBar
			// 
			this.mobjToolBar.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
			this.mobjToolBar.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjToolBar.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjToolBar.DragHandle = true;
			this.mobjToolBar.DropDownArrows = false;
			this.mobjToolBar.Location = new System.Drawing.Point(0, 0);
			this.mobjToolBar.Name = "mobjToolBar";
			this.mobjToolBar.ShowToolTips = true;
			this.mobjToolBar.TabIndex = 0;
			this.mobjToolBar.TextAlign = Gizmox.WebGUI.Forms.ToolBarTextAlign.Right;
			// 
			// ToolBarControl
			// 
			this.ClientSize = new System.Drawing.Size(536, 488);
			this.Controls.Add(this.mobjToolBar);
			this.Size = new System.Drawing.Size(536, 488);
			this.ResumeLayout(false);

		}
		#endregion

		private void mobjToolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
		{
			MessageBox.Show(e.Button.Text);
		}
	}
}
