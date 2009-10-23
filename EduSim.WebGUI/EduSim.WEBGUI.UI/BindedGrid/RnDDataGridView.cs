using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using System.Linq;
using EduSim.CoreFramework.DTO;
using System.Web;
using EduSim.WebGUI.UI;
using EduSim.CoreUtilities.Utility;
using System.Collections.Generic;
using EduSim.CoreFramework.Common;

//Test
namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
	/// <summary>
	/// Summary description for DataGridViewControl.
	/// </summary>

    [Serializable()]
    public class RnDDataGridView : UserControl, IHostedApplication
	{
        private DataGridView dataGridView1;
        private Button compute;
        private Button save;
        private Button addProduct;
        private RoundDataModel rdm;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;
        private Dictionary<string, string> parameter = new Dictionary<string,string>();

        public RnDDataGridView(Type model)
        {
            // This call is required by the WebGUI Form Designer.
            InitializeComponent();

            rdm = Activator.CreateInstance(model) as RoundDataModel;

            this.dataGridView1.DataSource = rdm.GetList();

            foreach (DataGridViewColumn d in this.dataGridView1.Columns)
            {
                d.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (rdm.Current)
            {
                foreach (int readOnlyColumn in rdm.HiddenColumns())
                {
                    this.dataGridView1.Columns[readOnlyColumn].ReadOnly = true;
                    DataGridViewCellStyle s = this.dataGridView1.Columns[readOnlyColumn].DefaultCellStyle;

                    s.BackColor = Color.LightGray;

                }
            }
            else
            {
                foreach (DataGridViewColumn d in this.dataGridView1.Columns)
                {
                    d.ReadOnly = true;
                }
            }
        }

		#region Component Designer generated code
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
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            compute = new Button();
            save = new Button() ;
            addProduct = new Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();

            compute.Location = new Point(16, 0);
            compute.Name = "backButton";
            compute.Text = "Compute";
            compute.Size = new Size(60, 20);
            compute.Click += new EventHandler((sender, e) =>
            {
                rdm.ComputeAllCells(dataGridView1);
            });

            save.Location = new Point(70, 0);
            save.Name = "saveButton";
            save.Text = "Save";
            save.Size = new Size(60, 20);
            save.Click += new EventHandler((sender, e) =>
            {
                rdm.Save(dataGridView1);
            });

            addProduct.Location = new Point(120, 0);
            addProduct.Name = "addProduct";
            addProduct.Text = "Add Product";
            addProduct.Size = new Size(100, 20);
            addProduct.Click += new EventHandler((sender, e) =>
            {
                rdm.ComputeAllCells(dataGridView1);
            });

            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(575, 452);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackColor = Color.White;
            this.dataGridView1.DefaultCellStyle.BackColor = Color.White;
            this.dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;

            //this.dataGridView1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
			// 
			// DataGridViewControl
			// 
			this.ClientSize = new System.Drawing.Size(640, 600);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.compute);
            this.Controls.Add(this.save);
            this.Controls.Add(this.addProduct);
            this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(640, 600);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell c = row.Cells[e.ColumnIndex];

            rdm.HandleDataChange(row, c);
            //MessageBox.Show("hi there the value is " + c.Value);
        }

		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
			// TODO: Add DataGridViewControl.InitializeApplication implementation
		}

		public HostedToolBarElement[] GetToolBarElements()
		{
			ArrayList objElements = new ArrayList();
			objElements.Add(new HostedToolBarButton("Update",new IconResourceHandle("Save.gif"),"Update"));
            objElements.Add(new HostedToolBarButton("Copy", new IconResourceHandle("Copy.gif"), "Copy"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{			
			string strAction = (string)objButton.Tag;
			switch(strAction)
			{
				case "Update":
					//mobjDatabaseData.CommitChanges();
					break;
				case "Copy":
                    // Copy the clipboard content to the clipboard
                    Clipboard.SetDataObject(this.dataGridView1.GetClipboardContent(TextDataFormat.Html));
                    // Send to client and clear clipboard
                    Clipboard.Update(TextDataFormat.Html);
                    break;
                case "Properties":
                    //InspectorForm objInspectorForm = new InspectorForm();
                    //objInspectorForm.SetControls(this.dataGridView1);
                    //objInspectorForm.ShowDialog();
                    break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "DataGridView class");
                    break;
			}
		}

		#endregion
	}
}
