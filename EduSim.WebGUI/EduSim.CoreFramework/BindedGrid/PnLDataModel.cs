using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;
using System.Reflection;
using EduSim.CoreUtilities.Utility;

namespace EduSim.WebGUI.UI.BindedGrid
{
    // Sales Revenue, Labor Cost, Material Cost, Automation Cost, Plant Cost, R&D Cost, S&M Cost, Depreciation, S&M, EBIT, Contribution Margin, Tax, Interest, Profit Sharing. Net Profit

    public class PnLDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, RnDDataView> rndData = GetData<RnDDataView>(SessionConstants.RnDData);
            Dictionary<string, MarketingDataView> marketingData = GetData<MarketingDataView>(SessionConstants.MarketingData);
            Dictionary<string, ProductionDataView> productionData = GetData<ProductionDataView>(SessionConstants.ProductionData);
            Dictionary<string, FinanceDataView> financeData = GetData<FinanceDataView>(SessionConstants.FinanceData);


            dataGridView1.Columns.Add("Description", "Description");
            Edusim db = new Edusim();

            List<string> products = (from rp in db.RoundProduct
                                     where rp.Round == round
                                     select rp.ProductName).ToList<string>();
            
            products.ForEach(o => dataGridView1.Columns.Add(o, o) );

            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "ProjectedSales");
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "LabourCost");
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "MaterialCost");
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "AutomationCost");
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "NewCapacityCost");
            AddRow<RnDDataView>(rndData, products, dataGridView1, "RnDCost");
            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "SalesExpense");
            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "MarketingExpense");
            AddRowForDepreciation(productionData, products, dataGridView1);
            AddRowForGeneralAndAdministration(financeData, products, dataGridView1);
            AddRowForEbit(products, dataGridView1);
            AddRowForContributionMargin(productionData, products, dataGridView1);
            AddRowForInterestAndTax(financeData, products, dataGridView1);
            AddRowForProfitSharing(products, dataGridView1);
            AddRowForNetProfit(products, dataGridView1);
        }

        private void AddRowForNetProfit(List<string> products, DataGridView dataGridView1)
        {
        }

        private void AddRowForProfitSharing(List<string> products, DataGridView dataGridView1)
        {
        }

        private void AddRowForContributionMargin(Dictionary<string, ProductionDataView> productionData, List<string> products, DataGridView dataGridView1)
        {
        }

        private void AddRowForEbit(List<string> products, DataGridView dataGridView1)
        {
        }

        private void AddRowForGeneralAndAdministration(Dictionary<string, FinanceDataView> financeData, List<string> products, DataGridView dataGridView1)
        {
        }

        private void AddRowForInterestAndTax(Dictionary<string, FinanceDataView> financeData, List<string> products, DataGridView dataGridView1)
        {
        }

        private void AddRowForDepreciation(Dictionary<string, ProductionDataView> productionData, List<string> products, DataGridView dataGridView1)
        {
            //Get the Plant capacity and Cost per Plant
            //Calculate the total cost
            //Depreciate it by 10%
            DataGridViewRow r = new DataGridViewRow();

            DataGridViewCell t = new DataGridViewTextBoxCell();
            t.Value = "Depreciation";
            r.Cells.Add(t);

            foreach (string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();

                t1.Value = (productionData[str].Capacity * configurationInfo["CapacityCost"] * 0.1).ToString("$###0.00");
            }
            dataGridView1.Rows.Add(r);
        }

        private void AddRow<T>(Dictionary<string, T> data, IEnumerable<string> products, DataGridView dataGridView1, string p)
        {
            DataGridViewRow r = new DataGridViewRow();

            DataGridViewCell t = new DataGridViewTextBoxCell();
            t.Value = p;
            r.Cells.Add(t);

            foreach(string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();
                if (data != null && data.Count > 0)
                {
                    T dat = data[str];
                    PropertyInfo prop = dat.GetType().GetProperty(p);

                    t1.Value = prop.GetValue(dat, null).ToDouble2().ToString("$###0.00");
                }
                else
                {
                    t1.Value = (0.0).ToString("$###0.00");
                }
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 3, 4, 5 };
        }

        public override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c)
        {
            throw new NotImplementedException();
        }

        public override void ComputeAllCells(DataGridView dataGridView1)
        {
        }

        public override void Save(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }
    }
}
