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
	/// Summary description for WorkspaceTabControlControl.
	/// </summary>

    [Serializable()]
    public class WorkspaceTabControlControl : UserControl, IHostedApplication
	{
        private Gizmox.WebGUI.Forms.WorkspaceTabs workspaceTabs1;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab1;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab2;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab3;
        private Gizmox.WebGUI.Forms.WorkspaceTab workspaceTab4;
		private Gizmox.WebGUI.Forms.CheckBox checkBox1;
		private Gizmox.WebGUI.Forms.CheckBox checkBox2;
		private Gizmox.WebGUI.Forms.CheckBox checkBox3;
		private Gizmox.WebGUI.Forms.GroupBox groupBox1;
		private Gizmox.WebGUI.Forms.MonthCalendar monthCalendar1;
		private Gizmox.WebGUI.Forms.DateTimePicker dateTimePicker1;
		private Gizmox.WebGUI.Forms.ListBox listBox1;
		private Gizmox.WebGUI.Forms.Panel panel1;
		private Gizmox.WebGUI.Forms.Splitter splitter1;
		private Gizmox.WebGUI.Forms.Panel panel2;
		private Gizmox.WebGUI.Forms.Splitter splitter2;
		private Gizmox.WebGUI.Forms.Panel panel3;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public WorkspaceTabControlControl()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

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
            this.workspaceTabs1 = new Gizmox.WebGUI.Forms.WorkspaceTabs();
            this.workspaceTab1 = new Gizmox.WebGUI.Forms.WorkspaceTab();
			this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
			this.checkBox1 = new Gizmox.WebGUI.Forms.CheckBox();
			this.checkBox2 = new Gizmox.WebGUI.Forms.CheckBox();
			this.checkBox3 = new Gizmox.WebGUI.Forms.CheckBox();
            this.workspaceTab2 = new Gizmox.WebGUI.Forms.WorkspaceTab();
			this.dateTimePicker1 = new Gizmox.WebGUI.Forms.DateTimePicker();
			this.monthCalendar1 = new Gizmox.WebGUI.Forms.MonthCalendar();
            this.workspaceTab3 = new Gizmox.WebGUI.Forms.WorkspaceTab();
			this.listBox1 = new Gizmox.WebGUI.Forms.ListBox();
			this.workspaceTab4 = new Gizmox.WebGUI.Forms.WorkspaceTab();
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.splitter1 = new Gizmox.WebGUI.Forms.Splitter();
			this.panel2 = new Gizmox.WebGUI.Forms.Panel();
			this.splitter2 = new Gizmox.WebGUI.Forms.Splitter();
			this.panel3 = new Gizmox.WebGUI.Forms.Panel();
            this.workspaceTabs1.SuspendLayout();
			this.workspaceTab1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.workspaceTab2.SuspendLayout();
			this.workspaceTab3.SuspendLayout();
			this.workspaceTab4.SuspendLayout();
			this.SuspendLayout();
			// 
            // workspaceTabs1
			// 
            this.workspaceTabs1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.workspaceTabs1.ClientSize = new System.Drawing.Size(530, 530);
            this.workspaceTabs1.Controls.Add(this.workspaceTab1);
            this.workspaceTabs1.Controls.Add(this.workspaceTab2);
            this.workspaceTabs1.Controls.Add(this.workspaceTab3);
            this.workspaceTabs1.Controls.Add(this.workspaceTab4);
            this.workspaceTabs1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.workspaceTabs1.Location = new System.Drawing.Point(3, 3);
            this.workspaceTabs1.Name = "workspaceTabs1";
            this.workspaceTabs1.SelectedIndex = 0;
            this.workspaceTabs1.Size = new System.Drawing.Size(530, 530);
            this.workspaceTabs1.TabIndex = 0;
            this.workspaceTabs1.ClientBehavior = TabControlClientBehavior.DrawingOptimized;
			// 
            // workspaceTab1
			// 
			this.workspaceTab1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab1.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab1.Controls.Add(this.groupBox1);
			this.workspaceTab1.Location = new System.Drawing.Point(4, 22);
            this.workspaceTab1.Name = "workspaceTab1";
			this.workspaceTab1.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab1.TabIndex = 0;
            this.workspaceTab1.Text = "workspaceTab1";
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
            // workspaceTab2
			// 
			this.workspaceTab2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab2.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab2.Controls.Add(this.dateTimePicker1);
			this.workspaceTab2.Controls.Add(this.monthCalendar1);
			this.workspaceTab2.Location = new System.Drawing.Point(4, 22);
            this.workspaceTab2.Name = "workspaceTab2";
			this.workspaceTab2.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab2.TabIndex = 1;
            this.workspaceTab2.Text = "workspaceTab2";
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
            // workspaceTab3
			// 
			this.workspaceTab3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab3.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab3.Controls.Add(this.listBox1);
			this.workspaceTab3.Location = new System.Drawing.Point(4, 22);
            this.workspaceTab3.Name = "workspaceTab3";
			this.workspaceTab3.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab3.TabIndex = 2;
            this.workspaceTab3.Text = "workspaceTab3";
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
            // workspaceTab4
			// 
			this.workspaceTab4.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.workspaceTab4.ClientSize = new System.Drawing.Size(100, 100);
			this.workspaceTab4.Controls.Add(this.panel3);
			this.workspaceTab4.Controls.Add(this.splitter2);
			this.workspaceTab4.Controls.Add(this.panel2);
			this.workspaceTab4.Controls.Add(this.splitter1);
			this.workspaceTab4.Controls.Add(this.panel1);
			this.workspaceTab4.Location = new System.Drawing.Point(4, 22);
            this.workspaceTab4.Name = "workspaceTab4";
			this.workspaceTab4.Size = new System.Drawing.Size(100, 100);
			this.workspaceTab4.TabIndex = 3;
            this.workspaceTab4.Text = "workspaceTab4";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(128)));
			this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel1.ClientSize = new System.Drawing.Size(152, 100);
			this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(152, 100);
			this.panel1.TabIndex = 0;
			// 
			// splitter1
			// 
			this.splitter1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.splitter1.ClientSize = new System.Drawing.Size(3, 100);
			this.splitter1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.splitter1.Location = new System.Drawing.Point(152, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 100);
			this.splitter1.TabIndex = 1;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(255)), ((System.Byte)(255)));
			this.panel2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel2.ClientSize = new System.Drawing.Size(112, 100);
			this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
			this.panel2.Location = new System.Drawing.Point(410, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(112, 100);
			this.panel2.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.splitter2.ClientSize = new System.Drawing.Size(3, 100);
			this.splitter2.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
			this.splitter2.Location = new System.Drawing.Point(407, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 100);
			this.splitter2.TabIndex = 3;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(128)));
			this.panel3.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.panel3.ClientSize = new System.Drawing.Size(-170, 100);
			this.panel3.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(155, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(-170, 100);
			this.panel3.TabIndex = 4;
			// 
			// WorkspaceTabControlControl
			// 
			this.ClientSize = new System.Drawing.Size(536, 520);
            this.Controls.Add(this.workspaceTabs1);
			this.DockPadding.All = 3;
			this.Size = new System.Drawing.Size(536, 520);
			this.workspaceTab1.ResumeLayout(false);
			this.workspaceTab1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.workspaceTab2.ResumeLayout(false);
			this.workspaceTab3.ResumeLayout(false);
			this.workspaceTab4.ResumeLayout(false);
			this.ResumeLayout(false);

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
                    objInspectorForm.SetControls(this.workspaceTabs1);
                    objInspectorForm.ShowDialog();
                    break;
            }
        }

		#endregion
	}
}
