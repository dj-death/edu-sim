#region Using

using System;
using System.Globalization;


using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using EduSim.UserManagementBL;
using EduSim.CoreFramework.DTO;
using System.Web;
using EduSim.WebGUI.UI;
using EduSim.CoreFramework.Common;
using System.Collections.Generic;
using EduSim.CoreFramework.Utilities;



#endregion

namespace EduSim.CoreFramework.Common
{
	#region Logon Class
	
	/// <summary>
	/// Impementation for Logon class.
	/// </summary>

    [Serializable()]
    public class ProductForm : Form ,ILogonForm
	{
	
		#region Class Members

        private Label mobjLabelProduct;
        private TextBox mobjTextProduct;

        private Label segmentTypeLabel;
        private ComboBox segmentType;

        private Button mobjButtonAdd;
		private Button mobjButtonClear;
		private Panel mobjPanelTitle;
		private Panel mobjPanelLine;
		private Label mobjLabelMessage;
        private Dictionary<string, int> segmentDetails = new Dictionary<string, int>();
        private Round round;
		/// <summary>
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		#endregion

		#region C'Tor/D'Tor

		/// <summary>
		/// Creates a new <see cref="LogonForm"/> instance.
		/// </summary>
		public ProductForm(Round round)
		{
            this.round = round;
            segmentDetails["Traditional"] = 1;
            segmentDetails["Low"] = 2;
            segmentDetails["High"] = 3;
            segmentDetails["Performance"] = 4;
            segmentDetails["Size"] = 5;
			InitializeComponent();

			#region Attach Events

			this.mobjButtonAdd.Click+=new EventHandler(mobjButtonAdd_Click);
			this.mobjButtonClear.Click+=new EventHandler(mobjButtonClear_Click);

			#endregion 


			this.Load+=new EventHandler(Logon_Load);

			this.mobjTextProduct.EnterKeyDown+=new KeyEventHandler(mobjTextProduct_EnterKeyDown);

            this.KeyDown += new KeyEventHandler(LogonForm_KeyDown);
		}

        void LogonForm_KeyDown(object objSender, KeyEventArgs objArgs)
        {
        }

		#endregion 

		#region Windows Form Designer generated code


		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjTextProduct = new TextBox();

            this.mobjButtonAdd = new Button();
			this.mobjLabelProduct = new Label();
            this.segmentType = new ComboBox();
            this.segmentTypeLabel = new Label();

