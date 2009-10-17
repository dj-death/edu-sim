using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using Gizmox.WebGUI.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.IO;
using Gizmox.WebGUI.Common.Resources;
using EduSim.CoreFramework.Common;
using EduSim.WebGUI.UI;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms.Catalog.Categories.DataControls;


namespace Gizmox.WebGUI.Forms.Catalog
{
    //TODO: 1. Create a Game
    //TODO: 1. Create Team for the Game
    //TODO: 1. Assign users to the team
    //TODO: 1. When the user logs in identify which team he belongs and which stage of the game he is playing
    //TODO: 1. First round of the game you start with 5 products
    //TODO: 1. During of the span of 8 games, you can create a maximum of 8 products
    [Serializable()]
	public class MainForm : BaseForm
    {
        //TODO: We need to implement ModuleManagement
        private Gizmox.WebGUI.Forms.Panel mobjPanelCategory;
        private RootCategoryNode mobjRootCategoryNode = null;
        private CategoryNode simulationHandle = null;
        private XmlElement simulationSection = null;

        public MainForm()
        {
            InitializeCatalogSections();

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            this.Load += new EventHandler(MainForm_Load);

            this.mobjMainMenu.MenuClick += new MenuEventHandler(mobjMainMenu_MenuClick);
            this.mobjTabsMain.SelectedIndexChanged += new EventHandler(mobjTabsMain_SelectedIndexChanged);
            Application.ThreadBookmarkNavigate += new ThreadBookmarkEventHandler(Application_ThreadBookmarkNavigate);
        }

