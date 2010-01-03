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

namespace EduSim.CoreFramework.DataControls
{
    // Sales Revenue, Labor Cost, Material Cost, Automation Cost, Plant Cost, R&D Cost, S&M Cost, Depreciation, S&M, EBIT, Contribution Margin, Tax, Interest, Profit Sharing. Net Profit

    public class PnLDataModel : RoundDataModel
    {
        public int projectedSalesIndex = 0, labourCostIndex = 1, materialCostIndex = 2, inventoryCarryIndex = 3,
            totalVariableIndex = 4, contributionIndex = 5, depreciationIndex = 6, rndIndex = 7, marketingIndex = 8,
            salesIndex = 9, adminIndex = 10, totalPeriodIndex = 11, netMarginIndex = 12, ebitIndex = 0, 
            shortTermIndex = 1, longTermIndex = 2, taxIndex = 3, profitSharingIndex = 4, netProfitIndex = 5;
        public Dictionary<string, List<double>> gridData = new Dictionary<string, List<double>>();
        public List<double> data = new List<double>();

        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, RnDDataView> rndData = GetData<RnDDataView>(SessionConstant.RnDData, round.Id);
            Dictionary<string, MarketingDataView> marketingData = GetData<MarketingDataView>(SessionConstant.MarketingData, round.Id);
            Dictionary<string, ProductionDataView> productionData = GetData<ProductionDataView>(SessionConstant.ProductionData, round.Id);
            Dictionary<string, FinanceDataView> financeData = GetData<FinanceDataView>(SessionConstant.FinanceData, round.Id);

            dataGridView1.Columns.Add("Description", "Description");
            Edusim db = new Edusim(Constants.ConnectionString);

            List<string> products = (from rp in db.RoundProduct
                                     where rp.Round == round
                                     select rp.ProductName).ToList<string>();
            
            products.ForEach(o => 
            {
                dataGridView1.Columns.Add(o, o);
                gridData[o] = new List<double>();
            });

            AddRowForSalesRevenue(marketingData, products, dataGridView1, gridData);

            AddRowForHeader(dataGridView1, "VariableCost");
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "LabourCost", gridData);
            AddRow<ProductionDataView>(productionData, products, dataGridView1, "MaterialCost", gridData);
            AddRowForInventoryCarryCost(productionData, products, dataGridView1, gridData);
            AddRowForTotalVariableCost(products, dataGridView1, gridData);
            AddRowForContributionMargin(products, dataGridView1, gridData);

