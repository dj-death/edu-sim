using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;
using EduSim.CoreUtilities.Utility;
using System.Data;

namespace EduSim.CoreFramework.DataControls
{
    public class MarketingDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, MarketingDataView> dic = GetData<MarketingDataView>(SessionConstant.MarketingData);
            DataTable table = dic.Values.ToDataTable<MarketingDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 3, 5, 7, 9 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            int colIndex = c.ColumnIndex;
            double unitCost = dataGridView1.Rows[2].Cells[colIndex].Value.ToDouble2();
            double salesExpense = dataGridView1.Rows[4].Cells[colIndex].Value.ToDouble2();
            double marketingExpense = dataGridView1.Rows[6].Cells[colIndex].Value.ToDouble2();
            double forcastQty = dataGridView1.Rows[8].Cells[colIndex].Value.ToDouble2();
            //M[i] = (double)r.Cells[12].Value;//RnDCost

            //(H2-G2)*$B$9+ (J2-I2)*$B$10 + (K2-L2)*$B$11
            dataGridView1.Rows[9].Cells[colIndex].Value = unitCost * forcastQty;

            Dictionary<string, MarketingDataView> dic = GetData<MarketingDataView>(SessionConstant.MarketingData);
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].UnitPrice = unitCost;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].ForecastedQuantity = forcastQty;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].ProjectedSales = unitCost * forcastQty;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].SalesExpense = salesExpense;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].MarketingExpense = marketingExpense;
        }
    }
}
