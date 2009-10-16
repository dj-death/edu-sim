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
	/// Summary description for ContextMenuControl.
	/// </summary>

    [Serializable()]
    public class ContextMenuControl : UserControl
	{
		private Gizmox.WebGUI.Forms.GroupBox groupBox1;
		private Gizmox.WebGUI.Forms.GroupBox groupBox2;
		private Gizmox.WebGUI.Forms.ContextMenu contextMenu1;
		private Gizmox.WebGUI.Forms.ContextMenu contextMenu2;
		private Gizmox.WebGUI.Forms.MenuItem menuItem1;
		private Gizmox.WebGUI.Forms.MenuItem menuItem2;
		private Gizmox.WebGUI.Forms.MenuItem menuItem3;
		private Gizmox.WebGUI.Forms.MenuItem menuItem4;
		private Gizmox.WebGUI.Forms.MenuItem menuItem5;
		private Gizmox.WebGUI.Forms.MenuItem menuItem6;
		private Gizmox.WebGUI.Forms.MenuItem menuItem7;
		private Gizmox.WebGUI.Forms.MenuItem menuItem8;
		private Gizmox.WebGUI.Forms.MenuItem menuItem9;
		private Gizmox.WebGUI.Forms.MenuItem menuItem10;
		private Gizmox.WebGUI.Forms.MenuItem menuItem11;
		private Gizmox.WebGUI.Forms.MenuItem menuItem12;
		private Gizmox.WebGUI.Forms.MenuItem menuItem13;
		private Gizmox.WebGUI.Forms.MenuItem menuItem14;
		private Gizmox.WebGUI.Forms.MenuItem menuItem15;
		private Gizmox.WebGUI.Forms.MenuItem menuItem16;
		private Gizmox.WebGUI.Forms.MenuItem menuItem17;
		private Gizmox.WebGUI.Forms.MenuItem menuItem18;
		private Gizmox.WebGUI.Forms.MenuItem menuItem19;
		private Gizmox.WebGUI.Forms.MenuItem menuItem20;
		private Gizmox.WebGUI.Forms.MenuItem menuItem21;
		private Gizmox.WebGUI.Forms.MenuItem menuItem22;
		private Gizmox.WebGUI.Forms.MenuItem menuItem23;
		private Gizmox.WebGUI.Forms.MenuItem menuItem24;
		private Gizmox.WebGUI.Forms.MenuItem menuItem25;
		private Gizmox.WebGUI.Forms.MenuItem menuItem26;
		private Gizmox.WebGUI.Forms.MenuItem menuItem27;
		private Gizmox.WebGUI.Forms.GroupBox groupBox5;
		private Gizmox.WebGUI.Forms.Button mobjButtonDropDown;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ContextMenuControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

			this.groupBox1.MenuClick+=new MenuEventHandler(groupBox1_MenuClick);
			this.groupBox2.MenuClick+=new MenuEventHandler(groupBox2_MenuClick);
			this.MenuClick+=new MenuEventHandler(ContextMenuControl_MenuClick);
			this.mobjButtonDropDown.MenuClick+=new MenuEventHandler(mobjButtonDropDown_MenuClick);
			this.groupBox5.Click+=new EventHandler(groupBox5_Click);
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
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.contextMenu1 = new Gizmox.WebGUI.Forms.ContextMenu();
			this.menuItem1 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem2 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem3 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem4 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem5 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem6 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem7 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem8 = new Gizmox.WebGUI.Forms.MenuItem();
			this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
			this.contextMenu2 = new Gizmox.WebGUI.Forms.ContextMenu();
			this.menuItem9 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem10 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem11 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem12 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem13 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem14 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem15 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem16 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem17 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem18 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem19 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem20 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem21 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem22 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem23 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem24 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem25 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem26 = new Gizmox.WebGUI.Forms.MenuItem();
			this.menuItem27 = new Gizmox.WebGUI.Forms.MenuItem();
			this.groupBox5 = new Gizmox.WebGUI.Forms.GroupBox();
			this.mobjButtonDropDown = new Gizmox.WebGUI.Forms.Button();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.groupBox1.ClientSize = new System.Drawing.Size(200, 100);
			this.groupBox1.ContextMenu = this.contextMenu1;
			this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(48, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 100);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.Text = "Context Menu 1";
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.menuItem1,
																						this.menuItem2,
																						this.menuItem3,
																						this.menuItem4,
																						this.menuItem5,
																						this.menuItem6,
																						this.menuItem7,
																						this.menuItem8});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "Edit";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Delete";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "Copy";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.Text = "Cut";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 5;
			this.menuItem6.Text = "Paste";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 6;
			this.menuItem7.Text = "-";
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 7;
			this.menuItem8.Text = "Properties";
			// 
			// groupBox2
			// 
			this.groupBox2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.groupBox2.ClientSize = new System.Drawing.Size(200, 100);
			this.groupBox2.ContextMenu = this.contextMenu2;
			this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(48, 168);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(200, 100);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.Text = "Context Menu 2";
			// 
			// contextMenu2
			// 
			this.contextMenu2.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																						this.menuItem9,
																						this.menuItem12,
																						this.menuItem13,
																						this.menuItem22,
																						this.menuItem23,
																						this.menuItem24,
																						this.menuItem25,
																						this.menuItem26,
																						this.menuItem27});
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																					 this.menuItem10,
																					 this.menuItem11});
			this.menuItem9.Text = "Open";
            this.menuItem9.Icon = new IconResourceHandle("Open.gif");
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.Text = "For Editing...";
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 1;
			this.menuItem11.Text = "For Viewing...";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 1;
			this.menuItem12.Text = "-";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 2;
			this.menuItem13.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																					  this.menuItem14,
																					  this.menuItem15,
																					  this.menuItem16,
																					  this.menuItem19});
			this.menuItem13.Text = "Attach";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 0;
			this.menuItem14.Text = "Process";
            this.menuItem14.Icon = new IconResourceHandle("Print.gif");
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 1;
			this.menuItem15.Text = "Document";
            this.menuItem15.Icon = new IconResourceHandle("Save.gif");
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 2;
			this.menuItem16.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																					  this.menuItem17,
																					  this.menuItem18});
			this.menuItem16.Text = "Extenal";
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 0;
			this.menuItem17.Text = "Link";
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 1;
			this.menuItem18.Text = "Custom";
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 3;
			this.menuItem19.MenuItems.AddRange(new Gizmox.WebGUI.Forms.MenuItem[] {
																					  this.menuItem20,
																					  this.menuItem21});
			this.menuItem19.Text = "Screen";
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 0;
			this.menuItem20.Text = "Instance";
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 1;
			this.menuItem21.Text = "Type";
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 3;
			this.menuItem22.Text = "-";
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 4;
			this.menuItem23.Text = "Copy";
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 5;
			this.menuItem24.Text = "Paste";
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 6;
			this.menuItem25.Text = "Cut";
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 7;
			this.menuItem26.Text = "-";
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 8;
			this.menuItem27.Text = "Properties";
			// 
			// groupBox5
			// 
			this.groupBox5.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.groupBox5.ClientSize = new System.Drawing.Size(200, 100);
			this.groupBox5.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.groupBox5.Location = new System.Drawing.Point(272, 32);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(200, 100);
			this.groupBox5.TabIndex = 2;
			this.groupBox5.Text = "Popup Window";
			// 
			// mobjButtonDropDown
			// 
			this.mobjButtonDropDown.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjButtonDropDown.ClientSize = new System.Drawing.Size(192, 23);
			this.mobjButtonDropDown.DropDownMenu = this.contextMenu1;
			this.mobjButtonDropDown.Location = new System.Drawing.Point(280, 176);
			this.mobjButtonDropDown.Name = "mobjButtonDropDown";
			this.mobjButtonDropDown.Size = new System.Drawing.Size(192, 23);
			this.mobjButtonDropDown.TabIndex = 3;
			this.mobjButtonDropDown.Text = "DropDown Button";
			// 
			// ContextMenuControl
			// 
			this.ClientSize = new System.Drawing.Size(632, 504);
			this.Controls.Add(this.mobjButtonDropDown);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Size = new System.Drawing.Size(632, 504);
			this.ResumeLayout(false);

		}
		#endregion

		private void groupBox1_MenuClick(object objSource, MenuItemEventArgs objArgs)
		{
			MessageBox.Show("groupBox1:"+objArgs.MenuItem.Text);
		}

		private void groupBox2_MenuClick(object objSource, MenuItemEventArgs objArgs)
		{
			MessageBox.Show("groupBox2:"+objArgs.MenuItem.Text);
		}

		private void ContextMenuControl_MenuClick(object objSource, MenuItemEventArgs objArgs)
		{
			MessageBox.Show("Control:"+objArgs.MenuItem.Text);
		}

		private void groupBox5_Click(object sender, EventArgs e)
		{
			ColorEditorDropDown a= new ColorEditorDropDown();
			a.Color = groupBox2.BackColor;
			a.Closed+=new EventHandler(a_Closed);
			a.ShowPopup(groupBox5,DialogAlignment.Right);
		}

		private void a_Closed(object sender, EventArgs e)
		{
			ColorEditorDropDown a= (ColorEditorDropDown)sender;
			if(a.IsCompleted)
			{
				groupBox5.BackColor = a.Color;
			}
		}

		#region color form

        [Serializable()]
        class ColorEditorDropDown : Form
		{

			private Gizmox.WebGUI.Forms.TabControl tabControl1;
			private Gizmox.WebGUI.Forms.TabPage mobjTabCustom;
			private Gizmox.WebGUI.Forms.TabPage mobjTabWeb;
			private Gizmox.WebGUI.Forms.TabPage mobjTabSystem;
			private Gizmox.WebGUI.Forms.ColorListBox mobjListWeb;
			private Gizmox.WebGUI.Forms.ColorListBox mobjListSystem;

			private bool mblnIsCompleted = false;
			private Color mobjColor = Color.Empty;

			private static Color[] marrWebColors;
			private static Color[] marrSystemColors;

			public ColorEditorDropDown()
			{
				InitializeComponenet();

				this.Load += new EventHandler(ColorEditorDropDown_Load);
			}

			private void ColorEditorDropDown_Load(object sender, EventArgs e)
			{
				this.tabControl1.SelectedIndex = 0;

				mobjListSystem.Items.AddRange(GetSystemColors());

				mobjListWeb.Items.AddRange(GetWebColors());


				InitializePalette(mobjTabCustom, GetWebColors());
            
			}

			private static Color[] GetWebColors()
			{
				if (marrWebColors == null)
				{
					marrWebColors = GetConstants(typeof(Color));
				}
				return marrWebColors;
			}

			private static Color[] GetSystemColors()
			{
				if (marrSystemColors == null)
				{
					marrSystemColors = GetConstants(typeof(SystemColors));
				}
				return marrSystemColors;
			}

			private static Color[] GetConstants(Type enumType)
			{
				MethodAttributes attributes1 = MethodAttributes.Static | MethodAttributes.Public;
				PropertyInfo[] infoArray1 = enumType.GetProperties();
				ArrayList list1 = new ArrayList();
				for (int num1 = 0; num1 < infoArray1.Length; num1++)
				{
					PropertyInfo info1 = infoArray1[num1];
					if (info1.PropertyType == typeof(Color))
					{
						MethodInfo info2 = info1.GetGetMethod();
						if ((info2 != null) && ((info2.Attributes & attributes1) == attributes1))
						{
							object[] objArray1 = null;
							list1.Add(info1.GetValue(null, objArray1));
						}
					}
				}
				return (Color[])list1.ToArray(typeof(Color));
			}

			private void InitializePalette(TabPage objTabPage,Color[] arrColors)
			{
				int intColor = 0;

				for (int y = 0; y < 8; y++)
				{
					for (int x = 0; x < 8; x++)
					{
						Panel objPanel = new Panel();
						objPanel.Location = new Point(6+x * 26, 6+y * 26);
						objPanel.Size = new Size(20, 20);
						objPanel.BorderStyle = BorderStyle.FixedSingle;
						objPanel.Click += new EventHandler(objPanel_Click);
						if (arrColors.Length > intColor)
						{
							objPanel.Tag = objPanel.BackColor = arrColors[intColor];
						}
						else
						{
							objPanel.Tag = objPanel.BackColor = Color.White;
						}
						objTabPage.Controls.Add(objPanel);
						intColor++;
					}
				}
			}




			private void InitializeComponenet()
			{
				this.tabControl1 = new Gizmox.WebGUI.Forms.TabControl();
				this.mobjTabCustom = new Gizmox.WebGUI.Forms.TabPage();
				this.mobjTabWeb = new Gizmox.WebGUI.Forms.TabPage();
				this.mobjListWeb = new Gizmox.WebGUI.Forms.ColorListBox();
				this.mobjTabSystem = new Gizmox.WebGUI.Forms.TabPage();
				this.mobjListSystem = new Gizmox.WebGUI.Forms.ColorListBox();
				this.tabControl1.SuspendLayout();
				this.mobjTabWeb.SuspendLayout();
				this.mobjTabSystem.SuspendLayout();
				this.SuspendLayout();
				// 
				// tabControl1
				// 
				this.tabControl1.Controls.Add(this.mobjTabCustom);
				this.tabControl1.Controls.Add(this.mobjTabWeb);
				this.tabControl1.Controls.Add(this.mobjTabSystem);
				this.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
				this.tabControl1.Location = new System.Drawing.Point(0, 0);
				this.tabControl1.Name = "tabControl1";
				this.tabControl1.SelectedIndex = 0;
				this.tabControl1.Size = new System.Drawing.Size(224, 242);
				this.tabControl1.TabIndex = 0;
				this.tabControl1.BorderStyle = BorderStyle.FixedSingle;
				// 
				// mobjTabCustom
				// 
				this.mobjTabCustom.Location = new System.Drawing.Point(4, 22);
				this.mobjTabCustom.Name = "mobjTabCustom";
				this.mobjTabCustom.Padding = new Gizmox.WebGUI.Forms.Padding(2);
				this.mobjTabCustom.Size = new System.Drawing.Size(216, 216);
				this.mobjTabCustom.TabIndex = 0;
				this.mobjTabCustom.Text = "Custom";

				// 
				// mobjTabWeb
				// 
				this.mobjTabWeb.Controls.Add(this.mobjListWeb);
				this.mobjTabWeb.Location = new System.Drawing.Point(4, 22);
				this.mobjTabWeb.Name = "mobjTabWeb";
				this.mobjTabWeb.Padding = new Gizmox.WebGUI.Forms.Padding(2);
				this.mobjTabWeb.Size = new System.Drawing.Size(216, 216);
				this.mobjTabWeb.TabIndex = 1;
				this.mobjTabWeb.Text = "Web";


				// 
				// mobjListWeb
				// 
				this.mobjListWeb.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
				this.mobjListWeb.FormattingEnabled = true;
				this.mobjListWeb.Location = new System.Drawing.Point(3, 3);
				this.mobjListWeb.Name = "mobjListWeb";
				this.mobjListWeb.Size = new System.Drawing.Size(210, 199);
				this.mobjListWeb.TabIndex = 0;
				this.mobjListWeb.SelectedIndexChanged += new EventHandler(mobjListWeb_SelectedIndexChanged);
				// 
				// mobjTabSystem
				// 
				this.mobjTabSystem.Controls.Add(this.mobjListSystem);
				this.mobjTabSystem.Location = new System.Drawing.Point(4, 22);
				this.mobjTabSystem.Name = "mobjTabSystem";
				this.mobjTabSystem.Size = new System.Drawing.Size(216, 216);
				this.mobjTabSystem.TabIndex = 2;
				this.mobjTabSystem.Text = "System";
				this.mobjTabSystem.Padding = new Padding(2);

				// 
				// mobjListSystem
				// 
				this.mobjListSystem.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
				this.mobjListSystem.FormattingEnabled = true;
				this.mobjListSystem.Location = new System.Drawing.Point(0, 0);
				this.mobjListSystem.Name = "mobjListSystem";
				this.mobjListSystem.Size = new System.Drawing.Size(216, 212);
				this.mobjListSystem.TabIndex = 0;
				this.mobjListSystem.SelectedIndexChanged += new EventHandler(mobjListSystem_SelectedIndexChanged);
				// 
				// ColorControl
				// 
				this.DockPadding.All = 2;
				this.ClientSize = new System.Drawing.Size(224, 242);
				this.Controls.Add(this.tabControl1);
				this.Name = "ColorControl";
				this.tabControl1.ResumeLayout(false);
				this.mobjTabWeb.ResumeLayout(false);
				this.mobjTabSystem.ResumeLayout(false);
				this.ResumeLayout(false);
			}


			private void objPanel_Click(object sender, EventArgs e)
			{
				mblnIsCompleted = true;
				mobjColor = (Color)((Panel)sender).Tag;
				this.Close();
			}

			public void mobjListWeb_SelectedIndexChanged(object sender, EventArgs e)
			{
				mblnIsCompleted = true;
				mobjColor = (Color)mobjListWeb.SelectedItem;
				this.Close();
			}

			public void mobjListSystem_SelectedIndexChanged(object sender, EventArgs e)
			{
				mblnIsCompleted = true;
				mobjColor = (Color)mobjListSystem.SelectedItem;
				this.Close();
			}

			public Color Color
			{
				get
				{
					return mobjColor;
				}
				set
				{
					mobjColor = value;
				}
			}

			public bool IsCompleted
			{
				get
				{
					return mblnIsCompleted;
				}
			}
		}

		#endregion

		private void mobjButtonDropDown_MenuClick(object objSource, MenuItemEventArgs objArgs)
		{
			MessageBox.Show("Button:"+objArgs.MenuItem.Text);
		}
	}
}
