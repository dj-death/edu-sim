using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Dialogs;
using Gizmox.WebGUI.Common.Resources;
using Microsoft.Reporting.WebForms;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
	/// <summary>
	/// Summary description for TreeViewControl.
	/// </summary>

    [Serializable()]
    public class ReportViewerControl : UserControl, IHostedApplication
	{



        
        private Gizmox.WebGUI.Reporting.ReportViewer reportViewer1;

		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized] 
        private System.ComponentModel.Container components = null;

        private static DataTable mobjReportData = null;

        public ReportViewerControl()
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
            this.reportViewer1 = new Gizmox.WebGUI.Reporting.ReportViewer();
			this.SuspendLayout();
			// 
			// treeView1
			// 
            this.reportViewer1.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
            this.reportViewer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(602, 602);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.HostedPageLoadComplete += new Gizmox.WebGUI.Forms.Hosts.AspPageEventHandler(reportViewer1_HostedPageLoadComplete);
            this.reportViewer1.Search += new SearchEventHandler(reportViewer1_Search);

			// 
			// TreeViewControl
			// 
			this.ClientSize = new System.Drawing.Size(608, 544);
            this.Controls.Add(this.reportViewer1);
			this.DockPadding.All = 3;
			this.Size = new System.Drawing.Size(608, 544);
			this.ResumeLayout(false);
		}

        void reportViewer1_HostedPageLoadComplete(object sender, Gizmox.WebGUI.Forms.Hosts.AspPageEventArgs e)
        {
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = @"Resources\Data\Report.rdl";
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Sales", LoadSalesData(this.Context)));
        }

        void reportViewer1_Search(object sender, SearchEventArgs e)
        {
            MessageBox.Show(e.SearchString);
        }
		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
		}


        private static DataTable LoadSalesData(IContext objContext)
        {
            if (mobjReportData == null)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(objContext.Server.MapPath(@"~\Resources\Data\Report.xml"));
                mobjReportData = dataSet.Tables[0];
            }
            return mobjReportData;
        }

		public HostedToolBarElement[] GetToolBarElements()
		{
			ArrayList objElements = new ArrayList();
            //objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			HostedToolBarToggleButton objHostedToolBarToggleButton = null;

			string strAction = (string)objButton.Tag;
			switch(strAction)
			{
                case "ShowToolbar":
                    objHostedToolBarToggleButton = objButton as HostedToolBarToggleButton;

                    break;
                case "Help":
                    reportViewer1.ShowExportControls = !reportViewer1.ShowExportControls;
                    reportViewer1.Update();
                    //Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "ReportViewer class");
                    break;

			}
		}

		#endregion
	}
}
