using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Extensions.Office
{


	/// <summary>
	/// Summary description for ScheduleBoxSample.
	/// </summary>

    [Serializable()]
    public class ScheduleBoxSample : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.ScheduleBox scheduleBox1;
		private Gizmox.WebGUI.Forms.DataGridView dataGridView1;
		private Gizmox.WebGUI.Forms.PropertyGrid propertyGrid1;
		private Gizmox.WebGUI.Forms.Splitter splitter1;
		private Gizmox.WebGUI.Forms.Splitter splitter2;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public ScheduleBoxSample()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			

			this.scheduleBox1.Events.Add("Meeting with ronen",DateTime.Now.AddDays(1),DateTime.Now.AddDays(30));
			this.scheduleBox1.Events.Add("Out of office",DateTime.Now,DateTime.Now.AddDays(2));
			this.scheduleBox1.Events.Add("testttt4",DateTime.Now,DateTime.Now.AddDays(3));
			this.scheduleBox1.Events.Add("guyyy",DateTime.Now.AddDays(3),DateTime.Now.AddDays(5));
			this.scheduleBox1.Events.Add("testttt3",DateTime.Now,DateTime.Now.AddHours(2));
			DateTime objTest = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,11,15,0);
			this.scheduleBox1.Events.Add("Happy",objTest.AddDays(1),objTest.AddDays(1).AddHours(5));
			this.scheduleBox1.Events.Add("Happy",objTest.AddDays(1).AddHours(3),objTest.AddDays(1).AddHours(8));
			this.scheduleBox1.Events.Add("Happy",objTest.AddDays(1).AddHours(10),objTest.AddDays(1).AddHours(12));
			this.scheduleBox1.FirstDate = DateTime.Now;
			this.propertyGrid1.SelectedObject = this.scheduleBox1;
			this.dataGridView1.DataSource = this.scheduleBox1.Events;
			this.propertyGrid1.Site = new ComponentChangeSite(this.propertyGrid1);
            this.scheduleBox1.EventDoubleClick += new ScheduleBox.ScheduleBoxEventHandler(scheduleBox1_EventDoubleClick);

            this.dataGridView1.Columns[0].Width = 150;
            this.dataGridView1.Columns[1].Width = 150;
            this.dataGridView1.Columns[2].Width = 150;
		}

        void scheduleBox1_EventDoubleClick(object sender, ScheduleBox.ScheduleBoxEventArgs e)
        {
            MessageBox.Show(e.Event.Subject);
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
			Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
			Gizmox.WebGUI.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new Gizmox.WebGUI.Forms.DataGridViewCellStyle();
			this.scheduleBox1 = new Gizmox.WebGUI.Forms.ScheduleBox();
			this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
			this.propertyGrid1 = new Gizmox.WebGUI.Forms.PropertyGrid();
			this.splitter1 = new Gizmox.WebGUI.Forms.Splitter();
			this.splitter2 = new Gizmox.WebGUI.Forms.Splitter();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// scheduleBox1
			// 
			this.scheduleBox1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.scheduleBox1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.scheduleBox1.ClientSize = new System.Drawing.Size(370, 476);
			this.scheduleBox1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.scheduleBox1.FirstDate = new System.DateTime(2006, 8, 3, 21, 14, 17, 750);
			this.scheduleBox1.Location = new System.Drawing.Point(6, 3);
			this.scheduleBox1.Name = "scheduleBox1";
			this.scheduleBox1.Size = new System.Drawing.Size(370, 476);
			this.scheduleBox1.TabIndex = 0;
			this.scheduleBox1.Text = "ScheduleBox Placeholder.";
			this.scheduleBox1.View = Gizmox.WebGUI.Forms.ScheduleBoxView.Week;
			// 
			// dataGridView1
			// 
			this.dataGridView1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.dataGridView1.ClientSize = new System.Drawing.Size(626, 150);
			this.dataGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
			this.dataGridView1.Location = new System.Drawing.Point(3, 511);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(626, 150);
			this.dataGridView1.TabIndex = 1;
			this.dataGridView1.AllowUserToResizeRows = false;

			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.propertyGrid1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.propertyGrid1.CategoryForeColor = System.Drawing.Color.Empty;
			this.propertyGrid1.ClientSize = new System.Drawing.Size(250, 476);
			this.propertyGrid1.CommandsVisibleIfAvailable = false;
			this.propertyGrid1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
			this.propertyGrid1.DockPadding.All = 0;
			this.propertyGrid1.DockPadding.Bottom = 0;
			this.propertyGrid1.DockPadding.Left = 0;
			this.propertyGrid1.DockPadding.Right = 0;
			this.propertyGrid1.DockPadding.Top = 0;
			this.propertyGrid1.HelpForeColor = System.Drawing.Color.Black;
			this.propertyGrid1.HelpVisible = false;
			this.propertyGrid1.LineColor = System.Drawing.Color.Empty;
			this.propertyGrid1.Location = new System.Drawing.Point(379, 3);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical;
			this.propertyGrid1.SelectedObject = null;
			this.propertyGrid1.Size = new System.Drawing.Size(250, 476);
			this.propertyGrid1.TabIndex = 1;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Control;
			this.propertyGrid1.ViewForeColor = System.Drawing.Color.Black;
			// 
			// splitter1
			// 
			this.splitter1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.splitter1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.splitter1.ClientSize = new System.Drawing.Size(3, 476);
			this.splitter1.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(376, 3);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 3);
			this.splitter1.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.splitter2.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.splitter2.ClientSize = new System.Drawing.Size(3, 476);
			this.splitter2.Dock = Gizmox.WebGUI.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(3, 3);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 3);
			this.splitter2.TabIndex = 1;
			// 
			// ScheduleBoxSample
			// 
			this.ClientSize = new System.Drawing.Size(632, 664);
			this.Controls.Add(this.scheduleBox1);
			
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.propertyGrid1);
			this.Controls.Add(this.splitter2);
			this.Controls.Add(this.dataGridView1);
			this.DockPadding.All = 3;
			this.DockPadding.Bottom = 3;
			this.DockPadding.Left = 3;
			this.DockPadding.Right = 3;
			this.DockPadding.Top = 3;
			this.Size = new System.Drawing.Size(632, 664);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
			objElements.Add(new HostedToolBarButton("NewEvent",new IconResourceHandle("NewEvent.gif"),"NewEvent"));
			objElements.Add(new HostedToolBarSeperator());
			objElements.Add(new HostedToolBarButton("PreviousWeek","Previous",new IconResourceHandle("Back.gif"),"PreviousWeek"));
			objElements.Add(new HostedToolBarButton("NextWeek","Next",new IconResourceHandle("Next.gif"),"NextWeek"));
			objElements.Add(new HostedToolBarSeperator());
			objElements.Add(new HostedToolBarToggleButton("Day View","Day View",new IconResourceHandle("DayView.gif"),"DayView","View"));
			HostedToolBarToggleButton objWeekView = new HostedToolBarToggleButton("Work Week View","Work Week View",new IconResourceHandle("WorkWeekView.gif"),"WorkWeekView","View");
			objWeekView.Pushed = true;
			objElements.Add(objWeekView);
			objElements.Add(new HostedToolBarToggleButton("Week View","Week View",new IconResourceHandle("WeekView.gif"),"WeekView","View"));
			
			objElements.Add(new HostedToolBarToggleButton("Month View","Month View",new IconResourceHandle("MonthView.gif"),"MonthView","View"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			string strAction = (string)objButton.Tag;

			switch(strAction)
			{
				case "NextWeek":
					this.scheduleBox1.FirstDate = this.scheduleBox1.FirstDate.AddDays(7);
					break;
				case "PreviousWeek":
					this.scheduleBox1.FirstDate = this.scheduleBox1.FirstDate.AddDays(-7);
					break;
				case "DayView":
					this.scheduleBox1.View = ScheduleBoxView.Day;
					break;
				case "WorkWeekView":
					this.scheduleBox1.View = ScheduleBoxView.Week;
					break;
                case "MonthView":
                    this.scheduleBox1.View = ScheduleBoxView.Month;
                    break;
				case "WeekView":
					this.scheduleBox1.View = ScheduleBoxView.FullWeek;
					break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "ScheduleBox class");
                    break;
			}
		}

		#endregion


	}


    [Serializable()]
    public class ComponentChangeSite : ISite, IComponentChangeService
    {
        private PropertyGrid mobjPropertyGrid = null;

        public ComponentChangeSite(PropertyGrid objPropertyGrid)
        {
            mobjPropertyGrid = objPropertyGrid;
        }

        #region ISite Members

        public IComponent Component
        {
            get
            {
                return mobjPropertyGrid;
            }
        }

        public IContainer Container
        {
            get
            {
                return null;
            }
        }

        public bool DesignMode
        {
            get
            {
                return false;
            }
        }

        public string Name
        {
            get
            {
                return mobjPropertyGrid.Name;
            }
            set
            {
            }
        }

        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IComponentChangeService))
            {
                return this;
            }
            return null;
        }

        #endregion

        #region IComponentChangeService Members

        public event System.ComponentModel.Design.ComponentEventHandler ComponentRemoving;

        public void OnComponentChanged(object component, MemberDescriptor member, object oldValue, object newValue)
        {
            // TODO:  Add TempSite.OnComponentChanged implementation
        }

        public void OnComponentChanging(object component, MemberDescriptor member)
        {
            // TODO:  Add TempSite.OnComponentChanging implementation
        }

        public event System.ComponentModel.Design.ComponentEventHandler ComponentAdded;

        public event System.ComponentModel.Design.ComponentRenameEventHandler ComponentRename;

        public event System.ComponentModel.Design.ComponentEventHandler ComponentAdding;

        public event System.ComponentModel.Design.ComponentEventHandler ComponentRemoved;

        public event System.ComponentModel.Design.ComponentChangingEventHandler ComponentChanging;

        public event System.ComponentModel.Design.ComponentChangedEventHandler ComponentChanged;

        #endregion
    }
}
