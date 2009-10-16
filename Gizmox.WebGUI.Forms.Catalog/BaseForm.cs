using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Catalog
{


	/// <summary>
	/// Summary description for BaseForm.
	/// </summary>
    [Serializable()]
	public abstract class BaseForm : Form
	{          

		private RootCategoryNode mobjRootCategoryNode = null;
		private Gizmox.WebGUI.Forms.Splitter mobjSplitterVert;
		
		private Gizmox.WebGUI.Forms.NavigationTabs mobjTabsMain;
		private Gizmox.WebGUI.Forms.ToolBar mobjToolBarMain;
		private Gizmox.WebGUI.Forms.Panel mobjPanelSpace;
        private Gizmox.WebGUI.Forms.Panel mobjPoweredByPanel;
		private Gizmox.WebGUI.Forms.MainMenu mobjMainMenu;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuFile;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuActions;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuHelp;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuEdit;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuExit;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuAboutVWG;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuUndo;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuRedo;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuSep2;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuCut;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuCopy;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuPaste;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuDelete;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuSep1;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuPrint;
        private Gizmox.WebGUI.Forms.StatusBar mobjStatusBar;
        private Gizmox.WebGUI.Forms.MenuItem mobjThemesMenu;

		private IHostedApplication mobjCurrentHostedApplication = null;

		private Control mobjCurrentHostedControl = null;
		private Gizmox.WebGUI.Forms.Panel mobjPanelCategories;
		private Gizmox.WebGUI.Forms.PictureBox mobjPictureBoxPoweredBy;

        private Gizmox.WebGUI.Forms.Extenders.UniqueIdExtender objUniqueId = new Gizmox.WebGUI.Forms.Extenders.UniqueIdExtender();


		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public BaseForm()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();
            InitalizeThemeMenu();

			this.mobjMainMenu.MenuClick+=new MenuEventHandler(mobjMainMenu_MenuClick);

			this.mobjPictureBoxPoweredBy.Image = new ImageResourceHandle("PoweredByLogo.jpg"); 
            this.mobjPictureBoxPoweredBy.Click += new EventHandler(mobjPictureBoxPoweredBy_Click);
            this.mobjPictureBoxPoweredBy.Cursor = Cursors.Hand;


            objUniqueId.SetUniqueId(mobjPictureBoxPoweredBy,"test1111");

            // Attach the selected-index-changed event
            this.mobjTabsMain.SelectedIndexChanged += new EventHandler(mobjTabsMain_SelectedIndexChanged);
            objUniqueId.SetUniqueId(mobjTabsMain, "fttt");
            Application.ThreadBookmarkNavigate += new ThreadBookmarkEventHandler(Application_ThreadBookmarkNavigate);
	
		}

        void mobjPictureBoxPoweredBy_Click(object sender, EventArgs e)
        {
            Link.Open("http://www.visualwebgui.com");
        }

        private void InitalizeThemeMenu()
        {
            mobjThemesMenu = new MenuItem("Themes");

            foreach (string strTheme in VWGContext.Current.Config.Themes)
            {
                MenuItem objThemeMenu = new MenuItem(strTheme);
                objThemeMenu.Tag = string.Format("Theme.{0}", strTheme);
                mobjThemesMenu.MenuItems.Add(objThemeMenu);
            }

            mobjMenuActions.MenuItems.Add(mobjThemesMenu);

            UpdateThemeMenu();
        }

        private void UpdateThemeMenu()
        {
            foreach (MenuItem objMenuItem in mobjMenuActions.MenuItems)
            {
                objMenuItem.RadioCheck = ((string)objMenuItem.Tag == VWGContext.Current.CurrentTheme);
            }
        }

        /// <summary>
        /// Handles navigation tabs selection of item by navigating to the selected
        /// category within this navigation category item
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
        void mobjTabsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check that there is a selected item
            if (mobjTabsMain.SelectedItem != null)
            {
                // Check that there are controls contained in this nav-tab
                if (mobjTabsMain.SelectedItem.Controls.Count > 0)
                {
                    // Get the selected category tree-node from within the nav-tab 
                    // treeview control and navigate to the selected control
                    // if there is any.
                    TreeView objTreeView = mobjTabsMain.SelectedItem.Controls[0] as TreeView;
                    if (objTreeView != null && objTreeView.SelectedNode!=null)
                    {
                        this.SelectCategory(objTreeView.SelectedNode.Tag as CategoryNode, true);
                    }
                }
            }
        }

        void Application_ThreadBookmarkNavigate(object sender, ThreadBookmarkEventArgs e)
        {
            if (this.Context.MainForm == this)
            {
                SelectCategory((CategoryNode)e.Data,false);
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

		#region Form Designer generated code

        protected abstract void InitialzeWorspace();

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			
			this.mobjTabsMain = new Gizmox.WebGUI.Forms.NavigationTabs();
			this.mobjSplitterVert = new Gizmox.WebGUI.Forms.Splitter();
			this.mobjToolBarMain = new Gizmox.WebGUI.Forms.ToolBar();
			this.mobjPanelSpace = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPoweredByPanel = new Panel();
			this.mobjMainMenu = new Gizmox.WebGUI.Forms.MainMenu();
			this.mobjMenuFile = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuPrint = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuSep1 = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuExit = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuEdit = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuUndo = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuRedo = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuSep2 = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuCut = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuCopy = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuPaste = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuDelete = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuActions = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuHelp = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuAboutVWG = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjPanelCategories = new Gizmox.WebGUI.Forms.Panel();
			this.mobjPictureBoxPoweredBy = new Gizmox.WebGUI.Forms.PictureBox();
            this.mobjStatusBar = new Gizmox.WebGUI.Forms.StatusBar();
			this.mobjPanelCategories.SuspendLayout();
			this.SuspendLayout();

            //
            // Initialize the workspace area
            //
            InitialzeWorspace();

			// 
			// mobjTabsMain
			// 
			this.mobjTabsMain.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjTabsMain.ClientSize = new System.Drawing.Size(237, 173);
			this.mobjTabsMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjTabsMain.Location = new System.Drawing.Point(0, 0);
			this.mobjTabsMain.Name = "mobjTabsMain";
			this.mobjTabsMain.SelectedIndex = 0;
			this.mobjTabsMain.Size = new System.Drawing.Size(237, 173);
			this.mobjTabsMain.TabIndex = 0;
			// 
			// mobjSplitterVert
			// 
			this.mobjSplitterVert.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjSplitterVert.ClientSize = new System.Drawing.Size(3, 694);
			this.mobjSplitterVert.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.mobjSplitterVert.Location = new System.Drawing.Point(240, 28);
			this.mobjSplitterVert.Name = "mobjSplitterVert";
			this.mobjSplitterVert.Size = new System.Drawing.Size(3, 694);
			this.mobjSplitterVert.TabIndex = 1;
			// 
			// mobjToolBarMain
			// 
			this.mobjToolBarMain.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
			this.mobjToolBarMain.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjToolBarMain.ButtonSize = new System.Drawing.Size(0, 0);
			this.mobjToolBarMain.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjToolBarMain.DragHandle = true;
			this.mobjToolBarMain.DropDownArrows = false;
			this.mobjToolBarMain.ImageList = null;
			this.mobjToolBarMain.Location = new System.Drawing.Point(3, 3);
			this.mobjToolBarMain.MenuHandle = true;
			this.mobjToolBarMain.Name = "mobjToolBarMain";
			this.mobjToolBarMain.RightToLeft = false;
			this.mobjToolBarMain.ShowToolTips = true;
			this.mobjToolBarMain.TabIndex = 3;
			this.mobjToolBarMain.TextAlign = Gizmox.WebGUI.Forms.ToolBarTextAlign.Right;
			// 
			// mobjPanelSpace
			// 
			this.mobjPanelSpace.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.mobjPanelSpace.ClientSize = new System.Drawing.Size(722, 3);
			this.mobjPanelSpace.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjPanelSpace.Location = new System.Drawing.Point(3, 25);
			this.mobjPanelSpace.Name = "mobjPanelSpace";
			this.mobjPanelSpace.Size = new System.Drawing.Size(722, 3);
			this.mobjPanelSpace.TabIndex = 4;
            // 
            // mobjPoweredByPanel
			// 
            this.mobjPoweredByPanel.BackColor = Color.White;
            this.mobjPoweredByPanel.ClientSize = new System.Drawing.Size(722, 3);
            this.mobjPoweredByPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            this.mobjPoweredByPanel.Location = new System.Drawing.Point(3, 25);
            this.mobjPoweredByPanel.Name = "mobjPanelSpace";
            this.mobjPoweredByPanel.Size = new System.Drawing.Size(237, 70);
            this.mobjPoweredByPanel.Controls.Add(this.mobjPictureBoxPoweredBy);
			// 
			// mobjMainMenu
			// 
			this.mobjMainMenu.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjMainMenu.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjMainMenu.Location = new System.Drawing.Point(0, 0);
			this.mobjMainMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.mobjMenuFile,
																						this.mobjMenuEdit,
																						this.mobjMenuActions,
																						this.mobjMenuHelp});
			this.mobjMainMenu.Name = "mobjMainMenu";
			// 
			// mobjMenuFile
			// 
			this.mobjMenuFile.Index = 0;
			this.mobjMenuFile.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.mobjMenuPrint,
																						this.mobjMenuSep1,
																						this.mobjMenuExit});
			this.mobjMenuFile.Text = "File";
			// 
			// mobjMenuPrint
			// 
			this.mobjMenuPrint.Index = 0;
			this.mobjMenuPrint.Tag = "Print";
			this.mobjMenuPrint.Text = "Print";
			// 
			// mobjMenuSep1
			// 
			this.mobjMenuSep1.Index = 1;
			this.mobjMenuSep1.Text = "-";
			// 
			// mobjMenuExit
			// 
			this.mobjMenuExit.Index = 2;
			this.mobjMenuExit.Tag = "Exit";
			this.mobjMenuExit.Text = "Exit";
			// 
			// mobjMenuEdit
			// 
			this.mobjMenuEdit.Index = 1;
			this.mobjMenuEdit.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.mobjMenuUndo,
																						this.mobjMenuRedo,
																						this.mobjMenuSep2,
																						this.mobjMenuCut,
																						this.mobjMenuCopy,
																						this.mobjMenuPaste,
																						this.mobjMenuDelete});
			this.mobjMenuEdit.Text = "Edit";
			// 
			// mobjMenuUndo
			// 
			this.mobjMenuUndo.Index = 0;
			this.mobjMenuUndo.Tag = "Undo";
			this.mobjMenuUndo.Text = "Undo";

			// 
			// mobjMenuRedo
			// 
			this.mobjMenuRedo.Index = 1;
			this.mobjMenuRedo.Tag = "Redo";
			this.mobjMenuRedo.Text = "Redo";
			// 
			// mobjMenuSep2
			// 
			this.mobjMenuSep2.Index = 2;
			this.mobjMenuSep2.Text = "-";
			// 
			// mobjMenuCut
			// 
			this.mobjMenuCut.Index = 3;
			this.mobjMenuCut.Tag = "Cut";
			this.mobjMenuCut.Text = "Cut";
            this.mobjMenuCut.Shortcut = Shortcut.CtrlX;
            

			// 
			// mobjMenuCopy
			// 
			this.mobjMenuCopy.Index = 4;
			this.mobjMenuCopy.Tag = "Copy";
			this.mobjMenuCopy.Text = "Copy";
            this.mobjMenuCopy.Shortcut = Shortcut.CtrlC;

			// 
			// mobjMenuPaste
			// 
			this.mobjMenuPaste.Index = 5;
			this.mobjMenuPaste.Tag = "Paste";
			this.mobjMenuPaste.Text = "Paste";
            this.mobjMenuPaste.Shortcut = Shortcut.CtrlV;

			// 
			// mobjMenuDelete
			// 
			this.mobjMenuDelete.Index = 6;
			this.mobjMenuDelete.Tag = "Delete";
			this.mobjMenuDelete.Text = "Delete";
			// 
			// mobjMenuActions
			// 
			this.mobjMenuActions.Index = 2;
			this.mobjMenuActions.Text = "Actions";
			// 
			// mobjMenuHelp
			// 
			this.mobjMenuHelp.Index = 3;
			this.mobjMenuHelp.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.mobjMenuAboutVWG});
			this.mobjMenuHelp.Text = "Help";
			// 
			// mobjMenuAboutVWG
			// 
			this.mobjMenuAboutVWG.Index = 0;
			this.mobjMenuAboutVWG.Tag = "AboutVWG";
			this.mobjMenuAboutVWG.Text = "About Visual WebGui";
			// 
			// mobjPanelCategories
			// 
			this.mobjPanelCategories.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjPanelCategories.ClientSize = new System.Drawing.Size(237, 694);
			this.mobjPanelCategories.Controls.Add(this.mobjTabsMain);
            this.mobjPanelCategories.Controls.Add(this.mobjPoweredByPanel);
			this.mobjPanelCategories.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.mobjPanelCategories.Location = new System.Drawing.Point(3, 28);
			this.mobjPanelCategories.Name = "mobjPanelCategories";
			this.mobjPanelCategories.Size = new System.Drawing.Size(237, 694);
			this.mobjPanelCategories.TabIndex = 5;
			// 
			// mobjPictureBoxPoweredBy
			// 
			this.mobjPictureBoxPoweredBy.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjPictureBoxPoweredBy.ClientSize = new System.Drawing.Size(237, 70);
			this.mobjPictureBoxPoweredBy.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
			this.mobjPictureBoxPoweredBy.Location = new System.Drawing.Point(0, 583);
			this.mobjPictureBoxPoweredBy.Name = "mobjPictureBoxPoweredBy";
			this.mobjPictureBoxPoweredBy.Size = new System.Drawing.Size(237, 70);
			this.mobjPictureBoxPoweredBy.TabIndex = 0;

            this.mobjStatusBar.Dock = DockStyle.Bottom;
            this.mobjStatusBar.ClientSize = new Size(237, 23);
            this.mobjStatusBar.Text = "Ready.";

			// 
			// BaseForm
			// 
			this.ClientSize = new System.Drawing.Size(728, 678);
			
			this.Controls.Add(this.mobjSplitterVert);
			this.Controls.Add(this.mobjPanelCategories);
			this.Controls.Add(this.mobjPanelSpace);
            this.Controls.Add(this.mobjStatusBar);
            this.Controls.Add(this.mobjToolBarMain);
			this.DockPadding.All = 3;
			this.FormStyle = Gizmox.WebGUI.Forms.FormStyle.Application;
			this.Location = new System.Drawing.Point(0, -256);
			this.Menu = this.mobjMainMenu;
			this.Size = new System.Drawing.Size(728, 678);
			this.Text = "Visual WebGui - Catalog";
			this.mobjPanelCategories.ResumeLayout(false);
			this.ResumeLayout(false);

		}




		#endregion

        protected virtual void ClearWorspace()
        {
        }

        protected virtual void AddWorspaceControl(Control objControl)
        {
        }

        private void SetThreadBookmark(CategoryNode objCategoryNode)
        {
            if (this.Context.MainForm == this)
            {
                Application.SetThreadBookmark(objCategoryNode, objCategoryNode.Text);
            }
        }


		public void SelectCategory(CategoryNode objCategoryNode,bool blnBookmark)
		{
            if (blnBookmark)
            {
                SetThreadBookmark(objCategoryNode);
            }
            
            ClearWorspace();

            if(!this.IsMdiContainer && mobjCurrentHostedControl!=null)
			{
				mobjCurrentHostedControl.Dispose();
			}

			if(objCategoryNode!=null)
			{
				Control objControl = objCategoryNode.GetCategoryInstance();
				if(objControl!=null)
				{
					objControl.Dock = DockStyle.Fill;
                    AddWorspaceControl(objControl);

					IHostedApplication objHostedApplication = objControl as IHostedApplication;
					if(objHostedApplication!=null)
					{
                        CatalogSettings.InitializeCatalogModule(objHostedApplication, this.mobjToolBarMain, new EventHandler(objToolBarButton_Click));
					}
					else
					{
						if(this.mobjToolBarMain.Buttons.Count>0)
						{
							this.mobjToolBarMain.Buttons.Clear();
							this.mobjToolBarMain.Update();
						}
					}

					mobjCurrentHostedControl = objControl;
					mobjCurrentHostedApplication = objHostedApplication;
				}
				else
				{
					this.mobjToolBarMain.Buttons.Clear();
				}
			}
		}

		protected RootCategoryNode RootCategory
		{
			get
			{
				if(mobjRootCategoryNode==null)
				{
					mobjRootCategoryNode = new RootCategoryNode(this.mobjTabsMain,this);
				}
				return mobjRootCategoryNode;
			}
		}

		private void objToolBarButton_Click(object sender, EventArgs e)
		{
			if(mobjCurrentHostedApplication!=null)
			{
                CatalogSettings.HandleApplicationHostToolBarClick(mobjCurrentHostedApplication, this.mobjToolBarMain, (ToolBarButton)sender, e);
			}
		}

		private void mobjMainMenu_MenuClick(object objSource, MenuItemEventArgs objArgs)
		{
			string strAction = objArgs.MenuItem.Tag as string;
			if(strAction!=null)
			{
                if (strAction.StartsWith("Theme."))
                {
                    this.Context.CurrentTheme = strAction.Replace("Theme.", "");
                    return;
                }
				switch(strAction)
				{
					case "Exit":
						this.Close();
						break;
					case "Print":
						MessageBox.Show(((Gizmox.WebGUI.Common.Interfaces.ISessionRegistry)this.Context.Session).Count.ToString());
						break;
                    case "AboutVWG":
                        Forms.AboutVWGForm objAboutVWGForm = new Gizmox.WebGUI.Forms.Catalog.Forms.AboutVWGForm();
                        objAboutVWGForm.ShowDialog();
                        break;
                    case "Cut":
                        MessageBox.Show("Cut");
                        break;
                    case "Copy":
                        MessageBox.Show("Copy");
                        break;
                    case "Paste":
                        MessageBox.Show("Paste");
                        break;
					default:
						MessageBox.Show(strAction);
						break;
				}
			}
		}

	
	}

	#region Classes


    [Serializable()]
    public abstract class CategoryNode
	{
		public CategoryNode(CategoryNode objParent,string strLabel)
		{
		}

		public virtual Control GetCategoryInstance()
		{
			return null;
		}

		public virtual TreeNodeCollection Nodes
		{
			get
			{
				return null;
			}
		}

		public virtual CategoryNode AddCategory(string strLabel,Type objType)
		{
			return new TypeCategoryNode(this,this.Nodes,strLabel,objType);
		}

		public virtual CategoryNode AddCategory(string strLabel,Type objType, string strIcon)
		{
			return new TypeCategoryNode(this,this.Nodes,strLabel,objType,strIcon);
		}

		public virtual CategoryNode AddCategory(string strLabel)
		{
			return new LogicalCategoryNode(this,this.Nodes,strLabel);
		}

		public virtual CategoryNode AddCategory(string strLabel,string strIcon)
		{
			return new LogicalCategoryNode(this,this.Nodes,strLabel,strIcon);
		}

		public virtual void SetDefault()
		{
		}

		protected void Expand(TreeNode objNode)
		{
			if(objNode!=null)
			{
				objNode.IsExpanded = true;
				objNode.Loaded = true;
				Expand(objNode.Parent);
			}
		}

        public virtual string Text
        {
            get
            {
                return "Category Node";
            }
        }
	}


    [Serializable()]
    public class TypeCategoryNode : CategoryNode
	{
		private TreeNodeCollection mobjNodes = null;
		private Type mobjType = null;
		private TreeNode mobjNode = null;

		public TypeCategoryNode(CategoryNode objParent,TreeNodeCollection objParebtNodes,string strLabel,Type objType) : this(objParent,objParebtNodes,strLabel,objType,"Folder.gif")
		{
		}

		public TypeCategoryNode(CategoryNode objParent,TreeNodeCollection objParebtNodes,string strLabel,Type objType,string strIcon) : base(objParent,strLabel)
		{
			mobjNode = new TreeNode(strLabel);
			mobjNode.Image = new IconResourceHandle(strIcon);
			//mobjNode.ExpandedImage = new IconResourceHandle("Interface.gif");
			mobjNode.Tag = this;
			mobjNode.IsExpanded = false;
			objParebtNodes.Add(mobjNode);
			mobjNodes = mobjNode.Nodes;
			mobjType = objType;
		}

		public override Control GetCategoryInstance()
		{
			return Activator.CreateInstance(this.mobjType) as Control;
		}

		public override TreeNodeCollection Nodes
		{
			get
			{
				return mobjNodes;
			}
		}

		public override void SetDefault()
		{
			mobjNode.TreeView.SelectedNode = mobjNode;
			Expand(mobjNode);
		}

        public override string Text
        {
            get
            {
                return mobjNode == null ? "Node" : mobjNode.Text;
            }
        }
	}


    [Serializable()]
    public class LogicalCategoryNode : CategoryNode
	{
		private TreeNodeCollection mobjNodes = null;
		private TreeNode mobjNode = null;

		public LogicalCategoryNode(CategoryNode objParent,TreeNodeCollection objParebtNodes,string strLabel) : this(objParent,objParebtNodes,strLabel,"Folders.gif")
		{
		}

		public LogicalCategoryNode(CategoryNode objParent,TreeNodeCollection objParebtNodes,string strLabel,string strIcon) : base(objParent,strLabel)
		{
			mobjNode = new TreeNode(strLabel);
			mobjNode.Image = new IconResourceHandle(strIcon);
			//mobjNode.ExpandedImage = new IconResourceHandle("Interface.gif");
			mobjNode.Tag = this;
			mobjNode.IsExpanded = false;
			objParebtNodes.Add(mobjNode);
			mobjNodes = mobjNode.Nodes;
		}

		public override Control GetCategoryInstance()
		{
			return new Categories.LogicalCategory(this);
		}

		public override TreeNodeCollection Nodes
		{
			get
			{
				return mobjNodes;
			}
		}

		public override void SetDefault()
		{
			mobjNode.TreeView.SelectedNode = mobjNode;
			Expand(mobjNode);
		}

        public override string Text
        {
            get
            {
                return mobjNode == null ? "Node" : mobjNode.Text;
            }
        }
	}


    [Serializable()]
    public class NavigationCategoryNode : CategoryNode
	{
		private TreeView mobjTreeView = null;
		private BaseForm mobjBaseForm = null;

		public NavigationCategoryNode(BaseForm objBaseForm,NavigationTabs objTabs,string strLabel) : this(objBaseForm,objTabs,strLabel,"24X24.Folders.gif")
		{

		}

		public NavigationCategoryNode(BaseForm objBaseForm,NavigationTabs objTabs,string strLabel,string strIcon) : base(null,strLabel)
		{
			mobjBaseForm = objBaseForm;

			NavigationTab objTab = new NavigationTab(strLabel);
			objTab.Image = new IconResourceHandle(strIcon);
			mobjTreeView = new TreeView();
			mobjTreeView.Dock = DockStyle.Fill;
            mobjTreeView.BorderStyle = BorderStyle.None;
			mobjTreeView.AfterSelect+=new TreeViewEventHandler(mobjTreeView_AfterSelect);
			objTab.Controls.Add(mobjTreeView);

			objTabs.TabPages.Add(objTab);
		}



		private void mobjTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			mobjBaseForm.SelectCategory(e.Node.Tag as CategoryNode,true);
            
		}

		public override TreeNodeCollection Nodes
		{
			get
			{
				return mobjTreeView.Nodes;
			}
		}
	}


    [Serializable()]
    public class RootCategoryNode : CategoryNode
	{
		private NavigationTabs mobjTabs = null;
		private BaseForm mobjBaseForm = null;

		public RootCategoryNode(NavigationTabs objTabs,BaseForm objBaseForm) : base(null,"Root")
		{
			mobjTabs = objTabs;
			mobjBaseForm = objBaseForm;
		}

		public override TreeNodeCollection Nodes
		{
			get
			{
				return null;
			}
		}

		public override CategoryNode AddCategory(string strLabel)
		{
			return new NavigationCategoryNode(mobjBaseForm,mobjTabs,strLabel);
		}

		public override CategoryNode AddCategory(string strLabel, string strIcon)
		{
			return new NavigationCategoryNode(mobjBaseForm,mobjTabs,strLabel,strIcon);
		}

		public override CategoryNode AddCategory(string strLabel, Type objType)
		{
			return new NavigationCategoryNode(mobjBaseForm,mobjTabs,strLabel);
		}

		public override CategoryNode AddCategory(string strLabel, Type objType, string strIcon)
		{
			return new NavigationCategoryNode(mobjBaseForm,mobjTabs,strLabel,strIcon);
		}

        public override string Text
        {
            get
            {
                return "Root";
            }
        }
	}


	#endregion Classes


}
