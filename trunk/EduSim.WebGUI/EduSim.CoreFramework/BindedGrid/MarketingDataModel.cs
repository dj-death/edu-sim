using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;
using EduSim.CoreUtilities.Utility;
using System.Data;

namespace EduSim.WebGUI.UI.BindedGrid
{
    public class MarketingDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, MarketingDataView> dic = GetData<MarketingDataView>("MarketingData");

            if (dic.Count == 0)
            {
                Edusim db = new Edusim();
                (from m in db.MarketingData
                 join rp in db.RoundProduct on m.RoundProduct equals rp
                 join rd in db.Round on rp.Round equals rd
                 join t in db.TeamGame on rd.TeamGame equals t
                 join tu in db.TeamUser on t.TeamId equals tu.Id
                 where rd.Id == round.Id && tu.UserDetails == user
                 select new MarketingDataView()
                 {
                     ProductName = rp.ProductName,
                     ProductCategory = rp.SegmentType.Description,
                     PreviousUnitPrice = m.PreviousPrice,
                     UnitPrice = m.Price.HasValue ? m.Price.Value : 0.0,
                     PreviousSalesExpense = m.PreviousSaleExpense,
                     SalesExpense = m.SalesExpense.HasValue ? m.SalesExpense.Value : 0.0,
                     PreviousMarketingExpense = m.PreviousMarketingExpense,
                     MarketingExpense = m.MarketingExpense.HasValue ? m.MarketingExpense.Value : 0.0,
                     PreviousForecastingQuantity = m.PreviousForecastingQuantity,
                     ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0,
                     ProjectedSales = 0.0
                 }).ToList<MarketingDataView>().ForEach(o => dic[o.ProductName] = o);
            }

            DataTable table = dic.Values.ToDataTable<MarketingDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 3, 5, 7, 9 };
        }

        public override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c)
        {
            int colIndex = c.ColumnIndex - 1;
            double unitCost = dataGridView1.Rows[2].Cells[colIndex].Value.ToDouble2();
            double salesExpense = dataGridView1.Rows[4].Cells[colIndex].Value.ToDouble2();
            double marketingExpense = dataGridView1.Rows[6].Cells[colIndex].Value.ToDouble2();
            double forcastQty = dataGridView1.Rows[8].Cells[colIndex].Value.ToDouble2();
            //M[i] = (double)r.Cells[12].Value;//RnDCost

            //(H2-G2)*$B$9+ (J2-I2)*$B$10 + (K2-L2)*$B$11
            dataGridView1.Rows[9].Cells[colIndex].Value = unitCost * forcastQty;

            Dictionary<string, MarketingDataView> dic = GetData<MarketingDataView>(SessionConstants.MarketingData);
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].UnitPrice = unitCost;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].ForecastedQuantity = forcastQty;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].ProjectedSales = unitCost * forcastQty;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].SalesExpense = salesExpense;
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].MarketingExpense = marketingExpense;
        }

        public override void ComputeAllCells(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }

        public override void Save(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }
    }
}
