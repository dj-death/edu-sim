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
    public class FinanceDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, FinanceData> dic = GetData<FinanceData>(SessionConstants.FinanceData);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim();

                (from f in db.FinanceData
                 where f.Round == round
                 select f).ToList<FinanceData>().ForEach(o => dic[o.Round.RoundCategory.RoundName] = o);
            }

            DataTable table = dic.Values.ToDataTable<FinanceData>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 4, 6 };
        }

        public override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c)
        {
            Dictionary<string, FinanceData> dic = GetData<FinanceData>(SessionConstants.FinanceData);
            double longTermLoan = dataGridView1.Rows[3].Cells[c.ColumnIndex].Value.ToDouble2();
            double shortTermLoan = dataGridView1.Rows[5].Cells[c.ColumnIndex].Value.ToDouble2();
            dic[round.RoundCategory.RoundName].LongTermLoan = longTermLoan;
            dic[round.RoundCategory.RoundName].ShortTermLoan = shortTermLoan;
            dic[round.RoundCategory.RoundName].Cash += (shortTermLoan + longTermLoan);
            dataGridView1.Rows[1].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].Cash;
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
