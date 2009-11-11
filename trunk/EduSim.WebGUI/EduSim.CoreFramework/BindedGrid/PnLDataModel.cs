using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;
using System.Reflection;
using EduSim.CoreUtilities.Utility;
using System.Drawing;

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
            Edusim db = new Edusim(Constants.ConnectionString);

            List<string> products = (from rp in db.RoundProduct
                                     where rp.Round == round
                                     select rp.ProductName).ToList<string>();
            
            products.ForEach(o => 
            {
                dataGridView1.Columns.Add(o, o);
                data[o] = new List<double>();
            });

            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "ProjectedSales", data);

            AddRowForHeader(dataGridView1, "VariableCost");
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "LabourCost", data);
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "MaterialCost", data);
            AddRowForInventoryCarryCost(productionData, products, dataGridView1, data);
            AddRowForTotalVariableCost(products, dataGridView1, data);
            AddRowForContributionMargin(products, dataGridView1, data);

            AddRowForHeader(dataGridView1, "PeriodCost");
            AddRowForDepreciation(productionData, products, dataGridView1, data);
            AddRow<RnDDataView>(rndData, products, dataGridView1, "RnDCost", data);
            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "SalesExpense", data);
            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "MarketingExpense", data);
            AddRowForGeneralAndAdministration(financeData, products, dataGridView1, data);
            AddRowForNetMargin(products, dataGridView1, data);

            AddRowForEbit(dataGridView1, data);
            AddRowForShortTermInterest(financeData, dataGridView1, data);
            AddRowForLongTermInterest(financeData, dataGridView1, data);
            AddRowForTax(dataGridView1, data);
            AddRowForProfitSharing(dataGridView1, data);
            AddRowForNetProfit(dataGridView1, data);
        }

        private void AddRowForTax(DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();

            AddHeader(r, "Tax");

            dataGridView1.Rows.Add(r);
        }

        private void AddRowForLongTermInterest(Dictionary<string, FinanceDataView> financeData, DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "LongTermInterest");
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForShortTermInterest(Dictionary<string, FinanceDataView> financeData, DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "ShortTermInterest");
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForNetMargin(List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "NetMargins");
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForTotalVariableCost(List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "TotalVariableCost");
            foreach (string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();

                double totalVariableCost = data[str][1] + data[str][2] + data[str][3];
                t1.Value = totalVariableCost;

                data[str].Add(totalVariableCost);
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForHeader(DataGridView dataGridView1, string header)
        {
            DataGridViewRow r = new DataGridViewRow();

            DataGridViewCell t = new DataGridViewTextBoxCell();
            t.Value = header;
            t.Style = new DataGridViewCellStyle();
            t.Style.BackColor = Color.Gray;
            r.Cells.Add(t);

            dataGridView1.Rows.Add(r);
        }

        private void AddRowForInventoryCarryCost(Dictionary<string, ProductionDataView> productionData, List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();

            AddHeader(r, "Inventory");

            foreach (string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();

                double depreciation = productionData[str].Inventory * configurationInfo["InventoryCarryCost"];
                t1.Value = depreciation.ToString("$###0.00");

                data[str].Add(depreciation);
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }

        private static void AddHeader(DataGridViewRow r, string header)
        {
            DataGridViewCell t = new DataGridViewTextBoxCell();
            t.Value = header;
            r.Cells.Add(t);
        }

        private void AddRowForNetProfit(DataGridView dataGridView1, 
            Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();

            AddHeader(r, "NetProfit");

            dataGridView1.Rows.Add(r);
        }

        private void AddRowForProfitSharing(DataGridView dataGridView1
            , Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "ProfitSharing");
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForContributionMargin( List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "ContributionMargin");
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForEbit(DataGridView dataGridView1, 
            Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "EBIT");
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForGeneralAndAdministration(Dictionary<string, FinanceDataView> financeData,
            List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "GeneralAndAdministration");
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForDepreciation(Dictionary<string, ProductionDataView> productionData,
            List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
            //Get the Plant capacity and Cost per Plant
            //Calculate the total cost
            //Depreciate it by 10%
            DataGridViewRow r = new DataGridViewRow();

            AddHeader(r, "Depreciation");

            foreach (string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();

                double depreciation = productionData[str].Capacity * configurationInfo["DepreciationFactor"];
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

            AddHeader(r, p);

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
