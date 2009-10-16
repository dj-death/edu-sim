using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.NavigationControls
{
	/// <summary>
	/// Summary description for TabControlControl.
	/// </summary>

    [Serializable()]
    public class TabControlControl : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.TabControl tabControl1;
		private Gizmox.WebGUI.Forms.TabPage tabPage1;
		private Gizmox.WebGUI.Forms.TabPage tabPage2;
		private Gizmox.WebGUI.Forms.TabPage tabPage3;
		private Gizmox.WebGUI.Forms.TabPage tabPage4;
		private Gizmox.WebGUI.Forms.CheckBox checkBox1;
		private Gizmox.WebGUI.Forms.CheckBox checkBox2;
		private Gizmox.WebGUI.Forms.CheckBox checkBox3;
		private Gizmox.WebGUI.Forms.GroupBox groupBox1;
		private Gizmox.WebGUI.Forms.MonthCalendar monthCalendar1;
		private Gizmox.WebGUI.Forms.DateTimePicker dateTimePicker1;
		private Gizmox.WebGUI.Forms.ListBox listBox1;
        private Button button1;
        private TextBox textBox1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public TabControlControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

            this.tabControl1.ClientBehavior = TabControlClientBehavior.DrawingOptimized;

            HtmlBox a = new HtmlBox();
            a.Url = "http://www.google.com";
            a.Dock = DockStyle.Fill;
            tabPage4.Controls.Add(a);
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
            this.tabControl1 = new Gizmox.WebGUI.Forms.TabControl();
            this.tabPage1 = new Gizmox.WebGUI.Forms.TabPage();
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.checkBox1 = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkBox2 = new Gizmox.WebGUI.Forms.CheckBox();
            this.checkBox3 = new Gizmox.WebGUI.Forms.CheckBox();
            this.tabPage2 = new Gizmox.WebGUI.Forms.TabPage();
            this.dateTimePicker1 = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.monthCalendar1 = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.tabPage3 = new Gizmox.WebGUI.Forms.TabPage();
            this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
            this.tabPage4 = new Gizmox.WebGUI.Forms.TabPage();
            this.button1 = new Gizmox.WebGUI.Forms.Button();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            // 
            // tabControl1
            // 
            this.tabControl1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.tabControl1.ClientSize = new System.Drawing.Size(530, 530);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(530, 530);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Multiline = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.tabPage1.ClientSize = new System.Drawing.Size(522, 488);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(522, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.groupBox1.ClientSize = new System.Drawing.Size(424, 112);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 112);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.Text = "groupBox1";
            // 
            // checkBox1
            // 
            this.checkBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.checkBox1.Checked = false;
            this.checkBox1.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.checkBox1.ClientSize = new System.Drawing.Size(104, 24);
            this.checkBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.checkBox1.Location = new System.Drawing.Point(16, 24);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.ThreeState = false;
            // 
            // checkBox2
            // 
            this.checkBox2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.checkBox2.Checked = false;
            this.checkBox2.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.checkBox2.ClientSize = new System.Drawing.Size(104, 24);
            this.checkBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.checkBox2.Location = new System.Drawing.Point(16, 48);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 24);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.ThreeState = false;
            // 
            // checkBox3
            // 
            this.checkBox3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.checkBox3.Checked = false;
            this.checkBox3.CheckState = Gizmox.WebGUI.Forms.CheckState.Unchecked;
            this.checkBox3.ClientSize = new System.Drawing.Size(104, 24);
            this.checkBox3.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Standard;
            this.checkBox3.Location = new System.Drawing.Point(16, 72);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(104, 24);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.ThreeState = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.tabPage2.ClientSize = new System.Drawing.Size(522, 488);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.monthCalendar1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(522, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.dateTimePicker1.Checked = false;
            this.dateTimePicker1.ClientSize = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.CustomFormat = null;
            this.dateTimePicker1.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Long;
            this.dateTimePicker1.Location = new System.Drawing.Point(16, 184);
            this.dateTimePicker1.MaxDate = new System.DateTime(2011, 9, 18, 8, 6, 44, 781);
            this.dateTimePicker1.MinDate = new System.DateTime(2001, 9, 18, 8, 6, 44, 781);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowCheckBox = false;
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.Value = new System.DateTime(2006, 9, 18, 0, 0, 0, 0);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.monthCalendar1.ClientSize = new System.Drawing.Size(178, 155);
            this.monthCalendar1.Location = new System.Drawing.Point(16, 16);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.Size = new System.Drawing.Size(178, 155);
            this.monthCalendar1.TabIndex = 0;
            this.monthCalendar1.Value = new System.DateTime(2006, 9, 18, 8, 6, 35, 968);
            // 
            // tabPage3
            // 
            this.tabPage3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.tabPage3.ClientSize = new System.Drawing.Size(522, 488);
            this.tabPage3.Controls.Add(this.listBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(522, 488);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // listBox1
            // 
            this.listBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.listBox1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.listBox1.ClientSize = new System.Drawing.Size(176, 368);
            this.listBox1.Location = new System.Drawing.Point(16, 16);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(176, 368);
            this.listBox1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.tabPage4.ClientSize = new System.Drawing.Size(522, 488);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(522, 488);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.button1.ClientSize = new System.Drawing.Size(75, 23);
            this.button1.Location = new System.Drawing.Point(8, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Click Me to change tab size";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.AcceptsReturn = true;
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.textBox1.ClientSize = new System.Drawing.Size(200, 20);
            this.textBox1.Lines = new string[0];
            this.textBox1.Location = new System.Drawing.Point(16, 210);
            this.textBox1.MaxLength = 0;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = false;
            this.textBox1.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            this.textBox1.Validator = null;
            this.textBox1.WordWrap = false;
            // 
            // TabControlControl
            // 
            this.ClientSize = new System.Drawing.Size(536, 520);
            this.Controls.Add(this.tabControl1);
            this.DockPadding.All = 3;
            this.Size = new System.Drawing.Size(536, 520);

		}
		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
		}

		public HostedToolBarElement[] GetToolBarElements()
		{
            ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
            string strAction = (string)objButton.Tag;
            switch (strAction)
            {
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.tabControl1);
                    objInspectorForm.ShowDialog();
                    break;
            }
		}

		#endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "1";
            this.tabPage1.Text += "s";
        }
	}
}
