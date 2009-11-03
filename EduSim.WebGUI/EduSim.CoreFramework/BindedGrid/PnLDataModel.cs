using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;
using System.Reflection;

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

            dataGridView1.Columns.Add("Description", "Description");
            foreach (string col in rndData.Keys)
            {
                dataGridView1.Columns.Add(col, col);
            }

            AddRow<MarketingDataView>(marketingData, rndData.Keys, dataGridView1, "ProjectedSales");
            AddRow<ProductionDataView>(productionData, rndData.Keys, dataGridView1, "LabourCost");
            AddRow<ProductionDataView>(productionData, rndData.Keys, dataGridView1, "AutomationCost");
            AddRow<ProductionDataView>(productionData, rndData.Keys, dataGridView1, "NewCapacityCost");
            AddRow<RnDDataView>(rndData, rndData.Keys, dataGridView1, "RnDCost");
            AddRow<MarketingDataView>(marketingData, rndData.Keys, dataGridView1, "SalesExpense");
            AddRow<MarketingDataView>(marketingData, rndData.Keys, dataGridView1, "MarketingExpense");
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

                    t1.Value = prop.GetValue(dat, null);
                }
                else
                {
                    t1.Value = 0.0;
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
