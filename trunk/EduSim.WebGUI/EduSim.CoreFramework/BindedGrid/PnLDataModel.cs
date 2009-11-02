using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;

namespace EduSim.WebGUI.UI.BindedGrid
{
    // Sales Revenue, Labor Cost, Material Cost, Automation Cost, Plant Cost, R&D Cost, S&M Cost, Depreciation, S&M, EBIT, Contribution Margin, Tax, Interest, Profit Sharing. Net Profit

    public class PnLDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            List<string> products = (List<string>)HttpContext.Current.Session["Products"];

            dataGridView1.Columns.Add("Description", "Description");
            foreach(string col in products)
            {
                dataGridView1.Columns.Add(col, col);
            }

            AddRow((Dictionary<string, double>)HttpContext.Current.Session["Revenue"], products, dataGridView1, "Sales Revenue");
            AddRow((Dictionary<string, double>)HttpContext.Current.Session["LabourCost"], products, dataGridView1, "Labour Cost");
            AddRow((Dictionary<string, double>)HttpContext.Current.Session["AutomationCost"], products, dataGridView1, "Automation Cost");
            AddRow((Dictionary<string, double>)HttpContext.Current.Session["NewCapacityCost"], products, dataGridView1, "Plant Cost");
            AddRow((Dictionary<string, double>)HttpContext.Current.Session["RnDCost"], products, dataGridView1, "R&D Cost");
            AddRow((Dictionary<string, double>)HttpContext.Current.Session["SalesAndMarketingExpense"], products, dataGridView1, "S&M Cost");
        }

        private void AddRow(Dictionary<string, double> rndData, List<string> products, DataGridView dataGridView1, string p)
        {
            DataGridViewRow r = new DataGridViewRow();

            DataGridViewCell t = new DataGridViewTextBoxCell();
            t.Value = p;
            r.Cells.Add(t);

            foreach(string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();
                t1.Value = rndData[str];
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 3, 4, 5 };
        }

        public override void HandleDataChange(DataGridViewRow row, DataGridViewCell c)
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