            AddRowForHeader(dataGridView1, "PeriodCost");
            AddRowForDepreciation(productionData, products, dataGridView1, gridData);
            AddRow<RnDDataView>(rndData, products, dataGridView1, "RnDCost", gridData);
            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "SalesExpense", gridData);
            AddRow<MarketingDataView>(marketingData, products, dataGridView1, "MarketingExpense", gridData);
            AddRowForGeneralAndAdministration(financeData, products, dataGridView1, gridData);
            AddRowForTotalPeriodCost(products, dataGridView1, gridData);
            AddRowForNetMargin(products, dataGridView1, gridData);

            AddRowForEbit(products, dataGridView1, gridData, data);
            AddRowForShortTermInterest(financeData, dataGridView1, data);
            AddRowForLongTermInterest(financeData, dataGridView1, data);
            AddRowForTax(dataGridView1, data);
            AddRowForProfitSharing(dataGridView1, data);
            AddRowForNetProfit(dataGridView1, data);
        }

        private void AddRowForSalesRevenue(Dictionary<string, MarketingDataView> data, List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();

            AddHeader(r, "Sales Revenue");

            foreach (string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();
                if (data != null && data.Count > 0)
                {
                    MarketingDataView dat = data[str];

                    double val = round.Current ? dat.ProjectedSales : dat.UnitPrice * dat.PurchaseQuantity;

                    gridData[str].Add(val);

                    t1.Value = val.ToString("$###0.00");
                }
                else
                {
                    gridData[str].Add(0.0);

                    t1.Value = (0.0).ToString("$###0.00");
                }
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForInventoryCarryCost(Dictionary<string, ProductionDataView> productionData, List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "Inventory");

            products.ForEach(o =>
            {
                double depreciation = productionData[o].Inventory * configurationInfo["InventoryCarryCost"];
                AddMultipleColumnData(depreciation, data, r, o);
            });

            dataGridView1.Rows.Add(r);
        }

        private void AddRowForTotalVariableCost(List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "TotalVariableCost");
            
            products.ForEach( o => 
            {
                double totalVariableCost = data[o][labourCostIndex] + data[o][materialCostIndex] + 
                    data[o][inventoryCarryIndex];
                AddMultipleColumnData(totalVariableCost, data, r, o);
            });

            dataGridView1.Rows.Add(r);
        }

        private void AddRowForContributionMargin(List<string> products, DataGridView dataGridView1, 
            Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "ContributionMargin");
            products.ForEach(o =>
            {
                double contributionMargin = gridData[o][projectedSalesIndex] - gridData[o][totalVariableIndex];
                AddMultipleColumnData(contributionMargin, gridData, r, o);
            });

            dataGridView1.Rows.Add(r);
        }

        private void AddRowForDepreciation(Dictionary<string, ProductionDataView> productionData,
            List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "Depreciation");

            products.ForEach(o =>
            {
                double depreciation = productionData[o].Capacity * configurationInfo["DepreciationFactor"];
                AddMultipleColumnData(depreciation, gridData, r, o);
            });
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForGeneralAndAdministration(Dictionary<string, FinanceDataView> financeData,
            List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "GeneralAndAdministration");

            products.ForEach(o =>
            {
                double gAndAData = gridData[o][totalVariableIndex] * configurationInfo["GAndAFactor"];
                AddMultipleColumnData(gAndAData, gridData, r, o);
            });
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForTotalPeriodCost(List<string> products, DataGridView dataGridView1, 
            Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "TotalPeriodCost");

            products.ForEach(o =>
            {
                double totalPeriodCost = data[o][depreciationIndex] + data[o][rndIndex] +
                    data[o][marketingIndex] + data[o][salesIndex] + data[o][adminIndex];
                AddMultipleColumnData(totalPeriodCost, data, r, o);
            });
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForNetMargin(List<string> products, DataGridView dataGridView1, Dictionary<string, List<double>> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "NetMargin");

            products.ForEach(o =>
            {
                double netMargin = data[o][contributionIndex] - data[o][totalPeriodIndex];
                AddMultipleColumnData(netMargin, data, r, o);
            });
            dataGridView1.Rows.Add(r);
        }

        private void AddRowForEbit(List<string> products, DataGridView dataGridView1,
            Dictionary<string, List<double>> gridData, List<double> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "EBIT");
            double ebit= 0;
            foreach (string str in products)
            {
                ebit += gridData[str][netMarginIndex];
            }

            AddSingleColumnData(dataGridView1, data, r, ebit);
        }

        private void AddRowForShortTermInterest(Dictionary<string, FinanceDataView> financeData, 
            DataGridView dataGridView1, List<double> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "ShortTermInterest");

            double shortTermLoan = 0;
            foreach (FinanceDataView d in financeData.Values)
            {
                shortTermLoan += d.ShortTermLoan;
            }

            AddSingleColumnData(dataGridView1, data, r, shortTermLoan * configurationInfo["ShortTermInterestRate"]);
        }

        private void AddRowForLongTermInterest(Dictionary<string, FinanceDataView> financeData, 
            DataGridView dataGridView1, List<double> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "LongTermInterest");

            double longTermLoan = 0;
            foreach (FinanceDataView d in financeData.Values)
            {
                longTermLoan += d.LongTermLoan;
            }

            AddSingleColumnData(dataGridView1, data, r, longTermLoan * configurationInfo["LongTermInterestRate"]);
        }

        private void AddRowForTax(DataGridView dataGridView1, List<double> data)
        {
            DataGridViewRow r = new DataGridViewRow();

            AddHeader(r, "Tax");

            AddSingleColumnData(dataGridView1, data, r, data[ebitIndex] * configurationInfo["TaxRate"]);
        }

        private void AddRowForProfitSharing(DataGridView dataGridView1
            , List<double> data)
        {
            DataGridViewRow r = new DataGridViewRow();
            AddHeader(r, "ProfitSharing");

            AddSingleColumnData(dataGridView1, data, r, data[ebitIndex] * configurationInfo["ProfitSharingRate"]);
        }

        private void AddRowForNetProfit(DataGridView dataGridView1,
            List<double> data)
        {
            DataGridViewRow r = new DataGridViewRow();

            AddHeader(r, "NetProfit");

            double netProfit = data[ebitIndex] - 
                (data[shortTermIndex] + data[longTermIndex] + data[taxIndex] + data[profitSharingIndex]);

            AddSingleColumnData(dataGridView1, data, r, netProfit);
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            throw new NotImplementedException();
        }
    }
}
