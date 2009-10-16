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
	/// Summary description for UpDownControls.
	/// </summary>

    [Serializable()]
    public class UpDownControls : Gizmox.WebGUI.Forms.UserControl, IHostedApplication
	{
		private Gizmox.WebGUI.Forms.DomainUpDown domainUpDown1;
		private Gizmox.WebGUI.Forms.NumericUpDown numericUpDown1;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public UpDownControls()
		{
			// This call is required by the Windows.Forms Form Designer.
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
			this.domainUpDown1 = new Gizmox.WebGUI.Forms.DomainUpDown();
			this.numericUpDown1 = new Gizmox.WebGUI.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// domainUpDown1
			// 
			this.domainUpDown1.Items.Add("Guy");
			this.domainUpDown1.Items.Add("Lital");
			this.domainUpDown1.Items.Add("Rotem");
			this.domainUpDown1.Items.Add("Dina");
			this.domainUpDown1.Items.Add("Navot");
			this.domainUpDown1.Items.Add("Miri");
			this.domainUpDown1.Items.Add("Jacko");
			this.domainUpDown1.Items.Add("Bob");
			this.domainUpDown1.Location = new System.Drawing.Point(32, 48);
			this.domainUpDown1.Name = "domainUpDown1";
			this.domainUpDown1.Size = new System.Drawing.Size(232, 20);
			this.domainUpDown1.TabIndex = 0;
			this.domainUpDown1.Text = "Lital";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(32, 120);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(232, 20);
			this.numericUpDown1.TabIndex = 1;
            // 
			// UpDownControls
			// 
			this.Controls.Add(this.numericUpDown1);
		//	this.Controls.Add(this.domainUpDown1);
			this.Name = "UpDownControls";
			this.Size = new System.Drawing.Size(688, 544);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
                    objInspectorForm.SetContainer(this);
                    objInspectorForm.ShowDialog();
                    break;
            }
        }
        #endregion
	}
}
