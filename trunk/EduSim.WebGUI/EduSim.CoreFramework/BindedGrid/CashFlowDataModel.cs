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

    public class CashFlowDataModel : RoundDataModel
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

            //TODO: we need to implement Cashflow logics
            AddRowForHeader(dataGridView1, "Cash flow from operations");
            AddRowForColumnDefault(dataGridView1, "Net Income");
            AddRowForColumnDefault(dataGridView1, "Depreciation and writeoffs");
            AddRowForColumnDefault(dataGridView1, "Change in accounts payable");
            AddRowForColumnDefault(dataGridView1, "Change in inventory");
            AddRowForColumnDefault(dataGridView1, "Change in account receiable");
            
            AddRowForHeader(dataGridView1, "Cash flow from investing");
            AddRowForColumnDefault(dataGridView1, "Plant improvements");

            AddRowForHeader(dataGridView1, "Cash flow from financial actions");
            AddRowForColumnDefault(dataGridView1, "Divedant paid");
            AddRowForColumnDefault(dataGridView1, "Sales of common stock");
            AddRowForColumnDefault(dataGridView1, "Increase long term debt");
            AddRowForColumnDefault(dataGridView1, "Retire long term dept");
            AddRowForColumnDefault(dataGridView1, "Change in current debt (net)");
            AddRowForColumnDefault(dataGridView1, "Net cash from financial actions");
            
            AddRowForHeader(dataGridView1, "Net change in cash position");
            AddRowForColumnDefault(dataGridView1, "Starting cash position");
            AddRowForHeader(dataGridView1, "Closing cash postion");
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            throw new NotImplementedException();
        }
    }
}
