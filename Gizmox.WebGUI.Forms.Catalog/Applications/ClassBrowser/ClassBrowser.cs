#region Using

using System;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

#endregion 

namespace Gizmox.WebGUI.Forms.Catalog.Applications.ClassBrowser
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>

    [Serializable()]
    public class ClassBrowser : UserControl, IHostedApplication
	{

		#region Designer Members

		private Gizmox.WebGUI.Forms.Panel mobjPanelTree;
		private Gizmox.WebGUI.Forms.Panel mobjPanelNamespace;
		private Gizmox.WebGUI.Forms.TreeView mobjTreeNamespaces;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader1;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader2;
		private Gizmox.WebGUI.Forms.HeaderedPanel mobjPanelContent;
		private Gizmox.WebGUI.Forms.ContextMenu mobjTypeMenu;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuOpenType;
		private Gizmox.WebGUI.Forms.ListView mobjListTypes;
		private Gizmox.WebGUI.Forms.Label mobjLabelTypes;
		private Gizmox.WebGUI.Forms.Panel panel4;
		private Gizmox.WebGUI.Forms.TabPage tabPageConstructors;
		private Gizmox.WebGUI.Forms.TabPage tabPageProperties;
		private Gizmox.WebGUI.Forms.TabPage tabPageHierarchy;
		private Gizmox.WebGUI.Forms.TabPage tabPageImplements;
		private Gizmox.WebGUI.Forms.TabPage tabPageEvents;
		private Gizmox.WebGUI.Forms.TabPage tabPageMethods;
		private Gizmox.WebGUI.Forms.ListView mobjListMethods;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader3;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader4;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader5;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader6;
		private Gizmox.WebGUI.Forms.ListView mobjListProperties;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader7;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader8;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader9;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader10;
		private Gizmox.WebGUI.Forms.ListView mobjListConstructors;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader11;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader12;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader13;
		private Gizmox.WebGUI.Forms.ListView mobjListImplements;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader14;
		private Gizmox.WebGUI.Forms.ListView mobjListEvents;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader15;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader16;
		private Gizmox.WebGUI.Forms.ListView mobjListHierarcy;
		private Gizmox.WebGUI.Forms.ColumnHeader columnHeader17;
		private Gizmox.WebGUI.Forms.TabControl mobjTabControlTypeMembers;
        private Gizmox.WebGUI.Forms.SearchTextBox mobjSearchTextBox;

		private Gizmox.WebGUI.Forms.Splitter splitter1;
		private Gizmox.WebGUI.Forms.Label mobjLabelType;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuColumns;
		private Gizmox.WebGUI.Forms.MenuItem mobjMenuSorting;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		#endregion 

		#region C'Tor\D'Tor

		/// <summary>
		/// Creates a new <see cref="ClassBrowser"/> instance.
		/// </summary>
        public ClassBrowser()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();
		}



		#endregion 

		#region Form Designer generated code

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

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjPanelTree = new Gizmox.WebGUI.Forms.Panel();
			this.mobjTreeNamespaces = new Gizmox.WebGUI.Forms.TreeView();
			this.mobjPanelNamespace = new Gizmox.WebGUI.Forms.Panel();
            this.mobjPanelContent = new Gizmox.WebGUI.Forms.HeaderedPanel();
			this.mobjTabControlTypeMembers = new Gizmox.WebGUI.Forms.TabControl();
			this.tabPageMethods = new Gizmox.WebGUI.Forms.TabPage();
			this.mobjListMethods = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader3 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader4 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader5 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader6 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.tabPageProperties = new Gizmox.WebGUI.Forms.TabPage();
			this.mobjListProperties = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader7 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader8 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader9 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader10 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.tabPageConstructors = new Gizmox.WebGUI.Forms.TabPage();
			this.mobjListConstructors = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader11 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader12 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader13 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.tabPageImplements = new Gizmox.WebGUI.Forms.TabPage();
			this.mobjListImplements = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader14 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.tabPageEvents = new Gizmox.WebGUI.Forms.TabPage();
			this.mobjListEvents = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader15 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.columnHeader16 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.tabPageHierarchy = new Gizmox.WebGUI.Forms.TabPage();
			this.mobjListHierarcy = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader17 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjLabelType = new Gizmox.WebGUI.Forms.Label();
			this.panel4 = new Gizmox.WebGUI.Forms.Panel();
			this.mobjListTypes = new Gizmox.WebGUI.Forms.ListView();
			this.columnHeader2 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjLabelTypes = new Gizmox.WebGUI.Forms.Label();
			this.columnHeader1 = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjTypeMenu = new Gizmox.WebGUI.Forms.ContextMenu();
			this.mobjMenuOpenType = new Gizmox.WebGUI.Forms.MenuItem();
            this.mobjSearchTextBox = new Gizmox.WebGUI.Forms.SearchTextBox();


            
			this.splitter1 = new Gizmox.WebGUI.Forms.Splitter();
			this.mobjMenuColumns = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjMenuSorting = new Gizmox.WebGUI.Forms.MenuItem();
			this.mobjPanelTree.SuspendLayout();
			this.mobjPanelNamespace.SuspendLayout();
			this.mobjPanelContent.SuspendLayout();
			this.mobjTabControlTypeMembers.SuspendLayout();
			this.tabPageMethods.SuspendLayout();
			this.tabPageProperties.SuspendLayout();
			this.tabPageConstructors.SuspendLayout();
			this.tabPageImplements.SuspendLayout();
			this.tabPageEvents.SuspendLayout();
			this.tabPageHierarchy.SuspendLayout();
			this.SuspendLayout();
			// 
			// mobjPanelTree
			// 
			this.mobjPanelTree.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjPanelTree.ClientSize = new System.Drawing.Size(200, 544);
			this.mobjPanelTree.Controls.Add(this.mobjTreeNamespaces);
			this.mobjPanelTree.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.mobjPanelTree.DockPadding.All = 0;
			this.mobjPanelTree.DockPadding.Bottom = 0;
			this.mobjPanelTree.DockPadding.Left = 0;
			this.mobjPanelTree.DockPadding.Right = 0;
			this.mobjPanelTree.DockPadding.Top = 0;
			this.mobjPanelTree.Location = new System.Drawing.Point(5, 51);
			this.mobjPanelTree.Name = "mobjPanelTree";
			this.mobjPanelTree.PanelType = Gizmox.WebGUI.Forms.PanelType.Titled;
			this.mobjPanelTree.Size = new System.Drawing.Size(200, 544);
			this.mobjPanelTree.Text = "Namespaces";
			// 
			// mobjTreeNamespaces
			// 
			this.mobjTreeNamespaces.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjTreeNamespaces.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
			this.mobjTreeNamespaces.ClientSize = new System.Drawing.Size(200, 200);
			this.mobjTreeNamespaces.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjTreeNamespaces.Location = new System.Drawing.Point(0, 0);
			this.mobjTreeNamespaces.Name = "mobjTreeNamespaces";
			this.mobjTreeNamespaces.Size = new System.Drawing.Size(200, 200);
			this.mobjTreeNamespaces.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.mobjTreeNamespaces_AfterSelect);
			this.mobjTreeNamespaces.BeforeExpand += new Gizmox.WebGUI.Forms.TreeViewCancelEventHandler(this.mobjTreeNamespaces_BeforeExpand);
			// 
			// mobjPanelNamespace
			// 
			this.mobjPanelNamespace.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjPanelNamespace.ClientSize = new System.Drawing.Size(387, 544);
			this.mobjPanelNamespace.Controls.Add(this.mobjPanelContent);
			this.mobjPanelNamespace.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjPanelNamespace.DockPadding.All = 0;
			this.mobjPanelNamespace.DockPadding.Bottom = 0;
			this.mobjPanelNamespace.DockPadding.Left = 0;
			this.mobjPanelNamespace.DockPadding.Right = 0;
			this.mobjPanelNamespace.DockPadding.Top = 0;
			this.mobjPanelNamespace.Location = new System.Drawing.Point(208, 51);
			this.mobjPanelNamespace.Name = "mobjPanelNamespace";
			this.mobjPanelNamespace.Size = new System.Drawing.Size(387, 544);
			// 
			// mobjPanelContent
			// 
			this.mobjPanelContent.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjPanelContent.ClientSize = new System.Drawing.Size(387, 387);
			this.mobjPanelContent.Controls.Add(this.mobjTabControlTypeMembers);
			this.mobjPanelContent.Controls.Add(this.mobjLabelType);
			this.mobjPanelContent.Controls.Add(this.panel4);
			this.mobjPanelContent.Controls.Add(this.mobjListTypes);
			this.mobjPanelContent.Controls.Add(this.mobjLabelTypes);
			this.mobjPanelContent.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjPanelContent.DockPadding.All = 5;
			this.mobjPanelContent.DockPadding.Bottom = 5;
			this.mobjPanelContent.DockPadding.Left = 5;
			this.mobjPanelContent.DockPadding.Right = 5;
			this.mobjPanelContent.DockPadding.Top = 5;
			this.mobjPanelContent.Location = new System.Drawing.Point(0, 0);
			this.mobjPanelContent.Name = "mobjPanelContent";
			this.mobjPanelContent.PanelType = Gizmox.WebGUI.Forms.PanelType.Titled;
			this.mobjPanelContent.Size = new System.Drawing.Size(387, 387);


            this.mobjSearchTextBox.WatermarkText = "Search types...";
            this.mobjSearchTextBox.Width = 130;
            this.mobjSearchTextBox.Height = 20;
            this.mobjSearchTextBox.Margin = new Padding(0, 2, 0, 0);
            this.mobjSearchTextBox.Search += new EventHandler(mobjSearchTextBox_Search);
            this.mobjPanelContent.Header = this.mobjSearchTextBox;

			// 
			// mobjTabControlTypeMembers
			// 
			this.mobjTabControlTypeMembers.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjTabControlTypeMembers.ClientSize = new System.Drawing.Size(377, 119);
			this.mobjTabControlTypeMembers.Controls.Add(this.tabPageMethods);
			this.mobjTabControlTypeMembers.Controls.Add(this.tabPageProperties);
			this.mobjTabControlTypeMembers.Controls.Add(this.tabPageConstructors);
			this.mobjTabControlTypeMembers.Controls.Add(this.tabPageImplements);
			this.mobjTabControlTypeMembers.Controls.Add(this.tabPageEvents);
			this.mobjTabControlTypeMembers.Controls.Add(this.tabPageHierarchy);
			this.mobjTabControlTypeMembers.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjTabControlTypeMembers.Location = new System.Drawing.Point(5, 263);
			this.mobjTabControlTypeMembers.Name = "mobjTabControlTypeMembers";
			this.mobjTabControlTypeMembers.SelectedIndex = 0;
			this.mobjTabControlTypeMembers.Size = new System.Drawing.Size(377, 119);
			// 
			// tabPageMethods
			// 
			this.tabPageMethods.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.tabPageMethods.ClientSize = new System.Drawing.Size(100, 100);
			this.tabPageMethods.Controls.Add(this.mobjListMethods);
			this.tabPageMethods.DockPadding.All = 5;
			this.tabPageMethods.DockPadding.Bottom = 5;
			this.tabPageMethods.DockPadding.Left = 5;
			this.tabPageMethods.DockPadding.Right = 5;
			this.tabPageMethods.DockPadding.Top = 5;
			this.tabPageMethods.Location = new System.Drawing.Point(4, 22);
			this.tabPageMethods.Name = "tabPageMethods";
			this.tabPageMethods.Size = new System.Drawing.Size(100, 100);
			this.tabPageMethods.Text = "Methods ";
            this.tabPageMethods.Image = new IconResourceHandle("Method.gif");
			// 
			// mobjListMethods
			// 
			this.mobjListMethods.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjListMethods.ClientSize = new System.Drawing.Size(90, 90);
			this.mobjListMethods.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																							 this.columnHeader3,
																							 this.columnHeader4,
																							 this.columnHeader5,
																							 this.columnHeader6});
			this.mobjListMethods.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListMethods.Location = new System.Drawing.Point(5, 5);
			this.mobjListMethods.Name = "mobjListMethods";
			this.mobjListMethods.Size = new System.Drawing.Size(90, 90);
			this.mobjListMethods.UseInternalPaging = true;
            this.mobjListMethods.GridLines = false;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Name";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Visibility";
			this.columnHeader4.Width = 150;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Returns";
			this.columnHeader5.Width = 150;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Parameters";
			this.columnHeader6.Width = 150;
			// 
			// tabPageProperties
			// 
			this.tabPageProperties.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.tabPageProperties.ClientSize = new System.Drawing.Size(100, 100);
			this.tabPageProperties.Controls.Add(this.mobjListProperties);
			this.tabPageProperties.DockPadding.All = 5;
			this.tabPageProperties.DockPadding.Bottom = 5;
			this.tabPageProperties.DockPadding.Left = 5;
			this.tabPageProperties.DockPadding.Right = 5;
			this.tabPageProperties.DockPadding.Top = 5;
			this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
			this.tabPageProperties.Name = "tabPageProperties";
			this.tabPageProperties.Size = new System.Drawing.Size(100, 100);
			this.tabPageProperties.Text = "Properties ";
            this.tabPageProperties.Image = new IconResourceHandle("Member.gif");
			// 
			// mobjListProperties
			// 
			this.mobjListProperties.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjListProperties.ClientSize = new System.Drawing.Size(90, 90);
			this.mobjListProperties.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																								this.columnHeader7,
																								this.columnHeader8,
																								this.columnHeader9,
																								this.columnHeader10});
			this.mobjListProperties.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListProperties.Location = new System.Drawing.Point(5, 5);
			this.mobjListProperties.Name = "mobjListProperties";
			this.mobjListProperties.Size = new System.Drawing.Size(90, 90);
			this.mobjListProperties.UseInternalPaging = true;
            this.mobjListProperties.GridLines = false;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Name";
			this.columnHeader7.Width = 150;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Visibility";
			this.columnHeader8.Width = 150;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Type";
			this.columnHeader9.Width = 150;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Accessibility";
			this.columnHeader10.Width = 150;
			// 
			// tabPageConstructors
			// 
			this.tabPageConstructors.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.tabPageConstructors.ClientSize = new System.Drawing.Size(100, 100);
			this.tabPageConstructors.Controls.Add(this.mobjListConstructors);
			this.tabPageConstructors.DockPadding.All = 5;
			this.tabPageConstructors.DockPadding.Bottom = 5;
			this.tabPageConstructors.DockPadding.Left = 5;
			this.tabPageConstructors.DockPadding.Right = 5;
			this.tabPageConstructors.DockPadding.Top = 5;
			this.tabPageConstructors.Location = new System.Drawing.Point(4, 22);
			this.tabPageConstructors.Name = "tabPageConstructors";
			this.tabPageConstructors.Size = new System.Drawing.Size(100, 100);
			this.tabPageConstructors.Text = "Constructors ";
            this.tabPageConstructors.Image = new IconResourceHandle("Method.gif");
			// 
			// mobjListConstructors
			// 
			this.mobjListConstructors.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjListConstructors.ClientSize = new System.Drawing.Size(90, 90);
			this.mobjListConstructors.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																								  this.columnHeader11,
																								  this.columnHeader12,
																								  this.columnHeader13});
			this.mobjListConstructors.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListConstructors.Location = new System.Drawing.Point(5, 5);
			this.mobjListConstructors.Name = "mobjListConstructors";
			this.mobjListConstructors.Size = new System.Drawing.Size(90, 90);
			this.mobjListConstructors.UseInternalPaging = true;

            this.mobjListConstructors.GridLines = false;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Name";
			this.columnHeader11.Width = 150;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Visibility";
			this.columnHeader12.Width = 150;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Parameters";
			this.columnHeader13.Width = 150;
			// 
			// tabPageImplements
			// 
			this.tabPageImplements.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.tabPageImplements.ClientSize = new System.Drawing.Size(100, 100);
			this.tabPageImplements.Controls.Add(this.mobjListImplements);
			this.tabPageImplements.DockPadding.All = 5;
			this.tabPageImplements.DockPadding.Bottom = 5;
			this.tabPageImplements.DockPadding.Left = 5;
			this.tabPageImplements.DockPadding.Right = 5;
			this.tabPageImplements.DockPadding.Top = 5;
			this.tabPageImplements.Location = new System.Drawing.Point(4, 22);
			this.tabPageImplements.Name = "tabPageImplements";
			this.tabPageImplements.Size = new System.Drawing.Size(100, 100);
			this.tabPageImplements.Text = "Implements ";
            this.tabPageImplements.Image = new IconResourceHandle("Interface.gif");
			// 
			// mobjListImplements
			// 
			this.mobjListImplements.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjListImplements.ClientSize = new System.Drawing.Size(90, 90);
			this.mobjListImplements.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																								this.columnHeader14});
			this.mobjListImplements.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListImplements.Location = new System.Drawing.Point(5, 5);
			this.mobjListImplements.Name = "mobjListImplements";
			this.mobjListImplements.Size = new System.Drawing.Size(90, 90);
			this.mobjListImplements.UseInternalPaging = true;
            this.mobjListImplements.GridLines = false;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Name";
			this.columnHeader14.Width = 250;
			// 
			// tabPageEvents
			// 
			this.tabPageEvents.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.tabPageEvents.ClientSize = new System.Drawing.Size(100, 100);
			this.tabPageEvents.Controls.Add(this.mobjListEvents);
			this.tabPageEvents.DockPadding.All = 5;
			this.tabPageEvents.DockPadding.Bottom = 5;
			this.tabPageEvents.DockPadding.Left = 5;
			this.tabPageEvents.DockPadding.Right = 5;
			this.tabPageEvents.DockPadding.Top = 5;
			this.tabPageEvents.Location = new System.Drawing.Point(4, 22);
			this.tabPageEvents.Name = "tabPageEvents";
			this.tabPageEvents.Size = new System.Drawing.Size(100, 100);
			this.tabPageEvents.Text = "Events ";
            this.tabPageEvents.Image = new IconResourceHandle("Event.gif");
			// 
			// mobjListEvents
			// 
			this.mobjListEvents.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjListEvents.ClientSize = new System.Drawing.Size(90, 90);
			this.mobjListEvents.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																							this.columnHeader15,
																							this.columnHeader16});
			this.mobjListEvents.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListEvents.Location = new System.Drawing.Point(5, 5);
			this.mobjListEvents.Name = "mobjListEvents";
			this.mobjListEvents.Size = new System.Drawing.Size(90, 90);
			this.mobjListEvents.UseInternalPaging = true;
            this.mobjListEvents.GridLines = false;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Name";
			this.columnHeader15.Width = 150;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "Type";
			this.columnHeader16.Width = 150;
			// 
			// tabPageHierarchy
			// 
			this.tabPageHierarchy.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.tabPageHierarchy.ClientSize = new System.Drawing.Size(100, 100);
			this.tabPageHierarchy.Controls.Add(this.mobjListHierarcy);
			this.tabPageHierarchy.DockPadding.All = 5;
			this.tabPageHierarchy.DockPadding.Bottom = 5;
			this.tabPageHierarchy.DockPadding.Left = 5;
			this.tabPageHierarchy.DockPadding.Right = 5;
			this.tabPageHierarchy.DockPadding.Top = 5;
			this.tabPageHierarchy.Location = new System.Drawing.Point(4, 22);
			this.tabPageHierarchy.Name = "tabPageHierarchy";
			this.tabPageHierarchy.Size = new System.Drawing.Size(100, 100);
			this.tabPageHierarchy.Text = "Hierarchy ";
            this.tabPageHierarchy.Image = new IconResourceHandle("Class.gif");
			// 
			// mobjListHierarcy
			// 
			this.mobjListHierarcy.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjListHierarcy.ClientSize = new System.Drawing.Size(90, 90);
			this.mobjListHierarcy.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																							  this.columnHeader17});
			this.mobjListHierarcy.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.mobjListHierarcy.Location = new System.Drawing.Point(5, 5);
			this.mobjListHierarcy.Name = "mobjListHierarcy";
			this.mobjListHierarcy.Size = new System.Drawing.Size(90, 90);
			this.mobjListHierarcy.UseInternalPaging = true;
            this.mobjListHierarcy.GridLines = false;
			// 
			// columnHeader17
			// 
			this.columnHeader17.Text = "Name";
			this.columnHeader17.Width = 250;
			// 
			// mobjLabelType
			// 
			this.mobjLabelType.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjLabelType.ClientSize = new System.Drawing.Size(377, 23);
			this.mobjLabelType.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjLabelType.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelType.Location = new System.Drawing.Point(5, 240);
			this.mobjLabelType.Name = "mobjLabelType";
			this.mobjLabelType.Size = new System.Drawing.Size(377, 23);
			this.mobjLabelType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panel4
			// 
			this.panel4.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.panel4.ClientSize = new System.Drawing.Size(377, 8);
			this.panel4.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.panel4.DockPadding.All = 0;
			this.panel4.DockPadding.Bottom = 0;
			this.panel4.DockPadding.Left = 0;
			this.panel4.DockPadding.Right = 0;
			this.panel4.DockPadding.Top = 0;
			this.panel4.Location = new System.Drawing.Point(5, 232);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(377, 8);
			// 
			// mobjListTypes
			// 
			this.mobjListTypes.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjListTypes.ClientSize = new System.Drawing.Size(377, 204);
			this.mobjListTypes.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																						   this.columnHeader2});
			this.mobjListTypes.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjListTypes.Location = new System.Drawing.Point(5, 28);
			this.mobjListTypes.Name = "mobjListTypes";
			this.mobjListTypes.Size = new System.Drawing.Size(377, 204);
			this.mobjListTypes.UseInternalPaging = true;
			this.mobjListTypes.SelectedIndexChanged += new System.EventHandler(this.mobjListTypes_SelectedIndexChanged);
            this.mobjListTypes.GridLines = false;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 300;
			// 
			// mobjLabelTypes
			// 
			this.mobjLabelTypes.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.mobjLabelTypes.ClientSize = new System.Drawing.Size(377, 23);
			this.mobjLabelTypes.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.mobjLabelTypes.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelTypes.Location = new System.Drawing.Point(5, 5);
			this.mobjLabelTypes.Name = "mobjLabelTypes";
			this.mobjLabelTypes.Size = new System.Drawing.Size(377, 23);
			this.mobjLabelTypes.Text = "Types:";
			this.mobjLabelTypes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 300;
			// 
			// mobjTypeMenu
			// 
			this.mobjTypeMenu.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.mobjMenuOpenType});
			// 
			// mobjMenuOpenType
			// 
			this.mobjMenuOpenType.Tag = "OpenType";
			this.mobjMenuOpenType.Text = "Open";


			// 
			// splitter1
			// 
			this.splitter1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.splitter1.ClientSize = new System.Drawing.Size(3, 544);
			this.splitter1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.splitter1.Location = new System.Drawing.Point(205, 51);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 544);
			// 
			// mobjMenuColumns
			// 
			this.mobjMenuColumns.Text = "Columns";
			// 
			// mobjMenuSorting
			// 
			this.mobjMenuSorting.Text = "Sorting";
			// 
			// Console
			// 
			this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.ClientSize = new System.Drawing.Size(600, 494);
			this.Controls.Add(this.mobjPanelNamespace);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.mobjPanelTree);
			this.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
			this.DockPadding.All = 3;
			this.Location = new System.Drawing.Point(0, -37);
			this.Size = new System.Drawing.Size(600, 494);
			this.Load += new System.EventHandler(this.Console_Load);
			this.mobjPanelTree.ResumeLayout(false);
			this.mobjPanelNamespace.ResumeLayout(false);
			this.mobjPanelContent.ResumeLayout(false);
			this.mobjTabControlTypeMembers.ResumeLayout(false);
			this.tabPageMethods.ResumeLayout(false);
			this.tabPageProperties.ResumeLayout(false);
			this.tabPageConstructors.ResumeLayout(false);
			this.tabPageImplements.ResumeLayout(false);
			this.tabPageEvents.ResumeLayout(false);
			this.tabPageHierarchy.ResumeLayout(false);
			this.ResumeLayout(false);

		}

        void mobjSearchTextBox_Search(object sender, EventArgs e)
        {
            MessageBox.Show(this.mobjSearchTextBox.Text);
        }
		#endregion

		#region Methods

		#region Events

		private void Console_Load(object sender, System.EventArgs e)
		{
			LoadNamespaces(mobjTreeNamespaces.Nodes,ConsoleInfo.Namespaces);
		}

		private void mobjTreeNamespaces_BeforeExpand(object sender, Gizmox.WebGUI.Forms.TreeViewCancelEventArgs e)
		{
			if(!e.Node.Loaded)
			{
				NamespaceInfo objNamespace = e.Node.Tag as NamespaceInfo;
				if(objNamespace!=null)
				{
					LoadNamespaces(e.Node.Nodes,objNamespace.Namespaces);
				}
				e.Node.Loaded = true;
			}
		}

		private void mobjTreeNamespaces_AfterSelect(object sender, Gizmox.WebGUI.Forms.TreeViewEventArgs e)
		{
			ClearMembers();
			mobjListTypes.Items.Clear();

			NamespaceInfo objNamespace = e.Node.Tag as NamespaceInfo;
			if(objNamespace!=null)
			{
				foreach(Type objType in objNamespace.Types)
				{

					ListViewItem objItem = mobjListTypes.Items.Add(objType.Name);
					objItem.Tag = objType;
					objItem.ContextMenu = mobjTypeMenu;

					if(objType.IsInterface)
					{
                        objItem.SmallImage = new IconResourceHandle("Interface.gif");
					}
					else
					{
                        objItem.SmallImage = new IconResourceHandle("Class.gif");
					}


				}
			}


			mobjPanelContent.Text = objNamespace.FullName;
		}

		private void mobjListTypes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			ClearMembers();

			if(mobjListTypes.SelectedItem!=null)
			{
				Type objSelectedType = mobjListTypes.SelectedItem.Tag as Type;
				if(objSelectedType!=null)
				{
					SetCurrentType(objSelectedType);
				}
			}
		}

		

		private void objSearchForm_Closed(object sender, EventArgs e)
		{
			SearchForm objSearchForm = (SearchForm)sender;
			if(objSearchForm.SelectedItem!=null)
			{
				Type objType = objSearchForm.SelectedItem as Type;
				if(objType!=null)
				{	
					SetCurrentNamespace(ConsoleInfo.GetNamespaces(objType.Namespace));

					foreach(ListViewItem objListItem in mobjListTypes.Items)
					{
						if(objListItem.Tag==objType)
						{
							mobjListTypes.SelectedItem = objListItem;

							SetCurrentType(objType);
							break;
						}
					}
				}

				NamespaceInfo objNamespaceInfo = objSearchForm.SelectedItem as NamespaceInfo;
				if(objNamespaceInfo!=null)
				{	
					SetCurrentNamespace(ConsoleInfo.GetNamespaces(objNamespaceInfo.FullName));
				}
			}
		}

		#endregion 

		#region Data

		private void ClearMembers()
		{
			mobjListConstructors.Items.Clear();
			mobjListEvents.Items.Clear();
			mobjListHierarcy.Items.Clear();
			mobjListImplements.Items.Clear();
			mobjListMethods.Items.Clear();
			mobjListProperties.Items.Clear();
			mobjTabControlTypeMembers.Update();
		}

		private void LoadNamespaces(TreeNodeCollection objNodes,ICollection objNamespaces)
		{

			objNodes.Clear();
			foreach(NamespaceInfo objNamespace in objNamespaces) 
			{
				TreeNode objTreeNode = new TreeNode();
				objTreeNode.Tag = objNamespace;
				objTreeNode.Text = objNamespace.Name;
				objTreeNode.Image = new IconResourceHandle("Namespace.gif");
				objTreeNode.Loaded = !objNamespace.HasNamespaces;
				objTreeNode.IsExpanded = !objNamespace.HasNamespaces;
				objTreeNode.HasNodes = objNamespace.HasNamespaces;
				objNodes.Add(objTreeNode);
			}
		}

		private void SetCurrentType(Type objSelectedType)
		{
			ListViewItem objListItem = null;

			mobjLabelType.Text = "Type: " + objSelectedType.FullName;

			MethodInfo[] objMethods = objSelectedType.GetMethods();
			foreach(MethodInfo objMethod in objMethods)
			{
				objListItem = mobjListMethods.Items.Add(objMethod.Name);
				objListItem.SubItems.Add(GetVisibility(objMethod.IsPublic,objMethod.IsPrivate,objMethod.IsFamily));
				objListItem.SubItems.Add(objMethod.ReturnType.Name);
				objListItem.SubItems.Add(ConsoleInfo.GetParameters(objMethod));
                objListItem.SmallImage = new IconResourceHandle("Method.gif");
			}

			PropertyInfo[] objProperties = objSelectedType.GetProperties();
			foreach(PropertyInfo objProperty in objProperties)
			{
				objListItem = mobjListProperties.Items.Add(objProperty.Name);
				MethodInfo objGetMethod = objProperty.GetGetMethod();
				if(objGetMethod!=null)
				{
					objListItem.SubItems.Add(GetVisibility(objGetMethod.IsPublic,objGetMethod.IsPrivate,objGetMethod.IsFamily));
				}
				else
				{
					objListItem.SubItems.Add("Unknown");
				}
				objListItem.SubItems.Add(objProperty.PropertyType.Name);

                objListItem.SmallImage = new IconResourceHandle("Member.gif");
			}



			EventInfo[] objEvents = objSelectedType.GetEvents();
			foreach(EventInfo objEvent in objEvents)
			{
				objListItem = mobjListEvents.Items.Add(objEvent.Name);
                objListItem.SmallImage = new IconResourceHandle("Event.gif");
			}

			ConstructorInfo[] objConstructors = objSelectedType.GetConstructors();
			foreach(ConstructorInfo objConstructor in objConstructors)
			{
				objListItem = mobjListConstructors.Items.Add(objConstructor.Name);
                objListItem.SmallImage = new IconResourceHandle("Method.gif");
			}

			Type[] objInterfaces = objSelectedType.GetInterfaces();
			foreach(Type objInterface in objInterfaces)
			{
				objListItem = mobjListImplements.Items.Add(objInterface.Name);
                objListItem.SmallImage = new IconResourceHandle("Interface.gif");
			}

			Type[] objHierarcyObjects = ConsoleInfo.GetHierarcyObjects(objSelectedType);
			foreach(Type objHierarcyObject in objHierarcyObjects)
			{
				objListItem = mobjListHierarcy.Items.Add(objHierarcyObject.Name);
				objListItem.SmallImage = new IconResourceHandle("Class.gif");
			}
		}



		private void SetCurrentNamespace(ICollection objNamespaces)
		{
			if(objNamespaces.Count>0)
			{
				TreeNodeCollection objTreeNodes = mobjTreeNamespaces.Nodes;
				TreeNode objSelectTreeNode = null;
				foreach(NamespaceInfo objNamespace in objNamespaces)
				{
					foreach(TreeNode objTreeNode in objTreeNodes)
					{
						if(objTreeNode.Tag==objNamespace)
						{
							objSelectTreeNode = objTreeNode;
							if(!objTreeNode.Loaded)
							{

								LoadNamespaces(objTreeNode.Nodes,objNamespace.Namespaces);
								objTreeNode.Loaded = true;
							}
							objTreeNode.IsExpanded = true;
							objTreeNodes = objTreeNode.Nodes;
							break;
						}
					}
				}

				if(objSelectTreeNode!=null)
				{
					mobjTreeNamespaces.SelectedNode = objSelectTreeNode;
					mobjTreeNamespaces.Update();
				}
			}
		}

		private string GetVisibility(bool blnIsPublic,bool blnIsPrivate,bool blnIsFamiliy)
		{
			if(blnIsFamiliy)
			{
				return "protected";
			}
			else if(blnIsPrivate)
			{
				return "public";
			}
			else
			{
				return "public";
			}
		}

		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
		}

		public HostedToolBarElement[] GetToolBarElements()
		{
			ArrayList objElements = new ArrayList();
			objElements.Add(new HostedToolBarButton("Search",new IconResourceHandle("Search.gif"),"Search"));
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			string strAction = (string)objButton.Tag;

			switch(strAction)
			{
				case "Search":
					SearchForm objSearchForm = new SearchForm();
					objSearchForm.Closed+=new EventHandler(objSearchForm_Closed);
					objSearchForm.ShowDialog();
					break;
			}
		}

		#endregion

		#endregion

		
	}
}