            this.mobjButtonClear = new Button();
			this.mobjPanelTitle = new Panel();
			this.mobjPanelLine = new Panel();
			this.mobjLabelMessage = new Label();
			this.SuspendLayout();
			// 
			// mobjTextUsername
			// 
			this.mobjTextProduct.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
				| AnchorStyles.Right)));
            this.mobjTextProduct.Location = new System.Drawing.Point(110, 80);
            this.mobjTextProduct.Name = "mobjTextProduct";
            this.mobjTextProduct.Size = new System.Drawing.Size(192, 18);
            this.mobjTextProduct.TabIndex = 0;
            this.mobjTextProduct.Text = "";

            this.segmentType.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                | AnchorStyles.Right)));
            this.segmentType.Location = new System.Drawing.Point(110, 112);
            this.segmentType.Name = "segmentType";
            this.segmentType.Size = new System.Drawing.Size(192, 18);
            this.segmentType.TabIndex = 1;

            foreach (string str in segmentDetails.Keys)
            {
                this.segmentType.Items.Add(str);
            }
            // 
			// mobjButtonLogon
			// 
			this.mobjButtonAdd.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            this.mobjButtonAdd.Location = new System.Drawing.Point(128, 232);
            this.mobjButtonAdd.Name = "mobjButtonLogon";
            this.mobjButtonAdd.Size = new System.Drawing.Size(72, 23);
            this.mobjButtonAdd.TabIndex = 5;
            this.mobjButtonAdd.Text = "Add";

            // 
			// mobjLabelUsername
			// 
			this.mobjLabelProduct.Location = new System.Drawing.Point(16, 80);
            this.mobjLabelProduct.Name = "mobjLabelProduct";
            this.mobjLabelProduct.Size = new System.Drawing.Size(100, 16);
            this.mobjLabelProduct.TabIndex = 4;
            this.mobjLabelProduct.Text = "Product Name:";

            this.segmentTypeLabel.Location = new System.Drawing.Point(16, 112);
            this.segmentTypeLabel.Name = "mobjLabelProduct";
            this.segmentTypeLabel.Size = new System.Drawing.Size(100, 16);
            this.segmentTypeLabel.TabIndex = 4;
            this.segmentTypeLabel.Text = "Segment Type:";
            // 
			// mobjButtonClear
			// 
			this.mobjButtonClear.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.mobjButtonClear.Location = new System.Drawing.Point(208, 232);
			this.mobjButtonClear.Name = "mobjButtonClear";
			this.mobjButtonClear.TabIndex = 6;
			this.mobjButtonClear.Text = "Clear";
			// 
			// mobjPanelTitle
			// 
			this.mobjPanelTitle.BackColor = System.Drawing.Color.White;
			this.mobjPanelTitle.Dock = DockStyle.Top;
			this.mobjPanelTitle.Location = new System.Drawing.Point(0, 0);
			this.mobjPanelTitle.Name = "mobjPanelTitle";
			this.mobjPanelTitle.Size = new System.Drawing.Size(292, 56);
			this.mobjPanelTitle.TabIndex = 7;
			// 
			// mobjPanelLine
			// 
			this.mobjPanelLine.BackColor = System.Drawing.SystemColors.Desktop;
			this.mobjPanelLine.Dock = DockStyle.Top;
			this.mobjPanelLine.Location = new System.Drawing.Point(0, 56);
			this.mobjPanelLine.Name = "mobjPanelLine";
			this.mobjPanelLine.Size = new System.Drawing.Size(292, 6);
			this.mobjPanelLine.TabIndex = 8;
			// 
			// mobjLabelMessage
			// 
			this.mobjLabelMessage.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
				| AnchorStyles.Right)));
			this.mobjLabelMessage.ForeColor = System.Drawing.Color.Red;
			this.mobjLabelMessage.Location = new System.Drawing.Point(88, 208);
			this.mobjLabelMessage.Name = "mobjLabelMessage";
			this.mobjLabelMessage.Size = new System.Drawing.Size(272, 40);
			this.mobjLabelMessage.TabIndex = 9;
			// 
			// LogonForm
			// 			
			this.ClientSize = new System.Drawing.Size(292, 264);
            this.Controls.Add(this.mobjLabelProduct);
            this.Controls.Add(this.mobjTextProduct);
            this.Controls.Add(this.segmentTypeLabel);
            this.Controls.Add(this.segmentType);

            this.Controls.Add(this.mobjPanelLine);
			this.Controls.Add(this.mobjPanelTitle);
			this.Controls.Add(this.mobjButtonClear);
			this.Controls.Add(this.mobjButtonAdd);
			this.Name = "ProductForm";
			this.Text = "Add New Product";
			this.ResumeLayout(false);
			this.ClientSize = new System.Drawing.Size(292, 284);
		}
		#endregion

		private void mobjButtonAdd_Click(object sender, EventArgs e)
		{
            //Create RnD information for new product
            //Create Marketing information for new product
            //Create Production information for new product
            Dictionary<string, RnDDataView> rndData = RoundDataModel.GetData<RnDDataView>(SessionConstant.RnDData, round.Id);
            Dictionary<string, MarketingDataView> mktData = RoundDataModel.GetData<MarketingDataView>(SessionConstant.MarketingData, round.Id);
            Dictionary<string, ProductionDataView> prodData = RoundDataModel.GetData<ProductionDataView>(SessionConstant.ProductionData, round.Id);

            if (rndData.ContainsKey(mobjTextProduct.Text))
            {
                MessageBox.Show("Product Name already exists");
            }

            if (!mobjTextProduct.Text.Equals(string.Empty))
            {
                Edusim db = new Edusim(Constants.ConnectionString);

                RoundProduct rp = new RoundProduct()
                {
                    RoundId = round.Id,
                    ProductName = mobjTextProduct.Text,
                    SegmentTypeId = segmentDetails[segmentType.SelectedItem as string]
                };

                db.RoundProduct.InsertOnSubmit(rp);
                RnDData rnd = new RnDData
                {
                    RoundProduct = rp,
                    PreviousAge = 0,
                    PreviousPerformance = 0,
                    PreviousReliability = 0,
                    PreviousRevisionDate = DateTime.Now,
                    PreviousSize = 0,
                };
                db.RnDData.InsertOnSubmit(rnd);
                MarketingData md = new MarketingData()
                {
                    RoundProduct = rp,
                    PreviousSaleExpense = 0,
                    PreviousMarketingExpense = 0,
                    PreviousPrice = 0,
                    PreviousForecastingQuantity = 0,
                };
                db.MarketingData.InsertOnSubmit(md);
                //Create ProductionData
                ProductionData pd = new ProductionData()
                {
                    RoundProduct = rp,
                    PreviousNumberOfLabour = 0,
                    OldCapacity = 0,
                    Inventory = 0,
                    CurrentAutomation = 0,
                };
                db.ProductionData.InsertOnSubmit(pd);

                db.SubmitChanges();

                rndData[mobjTextProduct.Text] = SessionManager.CopyRndDataToView(rnd, rp);
                mktData[mobjTextProduct.Text] = SessionManager.CopyMarketingDataToView(md, rp);
                prodData[mobjTextProduct.Text] = SessionManager.CopyProductionDataToView(pd, rp, md);
            }
        }

		private void mobjButtonClear_Click(object sender, EventArgs e)
		{
			Context.Session.IsLoggedOn = false;
			mobjLabelMessage.Text="";
			mobjTextProduct.Text="";
		}

		private void Logon_Load(object sender, EventArgs e)
		{
		}

		private void mobjTextProduct_EnterKeyDown(object objSender, KeyEventArgs objArgs)
		{
			mobjButtonAdd_Click(mobjButtonAdd ,EventArgs.Empty);
		}
	}
	
	#endregion
}
