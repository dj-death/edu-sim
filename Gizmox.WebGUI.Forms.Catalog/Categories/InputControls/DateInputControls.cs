using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.InputControls
{
	/// <summary>
	/// Summary description for DateInputControls.
	/// </summary>

    [Serializable()]
    public class DateInputControls : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.DateTimePicker dateTimePicker1;
		private Gizmox.WebGUI.Forms.MonthCalendar monthCalendar1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public DateInputControls()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //dateTimePicker1.ValueChanged += new EventHandler(dateTimePicker1_ValueChanged);
		}

        void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("test");
            //this.monthCalendar1.Value = this.dateTimePicker1.Value;
   
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
			this.dateTimePicker1 = new Gizmox.WebGUI.Forms.DateTimePicker();
			this.monthCalendar1 = new Gizmox.WebGUI.Forms.MonthCalendar();
			this.SuspendLayout();
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.dateTimePicker1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.dateTimePicker1.Checked = false;
			this.dateTimePicker1.ClientSize = new System.Drawing.Size(184, 20);
            this.dateTimePicker1.Format = DateTimePickerFormat.Long;
            //this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //this.dateTimePicker1.CustomFormat = "dddd MMMM MM/dd/yyyy hh:mm:sstt";
			this.dateTimePicker1.Location = new System.Drawing.Point(32, 40);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.ShowCheckBox = true;
			this.dateTimePicker1.Size = new System.Drawing.Size(284, 20);
			this.dateTimePicker1.TabIndex = 0;
			this.dateTimePicker1.Value = new System.DateTime(2006, 8, 3, 0, 23, 15, 0);
			// 
			// monthCalendar1
			// 
			this.monthCalendar1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.monthCalendar1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.monthCalendar1.ClientSize = new System.Drawing.Size(179, 155);
			this.monthCalendar1.Location = new System.Drawing.Point(32, 96);
			this.monthCalendar1.Name = "monthCalendar1";
			this.monthCalendar1.Size = new System.Drawing.Size(179, 155);
			this.monthCalendar1.TabIndex = 1;
			this.monthCalendar1.Value = new System.DateTime(2006, 8, 3, 22, 1, 48, 78);
			// 
			// DateInputControls
			// 
			this.ClientSize = new System.Drawing.Size(632, 688);
			this.Controls.Add(this.monthCalendar1);
			this.Controls.Add(this.dateTimePicker1);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(632, 688);
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
                    objInspectorForm.SetControls(this.monthCalendar1, this.dateTimePicker1);
                    objInspectorForm.ShowDialog();
                    break;
            }
        }

        #endregion
	}
}
