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
    public class FinanceDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, FinanceDataView> dic = GetData <FinanceDataView>(SessionConstant.FinanceData);

            DataTable table = dic.Values.ToDataTable<FinanceDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 1, 3, 4, 6, 7 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            Dictionary<string, FinanceDataView> dic = GetData<FinanceDataView>(SessionConstant.FinanceData);
            double longTermLoan = dataGridView1.Rows[2].Cells[c.ColumnIndex].Value.ToDouble2();
            double shortTermLoan = dataGridView1.Rows[5].Cells[c.ColumnIndex].Value.ToDouble2();
            dic[round.RoundCategory.RoundName].LongTermLoan = longTermLoan;
            dic[round.RoundCategory.RoundName].ShortTermLoan = shortTermLoan;
            dic[round.RoundCategory.RoundName].CurrentTotalLongTermLoan = dic[round.RoundCategory.RoundName].TotalLongTermLoan + longTermLoan;
            dic[round.RoundCategory.RoundName].CurrentTotalShortTermLoan = dic[round.RoundCategory.RoundName].TotalShortTermLoan + shortTermLoan;

            dic[round.RoundCategory.RoundName].Cash = dic[round.RoundCategory.RoundName].PreviousCash +
                longTermLoan + shortTermLoan;

            dataGridView1.Rows[1].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].CurrentTotalLongTermLoan;
            dataGridView1.Rows[4].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].CurrentTotalShortTermLoan;
            dataGridView1.Rows[7].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].Cash;
        }
    }
}
