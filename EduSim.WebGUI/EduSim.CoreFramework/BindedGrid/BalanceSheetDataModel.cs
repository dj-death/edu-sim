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

    public class BalanceSheetDataModel : RoundDataModel
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
            
            financeData.Keys.ToList<string>().ForEach(o => 
            {
                dataGridView1.Columns.Add(o, o);
                gridData[o] = new List<double>();
            });

            AddRowForHeader(dataGridView1, "Current Asset");
            AddRow<FinanceDataView>(financeData, financeData.Keys, dataGridView1, "Cash", gridData);
            AddRow<ProductionDataView>(productionData, products, financeData.Keys, dataGridView1, gridData, "Inventory", configurationInfo["InventoryCarryCost"]);

            AddRowForHeader(dataGridView1, "Fixed Asset");
            AddRow(productionData, products, financeData.Keys, dataGridView1, gridData, "Capacity", configurationInfo["CapacityCost"]);
            AddRow(productionData, products, financeData.Keys, dataGridView1, gridData, "NewCapacity", configurationInfo["CapacityCost"]);
            AddRow(productionData, products, financeData.Keys, dataGridView1, gridData, "NewAutomation", configurationInfo["AutomationCost"]);

            AddRowForHeader(dataGridView1, "Liabalities");
            AddRow<FinanceDataView>(financeData, financeData.Keys, dataGridView1, "ShortTermLoan", gridData);
            AddRow<FinanceDataView>(financeData, financeData.Keys, dataGridView1, "LongTermLoan", gridData);

            AddRowForHeader(dataGridView1, "Owners Equity");
            //TODO: we need to implement Shares equity instrument
            AddRowForColumnDefault(dataGridView1, "Share Value");
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            throw new NotImplementedException();
        }
    }
}
