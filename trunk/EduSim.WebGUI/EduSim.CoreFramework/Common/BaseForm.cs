using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Xml.Serialization;
using System.Web;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.Utilities;
using EduSim.CoreFramework.DTO;
using EduSim.Analyse.BusinessLayer;

namespace Gizmox.WebGUI.Forms.Catalog
{


	/// <summary>
	/// Summary description for BaseForm.
	/// </summary>
    [Serializable()]
	public abstract class BaseForm : Form
	{          

		private Gizmox.WebGUI.Forms.Splitter mobjSplitterVert;
		
		public Gizmox.WebGUI.Forms.NavigationTabs mobjTabsMain;
		protected Gizmox.WebGUI.Forms.ToolBar mobjToolBarMain;
		private Gizmox.WebGUI.Forms.Panel mobjPanelSpace;
        private Gizmox.WebGUI.Forms.Panel mobjPoweredByPanel;
		protected Gizmox.WebGUI.Forms.MainMenu mobjMainMenu;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuSession;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuActions;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuSave;
        private Gizmox.WebGUI.Forms.MenuItem mobjMenuSubmit;
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

		protected IHostedApplication mobjCurrentHostedApplication = null;

		protected Control mobjCurrentHostedControl = null;
		private Gizmox.WebGUI.Forms.Panel mobjPanelCategories;
		//private Gizmox.WebGUI.Forms.PictureBox mobjPictureBoxPoweredBy;

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


            //this.mobjPictureBoxPoweredBy.Image = new ImageResourceHandle("PoweredByLogo.jpg"); 
            //this.mobjPictureBoxPoweredBy.Click += new EventHandler(mobjPictureBoxPoweredBy_Click);
            //this.mobjPictureBoxPoweredBy.Cursor = Cursors.Hand;


            //objUniqueId.SetUniqueId(mobjPictureBoxPoweredBy,"test1111");

            // Attach the selected-index-changed event
            objUniqueId.SetUniqueId(mobjTabsMain, "fttt");
		}

        void mobjPictureBoxPoweredBy_Click(object sender, EventArgs e)
        {
            Link.Open("http://www.visualwebgui.com");
        }

        private void InitalizeThemeMenu()
        {
            mobjThemesMenu = new MenuItem("Themes");

            foreach (Theme strTheme in VWGContext.Current.Config.Themes)
            {
                MenuItem objThemeMenu = new MenuItem(strTheme.Name);
                objThemeMenu.Tag = string.Format("Theme.{0}", strTheme.Name);
                mobjThemesMenu.MenuItems.Add(objThemeMenu);
            }

            mobjMenuActions.MenuItems.Add(mobjThemesMenu);

            UpdateThemeMenu();
        }

        private void UpdateThemeMenu()
        {
            foreach (MenuItem objMenuItem in mobjMenuActions.MenuItems)
            {
                objMenuItem.RadioCheck = ((string)objMenuItem.Tag == VWGContext.Current.CurrentTheme.Name);
            }
        }

        /// <summary>
        /// Handles navigation tabs selection of item by navigating to the selected
        /// category within this navigation category item
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">Event arguments</param>
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
            this.mobjMenuSession = new Gizmox.WebGUI.Forms.MenuItem();
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

            this.mobjMenuSave = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjMenuSubmit = new Gizmox.WebGUI.Forms.MenuItem();

            this.mobjPanelCategories = new Gizmox.WebGUI.Forms.Panel();
            //this.mobjPictureBoxPoweredBy = new Gizmox.WebGUI.Forms.PictureBox();
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
            //this.mobjPoweredByPanel.Controls.Add(this.mobjPictureBoxPoweredBy);
            // 
            // mobjMainMenu
            // 
            this.mobjMainMenu.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.mobjMainMenu.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.mobjMainMenu.Location = new System.Drawing.Point(0, 0);
            this.mobjMainMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.mobjMenuSession,
																						this.mobjMenuEdit,
																						this.mobjMenuActions,
																						this.mobjMenuHelp});
            this.mobjMainMenu.Name = "mobjMainMenu";
            // 
            // mobjMenuFile
            // 
            this.mobjMenuSession.Index = 0;
            //this.mobjMenuSession.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
            //                                                                            this.mobjMenuExit}
            //                                                                            );
            this.mobjMenuSession.Text = "Logout";
            this.mobjMenuSession.Click += new EventHandler((sender, e) =>
            {
                HttpContext.Current.Session.Abandon();
            });

            //this.mobjMenuExit.Index = 0;
            //this.mobjMenuExit.Tag = "Exit";
            //this.mobjMenuExit.Text = "Exit";
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
            this.mobjMenuActions.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.mobjMenuSave,
																						this.mobjMenuSubmit});

            this.mobjMenuSave.Index = 0;
            this.mobjMenuSave.Tag = "Save";
            this.mobjMenuSave.Text = "Save";

            // 
            // mobjMenuRedo
            // 
            this.mobjMenuSubmit.Index = 1;
            this.mobjMenuSubmit.Tag = "Submit";
            this.mobjMenuSubmit.Text = "Submit";

            this.mobjMenuSave.Click += new EventHandler((sender, e) =>
            {
                SessionManager.SaveSessionData(HttpContext.Current.Session[SessionConstants.CurrentRound] as Round);
            });

            this.mobjMenuSubmit.Click += new EventHandler((sender, e) =>
            {
                Round round = HttpContext.Current.Session[SessionConstants.CurrentRound] as Round;
                ResultsManager.Run(round);
            });
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
            this.mobjMenuAboutVWG.Text = "About BizSim 2010";
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
            //this.mobjPictureBoxPoweredBy.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            //this.mobjPictureBoxPoweredBy.ClientSize = new System.Drawing.Size(237, 70);
            //this.mobjPictureBoxPoweredBy.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
            //this.mobjPictureBoxPoweredBy.Location = new System.Drawing.Point(0, 583);
            //this.mobjPictureBoxPoweredBy.Name = "mobjPictureBoxPoweredBy";
            //this.mobjPictureBoxPoweredBy.Size = new System.Drawing.Size(237, 70);
            //this.mobjPictureBoxPoweredBy.TabIndex = 0;

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
            this.Text = "BizSim 2010";
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


        public void SelectCategory(Type type, object[] parameter )
        {
            ClearWorspace();

            if (!this.IsMdiContainer && mobjCurrentHostedControl != null)
            {
                mobjCurrentHostedControl.Dispose();
            }

            Control objControl = Activator.CreateInstance(type, parameter) as Control;
            if (objControl is BaseUserControl)
            {
                (objControl as BaseUserControl).MainForm = this;
            }

            CreateInlineControl(objControl);
        }

        protected abstract void CreateInlineControl(Control objControl);

	
	}

}
