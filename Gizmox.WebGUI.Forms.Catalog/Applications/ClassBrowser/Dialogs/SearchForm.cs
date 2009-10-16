using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Applications.ClassBrowser
{
	/// <summary>
	/// Summary description for Search.
	/// </summary>

    [Serializable()]
    public class SearchForm : Form
	{
		private Gizmox.WebGUI.Forms.Button mobjButtonFind;
		private Gizmox.WebGUI.Forms.Button mobjButtonSelect;
		private Gizmox.WebGUI.Forms.TextBox mobjTextFind;
		private Gizmox.WebGUI.Forms.GroupBox mobjGroupMethods;
		private Gizmox.WebGUI.Forms.RadioButton mobjRadioStartsWith;
		private Gizmox.WebGUI.Forms.RadioButton mobjRadioContains;
		private Gizmox.WebGUI.Forms.RadioButton mobjRadioEndsWith;
		private Gizmox.WebGUI.Forms.Label mobjLabelFind;
		private Gizmox.WebGUI.Forms.Button mobjButtonClose;
		private Gizmox.WebGUI.Forms.CheckBox mobjCheckClasses;
		private Gizmox.WebGUI.Forms.CheckBox mobjChechInterfaces;
		private Gizmox.WebGUI.Forms.CheckBox mobjCheckNamespaces;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnHeaderName;
		private Gizmox.WebGUI.Forms.ColumnHeader mobjColumnHeaderType;
		private Gizmox.WebGUI.Forms.ListView mobjListItems;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		private object mobjSelectedItem = null;

		public SearchForm()
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

		#region Form Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjButtonFind = new Gizmox.WebGUI.Forms.Button();
			this.mobjButtonSelect = new Gizmox.WebGUI.Forms.Button();
			this.mobjTextFind = new Gizmox.WebGUI.Forms.TextBox();
			this.mobjGroupMethods = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjRadioEndsWith = new Gizmox.WebGUI.Forms.RadioButton();
			this.mobjRadioContains = new Gizmox.WebGUI.Forms.RadioButton();
			this.mobjRadioStartsWith = new Gizmox.WebGUI.Forms.RadioButton();
			this.mobjLabelFind = new Gizmox.WebGUI.Forms.Label();
			this.mobjButtonClose = new Gizmox.WebGUI.Forms.Button();
			this.mobjCheckClasses = new Gizmox.WebGUI.Forms.CheckBox();
			this.mobjChechInterfaces = new Gizmox.WebGUI.Forms.CheckBox();
			this.mobjCheckNamespaces = new Gizmox.WebGUI.Forms.CheckBox();
			this.mobjListItems = new Gizmox.WebGUI.Forms.ListView();
			this.mobjColumnHeaderName = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjColumnHeaderType = new Gizmox.WebGUI.Forms.ColumnHeader();
			this.mobjGroupMethods.SuspendLayout();
			this.SuspendLayout();
			// 
			// mobjButtonFind
			// 
			this.mobjButtonFind.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjButtonFind.ClientSize = new System.Drawing.Size(75, 23);
			this.mobjButtonFind.Location = new System.Drawing.Point(368, 8);
			this.mobjButtonFind.Name = "mobjButtonFind";
			this.mobjButtonFind.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonFind.Text = "Find";
			this.mobjButtonFind.Click += new System.EventHandler(this.mobjButtonFind_Click);
			// 
			// mobjButtonSelect
			// 
			this.mobjButtonSelect.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjButtonSelect.ClientSize = new System.Drawing.Size(75, 23);
			this.mobjButtonSelect.Enabled = false;
			this.mobjButtonSelect.Location = new System.Drawing.Point(368, 40);
			this.mobjButtonSelect.Name = "mobjButtonSelect";
			this.mobjButtonSelect.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonSelect.Text = "Select";
			this.mobjButtonSelect.Click += new System.EventHandler(this.mobjButtonSelect_Click);
			// 
			// mobjTextFind
			// 
			this.mobjTextFind.AcceptsReturn = true;
			this.mobjTextFind.AcceptsTab = true;
			this.mobjTextFind.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjTextFind.ClientSize = new System.Drawing.Size(264, 20);
			this.mobjTextFind.Lines = new string[0];
			this.mobjTextFind.Location = new System.Drawing.Point(88, 8);
			this.mobjTextFind.MaxLength = 0;
			this.mobjTextFind.Multiline = false;
			this.mobjTextFind.Name = "mobjTextFind";
			this.mobjTextFind.ReadOnly = false;
			this.mobjTextFind.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
			this.mobjTextFind.Size = new System.Drawing.Size(264, 20);
			this.mobjTextFind.Validator = null;
			this.mobjTextFind.WordWrap = false;
			this.mobjTextFind.EnterKeyDown+=new KeyEventHandler(mobjTextFind_EnterKeyDown);
			// 
			// mobjGroupMethods
			// 
			this.mobjGroupMethods.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)(((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjGroupMethods.ClientSize = new System.Drawing.Size(224, 96);
			this.mobjGroupMethods.Controls.Add(this.mobjRadioEndsWith);
			this.mobjGroupMethods.Controls.Add(this.mobjRadioContains);
			this.mobjGroupMethods.Controls.Add(this.mobjRadioStartsWith);
			this.mobjGroupMethods.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjGroupMethods.Location = new System.Drawing.Point(128, 40);
			this.mobjGroupMethods.Name = "mobjGroupMethods";
			this.mobjGroupMethods.Size = new System.Drawing.Size(224, 96);
			this.mobjGroupMethods.Text = "Method";
			// 
			// mobjRadioEndsWith
			// 
			this.mobjRadioEndsWith.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjRadioEndsWith.Checked = false;
			this.mobjRadioEndsWith.ClientSize = new System.Drawing.Size(104, 24);
			this.mobjRadioEndsWith.Location = new System.Drawing.Point(8, 64);
			this.mobjRadioEndsWith.Name = "mobjRadioEndsWith";
			this.mobjRadioEndsWith.Size = new System.Drawing.Size(104, 24);
			this.mobjRadioEndsWith.Text = "Ends With";
			// 
			// mobjRadioContains
			// 
			this.mobjRadioContains.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjRadioContains.Checked = true;
			this.mobjRadioContains.ClientSize = new System.Drawing.Size(104, 24);
			this.mobjRadioContains.Location = new System.Drawing.Point(8, 40);
			this.mobjRadioContains.Name = "mobjRadioContains";
			this.mobjRadioContains.Size = new System.Drawing.Size(104, 24);
			this.mobjRadioContains.Text = "Contains";
			// 
			// mobjRadioStartsWith
			// 
			this.mobjRadioStartsWith.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjRadioStartsWith.Checked = false;
			this.mobjRadioStartsWith.ClientSize = new System.Drawing.Size(104, 24);
			this.mobjRadioStartsWith.Location = new System.Drawing.Point(8, 16);
			this.mobjRadioStartsWith.Name = "mobjRadioStartsWith";
			this.mobjRadioStartsWith.Size = new System.Drawing.Size(104, 24);
			this.mobjRadioStartsWith.Text = "Starts With";
			// 
			// mobjLabelFind
			// 
			this.mobjLabelFind.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjLabelFind.ClientSize = new System.Drawing.Size(72, 20);
			this.mobjLabelFind.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.mobjLabelFind.Location = new System.Drawing.Point(8, 8);
			this.mobjLabelFind.Name = "mobjLabelFind";
			this.mobjLabelFind.Size = new System.Drawing.Size(72, 20);
			this.mobjLabelFind.Text = "Find what:";
			this.mobjLabelFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mobjButtonClose
			// 
			this.mobjButtonClose.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjButtonClose.ClientSize = new System.Drawing.Size(75, 23);
			this.mobjButtonClose.Location = new System.Drawing.Point(368, 72);
			this.mobjButtonClose.Name = "mobjButtonClose";
			this.mobjButtonClose.Size = new System.Drawing.Size(75, 23);
			this.mobjButtonClose.Text = "Close";
			this.mobjButtonClose.Click += new System.EventHandler(this.mobjButtonClose_Click);
			// 
			// mobjCheckClasses
			// 
			this.mobjCheckClasses.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjCheckClasses.Checked = true;
			this.mobjCheckClasses.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjCheckClasses.ClientSize = new System.Drawing.Size(104, 24);
			this.mobjCheckClasses.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
			this.mobjCheckClasses.Location = new System.Drawing.Point(8, 40);
			this.mobjCheckClasses.Name = "mobjCheckClasses";
			this.mobjCheckClasses.Size = new System.Drawing.Size(104, 24);
			this.mobjCheckClasses.Text = "Classes";
			this.mobjCheckClasses.ThreeState = false;
			// 
			// mobjChechInterfaces
			// 
			this.mobjChechInterfaces.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjChechInterfaces.Checked = true;
			this.mobjChechInterfaces.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjChechInterfaces.ClientSize = new System.Drawing.Size(104, 24);
			this.mobjChechInterfaces.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
			this.mobjChechInterfaces.Location = new System.Drawing.Point(8, 64);
			this.mobjChechInterfaces.Name = "mobjChechInterfaces";
			this.mobjChechInterfaces.Size = new System.Drawing.Size(104, 24);
			this.mobjChechInterfaces.Text = "Interfaces";
			this.mobjChechInterfaces.ThreeState = false;
			// 
			// mobjCheckNamespaces
			// 
			this.mobjCheckNamespaces.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.mobjCheckNamespaces.Checked = true;
			this.mobjCheckNamespaces.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
			this.mobjCheckNamespaces.ClientSize = new System.Drawing.Size(104, 24);
			this.mobjCheckNamespaces.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
			this.mobjCheckNamespaces.Location = new System.Drawing.Point(8, 88);
			this.mobjCheckNamespaces.Name = "mobjCheckNamespaces";
			this.mobjCheckNamespaces.Size = new System.Drawing.Size(104, 24);
			this.mobjCheckNamespaces.Text = "Namespaces";
			this.mobjCheckNamespaces.ThreeState = false;
			// 
			// mobjListItems
			// 
			this.mobjListItems.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Bottom) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Left) 
				| Gizmox.WebGUI.Forms.AnchorStyles.Right)));
			this.mobjListItems.ClientSize = new System.Drawing.Size(432, 208);
			this.mobjListItems.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
																						   this.mobjColumnHeaderName,
																						   this.mobjColumnHeaderType});
			this.mobjListItems.Location = new System.Drawing.Point(8, 152);
			this.mobjListItems.Name = "mobjListItems";
			this.mobjListItems.Size = new System.Drawing.Size(432, 208);
			this.mobjListItems.UseInternalPaging = true;
			this.mobjListItems.DoubleClick += new System.EventHandler(this.mobjListItems_DoubleClick);
			this.mobjListItems.SelectedIndexChanged += new System.EventHandler(this.mobjListItems_SelectedIndexChanged);
			// 
			// mobjColumnHeaderName
			// 
			this.mobjColumnHeaderName.Text = "Name";
			this.mobjColumnHeaderName.Width = 200;
			// 
			// mobjColumnHeaderType
			// 
			this.mobjColumnHeaderType.Text = "Type";
			this.mobjColumnHeaderType.Width = 150;
			// 
			// SearchForm
			// 
			this.ClientSize = new System.Drawing.Size(448, 366);
			this.Controls.Add(this.mobjListItems);
			this.Controls.Add(this.mobjCheckNamespaces);
			this.Controls.Add(this.mobjChechInterfaces);
			this.Controls.Add(this.mobjCheckClasses);
			this.Controls.Add(this.mobjButtonClose);
			this.Controls.Add(this.mobjLabelFind);
			this.Controls.Add(this.mobjGroupMethods);
			this.Controls.Add(this.mobjTextFind);
			this.Controls.Add(this.mobjButtonSelect);
			this.Controls.Add(this.mobjButtonFind);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
            this.Load += new EventHandler(SearchForm_Load);
			this.Size = new System.Drawing.Size(448, 366);
			this.Text = "Search Form";
			this.mobjGroupMethods.ResumeLayout(false);
			this.ResumeLayout(false);

		}


		#endregion

		public object SelectedItem
		{
			get
			{
				return mobjSelectedItem;
			}
		}

        void SearchForm_Load(object sender, EventArgs e)
        {
            mobjTextFind.Focus();
        }

		private void mobjTextFind_EnterKeyDown(object objSender, KeyEventArgs objArgs)
		{
			mobjButtonFind_Click(this.mobjButtonFind,EventArgs.Empty);
		}

		private void mobjButtonFind_Click(object sender, System.EventArgs e)
		{
			if(mobjTextFind.Text!="")
			{
				ArrayList objFoundItems = Search();

				mobjListItems.Items.Clear();
				mobjButtonSelect.Enabled = false;

				foreach(object objFoundItem in objFoundItems)
				{
					ListViewItem objListItem;

					Type objType = objFoundItem as Type;
					if(objType!=null)
					{
						objListItem = mobjListItems.Items.Add(objType.Name);
						objListItem.Tag = objType;
						if(objType.IsInterface)
						{
							objListItem.SubItems.Add("Interface");
                            objListItem.SmallImage = new IconResourceHandle("Interface.gif");
						}
						else
						{
							objListItem.SubItems.Add("Class");
                            objListItem.SmallImage = new IconResourceHandle("Class.gif");
						}
					}

					NamespaceInfo objNamespaceInfo = objFoundItem as NamespaceInfo;
					if(objNamespaceInfo!=null)
					{
						objListItem = mobjListItems.Items.Add(objNamespaceInfo.Name);
						objListItem.Tag = objNamespaceInfo;
						objListItem.SubItems.Add("Namespace");
						objListItem.SmallImage = new IconResourceHandle("Namespace.gif");
					}
				}

			}
			else
			{
				MessageBox.Show("Criteria is empty.","Find",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}

		private void mobjButtonClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private ArrayList Search()
		{
			ArrayList objFoundItems = new ArrayList();
			SearchNamespaces(ConsoleInfo.Namespaces,objFoundItems);
			return objFoundItems;
		}

		private void SearchNamespaces(ICollection objNamespaces,ArrayList objFoundItems)
		{
			foreach(NamespaceInfo objNamespaceInfo in objNamespaces)
			{
				if(mobjCheckNamespaces.Checked)
				{
					if(IsMatching(objNamespaceInfo.Name))
					{
						objFoundItems.Add(objNamespaceInfo);
					}
				}

				SearchNamespaces(objNamespaceInfo.Namespaces,objFoundItems);

				if(mobjCheckClasses.Checked || mobjChechInterfaces.Checked)
				{
					foreach(Type objType in objNamespaceInfo.Types)
					{
						if(objType.IsInterface && mobjChechInterfaces.Checked)
						{
							if(IsMatching(objType.Name))
							{
								objFoundItems.Add(objType);
							}
						}
						else if(objType.IsClass && mobjCheckClasses.Checked)
						{
							if(IsMatching(objType.Name))
							{
								objFoundItems.Add(objType);
							}
						}
					}
				}
			}

			
		}

		private bool IsMatching(string strObjectName)
		{
			if(mobjRadioStartsWith.Checked)
			{
				return strObjectName.StartsWith(mobjTextFind.Text);
			}
			else if(mobjRadioEndsWith.Checked)
			{
				return strObjectName.EndsWith(mobjTextFind.Text);
			}
			else
			{
				return strObjectName.IndexOf(mobjTextFind.Text)>-1;
			}
		}

		private void mobjListItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(mobjListItems.SelectedItem!=null)
			{
				mobjButtonSelect.Enabled = true;
			}
			else
			{
				mobjButtonSelect.Enabled = false;
			}
		}

		private void mobjButtonSelect_Click(object sender, System.EventArgs e)
		{
			if(mobjListItems.SelectedItem!=null)
			{
				mobjSelectedItem = mobjListItems.SelectedItem.Tag;
			}
			this.Close();
		}

		private void mobjListItems_DoubleClick(object sender, System.EventArgs e)
		{
			if(mobjListItems.SelectedItem!=null)
			{
				mobjSelectedItem = mobjListItems.SelectedItem.Tag;
				this.Close();
			}
			
		}

		
	}
}