        private void mobjMainMenu_MenuClick(object objSource, MenuItemEventArgs objArgs)
        {
            string strAction = objArgs.MenuItem.Tag as string;
            if (strAction != null)
            {
                if (strAction.StartsWith("Theme."))
                {
                    this.Context.CurrentTheme = strAction.Replace("Theme.", "");
                    return;
                }
                switch (strAction)
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

        protected override void InitialzeWorspace()
        {
            this.mobjPanelCategory = new Gizmox.WebGUI.Forms.Panel();

            // 
            // mobjPanelCategory
            // 
            this.mobjPanelCategory.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
            this.mobjPanelCategory.ClientSize = new System.Drawing.Size(482, 694);
            this.mobjPanelCategory.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mobjPanelCategory.Location = new System.Drawing.Point(243, 28);
            this.mobjPanelCategory.Name = "mobjPanelCategory";
            this.mobjPanelCategory.PanelType = Gizmox.WebGUI.Forms.PanelType.Titled;
            this.mobjPanelCategory.Size = new System.Drawing.Size(482, 694);
            this.mobjPanelCategory.TabIndex = 2;
            this.mobjPanelCategory.Text = "Category";

            this.Controls.Add(this.mobjPanelCategory);
        }

        protected override void ClearWorspace()
        {
            mobjPanelCategory.Controls.Clear();
        }

        protected override void AddWorspaceControl(Control objControl)
        {
            mobjPanelCategory.Controls.Add(objControl);
        }


        /// <summary>
        /// Initializes the catalog category node.
        /// </summary>
        /// <param name="objCategoryNode">The obj category node.</param>
        /// <param name="objNodeDefinition">The obj node definition.</param>
        private void InitializeCatalogCategoryNode(CategoryNode objCategoryNode, XmlElement objNodeDefinition)
        {
            // Loop all sub category nodes
            foreach (XmlElement objSubCategoryDefinition in objNodeDefinition.SelectNodes("CatalogNode"))
            {
                // The sub category node
                CategoryNode objSubCategoryNode = null;

                // If has a module defined
                // If has a module defined
                if (objSubCategoryDefinition.HasAttribute("XmlForm"))
                {
                    string objSubCatalogXmlForm = objSubCategoryDefinition.GetAttribute("XmlForm");

                    objSubCategoryNode = objCategoryNode.AddCategory(objSubCategoryDefinition.GetAttribute("Label"), objSubCatalogXmlForm, objSubCategoryDefinition.GetAttribute("Icon"));
                }
                else if (objSubCategoryDefinition.HasAttribute("Module"))
                {
                    // Try to get module type definition
                    Type objSubCatalogModuleMappedType = CatalogSettings.GetCatalogModuleTypeByModuleName(objSubCategoryDefinition.GetAttribute("Module"));
                    if (objSubCatalogModuleMappedType != null)
                    {
                        objSubCategoryNode = objCategoryNode.AddCategory(objSubCategoryDefinition.GetAttribute("Label"), objSubCatalogModuleMappedType);
                    }
                }
                else if (objSubCategoryDefinition.HasAttribute("BrixModule"))
                {
                    string objBrixModule = objSubCategoryDefinition.GetAttribute("BrixModule");

                    objSubCategoryNode = objCategoryNode.AddCategoryForBrixModule(objSubCategoryDefinition.GetAttribute("Label"), objBrixModule, objSubCategoryDefinition.GetAttribute("Icon"));
                }
                else
                {
                    objSubCategoryNode = objCategoryNode.AddCategory(objSubCategoryDefinition.GetAttribute("Label"));
                }

                if (objSubCategoryNode != null)
                {
                    // If is a defalut module
                    if (objSubCategoryDefinition.GetAttribute("Default") == "True")
                    {
                        objSubCategoryNode.SetDefault();
                    }
                }
                else
                {
                    object a = 1;
                }

                // Initialize sub module definition
                InitializeCatalogCategoryNode(objSubCategoryNode, objSubCategoryDefinition);
            }
        }


        /// <summary>
        /// Initializes the catalog sections.
        /// </summary>
        private void InitializeCatalogSections()
        {
            // Loop all catalog sections
            foreach (XmlElement objCatalogSection in CatalogSettings.CatalogSections)
            {
                LoadMainTab(objCatalogSection);
            }

            // Loop all uploadable modules...
            foreach (CatalogSettings objCatalogSettings in CatalogSettings.UploadedCatalogSections)
            {
                foreach (XmlElement objCatalogSection in objCatalogSettings.CATConfigSection.SelectNodes("CatalogTree/CatalogSection"))
                {
                    LoadMainTab(objCatalogSection);
                }
            }
        }

        private void LoadMainTab(XmlElement objCatalogSection)
        {
            // The section category node
            CategoryNode objCategoryNode = null;

            // If has icon
            if (objCatalogSection.HasAttribute("Icon"))
            {
                // Create section
                objCategoryNode = this.RootCategory.AddCategory(objCatalogSection.GetAttribute("Label"), objCatalogSection.GetAttribute("Icon"));
                if(objCatalogSection.GetAttribute("Label").Equals("Simulations"))
                {
                    simulationSection = objCatalogSection;
                    simulationHandle = objCategoryNode;
                }
            }
            else
            {
                // Create section
                objCategoryNode = this.RootCategory.AddCategory(objCatalogSection.GetAttribute("Label"));
            }

            // Initialize recursivly
            InitializeCatalogCategoryNode(objCategoryNode, objCatalogSection);
        }

        protected override void CreateInlineControl(Control objControl)
        {
            if (objControl != null)
            {
                objControl.Dock = DockStyle.Fill;
                AddWorspaceControl(objControl);

                IHostedApplication objHostedApplication = objControl as IHostedApplication;
                if (objHostedApplication != null)
                {
                    CatalogSettings.InitializeCatalogModule(objHostedApplication, this.mobjToolBarMain, new EventHandler(objToolBarButton_Click));
                }
                else
                {
                    if (this.mobjToolBarMain.Buttons.Count > 0)
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

        private void objToolBarButton_Click(object sender, EventArgs e)
        {
            if (mobjCurrentHostedApplication != null)
            {
                CatalogSettings.HandleApplicationHostToolBarClick(mobjCurrentHostedApplication, this.mobjToolBarMain, (ToolBarButton)sender, e);
            }
        }


        void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Gizmox.WebGUI.Forms.TextBox txtMeaningOfLife = new TextBox();
        private void FormLoad_AfterLogon()
        {

            txtMeaningOfLife.Text = GetMeaningOfLifeFromSecureDatabase();
            //Implement here what you usually do in Form_Load.
            BuildGameTree();
        }

        private void BuildGameTree()
        {
            UserDetails user = HttpContext.Current.Session[SessionConstants.CurrentUser] as UserDetails;

            EduSimDb db = new EduSimDb();

            (from g in db.Game
             join t in db.TeamGame on g.Id equals t.GameId
             where t.TeamUser.UserDetails == user
             select g).ToList<Game>().ForEach(o =>
            {
                CategoryNode catNode = simulationHandle.AddCategory(o.Id.ToString());

                BuildRoundTree(o.Id, catNode, user, db);
            });
        }

        private void BuildRoundTree(int gameId, CategoryNode catNode, UserDetails user, EduSimDb db)
        {
            (from r in db.Round
             join t in db.TeamGame on r.TeamGameId equals t.Id
             join g in db.Game on gameId equals g.Id
             where t.TeamUser.UserDetails == user
             select r).ToList<Round>().ForEach(o =>
             {
                 CategoryNode catNode1 = catNode.AddCategory(o.RoundCategory.RoundName + "|" + o.Id );
                 catNode1.AddCategory("R&D", typeof(RnDDataGridView));
                 catNode1.AddCategory("Marketing", typeof(MarketingDataGridView));
                 catNode1.AddCategory("Production", typeof(ProductionDataGridView));
                 catNode1.AddCategory("Finance", typeof(FinanceDataGridView));
                 catNode1.AddCategory("Reports", typeof(RnDDataGridView));
             });
        }

        private string GetMeaningOfLifeFromSecureDatabase()
        {
            return "42";
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            ///////////////////////////////////////////
            //don't do anything here that require that 
            //the user will be logged on! insted use
            //FormLoad_AfterLogon() method.
            ///////////////////////////////////////////

            //if user is not logged on - show logon screen
            if (!Context.Session.IsLoggedOn)
            {
                LogonForm objLogonPopup = new LogonForm(this);
                objLogonPopup.Closed += new EventHandler(objLogonPopup_Closed);
                objLogonPopup.ShowDialog();
            }
        }

        internal void objLogonPopup_Closed(object sender, EventArgs e)
        {
            FormLoad_AfterLogon();
        }

        public void SelectCategory(CategoryNode objCategoryNode, bool blnBookmark)
        {
            if (blnBookmark)
            {
                SetThreadBookmark(objCategoryNode);
            }

            ClearWorspace();

            if (!this.IsMdiContainer && mobjCurrentHostedControl != null)
            {
                mobjCurrentHostedControl.Dispose();
            }

            if (objCategoryNode != null)
            {
                Control objControl = objCategoryNode.GetCategoryInstance() as Control;
                if (objControl is BaseUserControl)
                {
                    (objControl as BaseUserControl).MainForm = this;
                }

                CreateInlineControl(objControl);
            }
        }

        private void SetThreadBookmark(CategoryNode objCategoryNode)
        {
            if (this.Context.MainForm == this)
            {
                Application.SetThreadBookmark(objCategoryNode, objCategoryNode.Text);
            }
        }

        private RootCategoryNode RootCategory
        {
            get
            {
                if (mobjRootCategoryNode == null)
                {
                    mobjRootCategoryNode = new RootCategoryNode(this.mobjTabsMain, this);
                }
                return mobjRootCategoryNode;
            }
        }

        void mobjTabsMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check that there is a selected item
            UserDetails user = HttpContext.Current.Session[SessionConstants.CurrentUser] as UserDetails;

            if (mobjTabsMain.SelectedIndex != 0 && user.RoleEnum == Role.Player)
            {
                if (mobjTabsMain.SelectedItem.Text.Equals(TabConstants.Administrator))
                {
                    MessageBox.Show("No permission to access this page");
                    mobjTabsMain.SelectedIndex = 0;
                }
            }

            if (mobjTabsMain.SelectedItem != null)
            {
                // Check that there are controls contained in this nav-tab
                if (mobjTabsMain.SelectedItem.Controls.Count > 0)
                {
                    // Get the selected category tree-node from within the nav-tab 
                    // treeview control and navigate to the selected control
                    // if there is any.
                    TreeView objTreeView = mobjTabsMain.SelectedItem.Controls[0] as TreeView;
                    if (objTreeView != null && objTreeView.SelectedNode != null)
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
                SelectCategory((CategoryNode)e.Data, false);
            }
        }

    }

    public abstract class CategoryNode
    {
        public CategoryNode(CategoryNode objParent, string strLabel)
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

        public virtual CategoryNode AddCategory(string strLabel, Type objType)
        {
            return new TypeCategoryNode(this, this.Nodes, strLabel, objType);
        }

        public virtual CategoryNode AddCategory(string strLabel, Type objType, string strIcon)
        {
            return new TypeCategoryNode(this, this.Nodes, strLabel, objType, strIcon);
        }

        public virtual CategoryNode AddCategory(string strLabel, string xmlForm, string strIcon)
        {
            return new TypeCategoryNode(this, this.Nodes, strLabel, xmlForm, string.Empty, strIcon);
        }

        public virtual CategoryNode AddCategoryForBrixModule(string strLabel, string brixForm, string strIcon)
        {
            return new TypeCategoryNode(this, this.Nodes, strLabel, string.Empty, brixForm, strIcon);
        }

        public virtual CategoryNode AddCategory(string strLabel)
        {
            return new LogicalCategoryNode(this, this.Nodes, strLabel);
        }

        public virtual CategoryNode AddCategory(string strLabel, string strIcon)
        {
            return new LogicalCategoryNode(this, this.Nodes, strLabel, strIcon);
        }

        public virtual void SetDefault()
        {
        }

        protected void Expand(TreeNode objNode)
        {
            if (objNode != null)
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
    public class RootCategoryNode : CategoryNode
    {
        private NavigationTabs mobjTabs = null;
        private BaseForm mobjBaseForm = null;

        public RootCategoryNode(NavigationTabs objTabs, BaseForm objBaseForm)
            : base(null, "Root")
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
            return new NavigationCategoryNode(mobjBaseForm, mobjTabs, strLabel);
        }

        public override CategoryNode AddCategory(string strLabel, string strIcon)
        {
            return new NavigationCategoryNode(mobjBaseForm, mobjTabs, strLabel, strIcon);
        }

        public override CategoryNode AddCategory(string strLabel, Type objType)
        {
            return new NavigationCategoryNode(mobjBaseForm, mobjTabs, strLabel);
        }

        public override CategoryNode AddCategory(string strLabel, Type objType, string strIcon)
        {
            return new NavigationCategoryNode(mobjBaseForm, mobjTabs, strLabel, strIcon);
        }

        public override string Text
        {
            get
            {
                return "Root";
            }
        }
    }

    [Serializable()]
    public class NavigationCategoryNode : CategoryNode
    {
        private TreeView mobjTreeView = null;
        private BaseForm mobjBaseForm = null;

        public NavigationCategoryNode(BaseForm objBaseForm, NavigationTabs objTabs, string strLabel)
            : this(objBaseForm, objTabs, strLabel, "24X24.Folders.gif")
        {

        }

        public NavigationCategoryNode(BaseForm objBaseForm, NavigationTabs objTabs, string strLabel, string strIcon)
            : base(null, strLabel)
        {
            mobjBaseForm = objBaseForm;

            NavigationTab objTab = new NavigationTab(strLabel);
            objTab.Image = new IconResourceHandle(strIcon);
            mobjTreeView = new TreeView();
            mobjTreeView.Dock = DockStyle.Fill;
            mobjTreeView.BorderStyle = BorderStyle.None;
            mobjTreeView.AfterSelect += new TreeViewEventHandler(mobjTreeView_AfterSelect);
            objTab.Controls.Add(mobjTreeView);

            objTabs.TabPages.Add(objTab);
        }



        private void mobjTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string[] split = e.Node.FullPath.Split("\\".ToCharArray());
            string[] split1 = split[1].Split("|".ToCharArray());
            HttpContext.Current.Session[SessionConstants.CurrentRound] = int.Parse(split1[1]);
            (mobjBaseForm as MainForm).SelectCategory(e.Node.Tag as CategoryNode, true);
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
    public class TypeCategoryNode : CategoryNode
    {
        private TreeNodeCollection mobjNodes = null;
        protected Type mobjType = null;
        private TreeNode mobjNode = null;
        protected string xmlForm = string.Empty;
        protected string brixModule = string.Empty;

        public TypeCategoryNode(CategoryNode objParent, TreeNodeCollection objParebtNodes, string strLabel, Type objType)
            : this(objParent, objParebtNodes, strLabel, objType, "Folder.gif")
        {
        }

        public TypeCategoryNode(CategoryNode objParent, TreeNodeCollection objParentNodes, string strLabel, string xmlForm, string brixModule, string strIcon)
            : base(objParent, strLabel)
        {
            mobjNode = new TreeNode(strLabel);
            mobjNode.Image = new IconResourceHandle(strIcon);
            //mobjNode.ExpandedImage = new IconResourceHandle("Interface.gif");
            mobjNode.Tag = this;
            mobjNode.IsExpanded = false;
            objParentNodes.Add(mobjNode);
            mobjNodes = mobjNode.Nodes;
            this.xmlForm = xmlForm;
            this.brixModule = brixModule;
        }

        public TypeCategoryNode(CategoryNode objParent, TreeNodeCollection objParebtNodes, string strLabel, Type objType, string strIcon)
            : base(objParent, strLabel)
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

        public override TreeNodeCollection Nodes
        {
            get
            {
                return mobjNodes;
            }
        }

        public override Control GetCategoryInstance()
        {
            if (!xmlForm.Equals(string.Empty))
            {
                BrixMainForm brixMainForm = null;
                XmlSerializer serializer = new XmlSerializer(typeof(BrixMainForm));
                string xmlPath = HttpContext.Current.Server.MapPath(xmlForm);
                using (FileStream fs = new FileStream(xmlPath, FileMode.Open, FileAccess.Read))
                {
                    brixMainForm = ((BrixMainForm)serializer.Deserialize(fs));
                }

                return new BrixXmlListControl(brixMainForm);
            }
            if (!brixModule.Equals(string.Empty))
            {
                return new BrixListControl(brixModule);
            }
            else
            {
                return Activator.CreateInstance(this.mobjType) as Control;
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

        public LogicalCategoryNode(CategoryNode objParent, TreeNodeCollection objParebtNodes, string strLabel)
            : this(objParent, objParebtNodes, strLabel, "Folders.gif")
        {
        }

        public LogicalCategoryNode(CategoryNode objParent, TreeNodeCollection objParebtNodes, string strLabel, string strIcon)
            : base(objParent, strLabel)
        {
            mobjNode = new TreeNode(strLabel);
            mobjNode.Image = new IconResourceHandle(strIcon);
            //mobjNode.ExpandedImage = new IconResourceHandle("Interface.gif");
            mobjNode.Tag = this;
            mobjNode.IsExpanded = false;
            objParebtNodes.Add(mobjNode);
            mobjNodes = mobjNode.Nodes;
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

        public override Control GetCategoryInstance()
        {
            return new Categories.LogicalCategory(this);
        }

        public override string Text
        {
            get
            {
                return mobjNode == null ? "Node" : mobjNode.Text;
            }
        }
    }

}