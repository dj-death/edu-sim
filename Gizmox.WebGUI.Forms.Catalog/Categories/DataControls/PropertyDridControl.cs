using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
	/// <summary>
	/// Summary description for PropertyDridControl.
	/// </summary>

    [Serializable()]
    public class PropertyDridControl : UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.PropertyGrid propertyGrid1;
		private Gizmox.WebGUI.Forms.Panel panel1;
		private Gizmox.WebGUI.Forms.Label label1;
		private Gizmox.WebGUI.Forms.Splitter splitter1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public PropertyDridControl()
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.propertyGrid1 = new Gizmox.WebGUI.Forms.PropertyGrid();
			this.panel1 = new Gizmox.WebGUI.Forms.Panel();
			this.label1 = new Gizmox.WebGUI.Forms.Label();
			this.splitter1 = new Gizmox.WebGUI.Forms.Splitter();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.propertyGrid1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.propertyGrid1.CategoryForeColor = System.Drawing.Color.Empty;
			this.propertyGrid1.ClientSize = new System.Drawing.Size(264, 672);
			this.propertyGrid1.CommandsVisibleIfAvailable = false;
			this.propertyGrid1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.propertyGrid1.DockPadding.All = 0;
			this.propertyGrid1.DockPadding.Bottom = 0;
			this.propertyGrid1.DockPadding.Left = 0;
			this.propertyGrid1.DockPadding.Right = 0;
			this.propertyGrid1.DockPadding.Top = 0;
			this.propertyGrid1.HelpForeColor = System.Drawing.Color.Black;
            this.propertyGrid1.HelpBackColor = System.Drawing.SystemColors.ControlLight;
			this.propertyGrid1.HelpVisible = true;
			this.propertyGrid1.LineColor = System.Drawing.Color.Empty;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.PropertySort = Gizmox.WebGUI.Forms.PropertySort.CategorizedAlphabetical;
			this.propertyGrid1.SelectedObject = null;
			this.propertyGrid1.Size = new System.Drawing.Size(264, 672);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Control;
			this.propertyGrid1.ViewForeColor = System.Drawing.Color.Black;
			// 
			// panel1
			// 
			this.panel1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.panel1.AutoScroll = true;
			this.panel1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.panel1.ClientSize = new System.Drawing.Size(405, 672);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
			this.panel1.DockPadding.All = 0;
			this.panel1.DockPadding.Bottom = 0;
			this.panel1.DockPadding.Left = 0;
			this.panel1.DockPadding.Right = 0;
			this.panel1.DockPadding.Top = 0;
			this.panel1.Location = new System.Drawing.Point(267, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(405, 672);
			this.panel1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
			this.label1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.label1.ClientSize = new System.Drawing.Size(100, 23);
			this.label1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
			this.label1.Location = new System.Drawing.Point(80, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "This is a label.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// splitter1
			// 
			this.splitter1.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
			this.splitter1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.None;
			this.splitter1.ClientSize = new System.Drawing.Size(3, 672);
			this.splitter1.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
			this.splitter1.Location = new System.Drawing.Point(264, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 672);
			this.splitter1.TabIndex = 2;
			// 
			// PropertyDridControl
			// 
			this.ClientSize = new System.Drawing.Size(672, 680);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.propertyGrid1);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(672, 680);
			this.Load += new System.EventHandler(this.PropertyDridControl_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void PropertyDridControl_Load(object sender, System.EventArgs e)
		{
            // TODO: Add any initialization after the InitializeComponent call
            this.propertyGrid1.SelectedObject = this.label1;
		}

        #region IHostedApplication Members

        public void InitializeApplication()
        {
        }

        public HostedToolBarElement[] GetToolBarElements()
        {
            ArrayList objElements = new ArrayList();
            
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));

            return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
        }

        public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
        {            

            string strAction = (string)objButton.Tag;

            switch (strAction)
            {
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.propertyGrid1);
                    objInspectorForm.ShowDialog();
                    break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "PropertyGrid class");
                    break;
            }
        }

        #endregion
	}
}
