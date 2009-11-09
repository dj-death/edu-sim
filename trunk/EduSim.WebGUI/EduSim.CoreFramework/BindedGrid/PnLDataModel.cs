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
        Dictionary<string, List<double>> data = new Dictionary<string, List<double>>();
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
            
            products.ForEach(o => 
            {
                dataGridView1.Columns.Add(o, o);
                data[o] = new List<double>();
            });

            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "ProjectedSales", data);
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "LabourCost", data);
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "MaterialCost", data);
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "AutomationCost", data);
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "NewCapacityCost", data);
            AddRow<RnDDataView>(rndData, products, dataGridView1, "RnDCost", data);
            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "SalesExpense", data);
            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "MarketingExpense", data);
            AddRowForDepreciation(productionData, products, dataGridView1, data);
            AddRowForGeneralAndAdministration(financeData, products, dataGridView1, data);
            AddRowForEbit(products, dataGridView1, data);
            AddRowForContributionMargin(productionData, products, dataGridView1, data);
            AddRowForInterestAndTax(financeData, products, dataGridView1, data);
            AddRowForProfitSharing(products, dataGridView1, data);
            AddRowForNetProfit(products, dataGridView1, data);
        }

        private void AddRowForNetProfit(List<string> products, DataGridView dataGridView1, 
            Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();

            DataGridViewCell t = new DataGridViewTextBoxCell();
            t.Value = "NetProfit";
            r.Cells.Add(t);

            foreach (string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();
                double sum = 0;
                bool skipFirstRow = true;
                foreach (double val in gridData[str])
                {
                    if (!skipFirstRow)
                    {
                        sum += val;
                    }
                    skipFirstRow = false;
                }

                t1.Value = (gridData[str][0] - sum).ToString("$###0.00");
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForProfitSharing(List<string> products, DataGridView dataGridView1
            , Dictionary<string, List<double>> gridData)
        {
        }

        private void AddRowForContributionMargin(Dictionary<string, ProductionDataView> productionData,
            List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
        }

        private void AddRowForEbit(List<string> products, DataGridView dataGridView1, 
            Dictionary<string, List<double>> gridData)
        {
        }

        private void AddRowForGeneralAndAdministration(Dictionary<string, FinanceDataView> financeData,
            List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
        }

        private void AddRowForInterestAndTax(Dictionary<string, FinanceDataView> financeData,
            List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
        }

        private void AddRowForDepreciation(Dictionary<string, ProductionDataView> productionData,
            List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
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

                double depreciation = productionData[str].Capacity * configurationInfo["CapacityCost"] * 0.1;
                t1.Value = depreciation.ToString("$###0.00");

                gridData[str].Add(depreciation);
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }

        private void AddRow<T>(Dictionary<string, T> data, IEnumerable<string> products, 
            DataGridView dataGridView1, string p, Dictionary<string, List<double>> gridData)
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

                    double val = prop.GetValue(dat, null).ToDouble2();
                    t1.Value = val.ToString("$###0.00");
                    gridData[str].Add(val);
                }
                else
                {
                    t1.Value = (0.0).ToString("$###0.00");
                    gridData[str].Add(0.0);
                }
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 3, 4, 5 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            throw new NotImplementedException();
        }
    }
}
