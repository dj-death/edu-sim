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
            Dictionary<string, FinanceDataView> dic = GetData <FinanceDataView>(SessionConstants.FinanceData);

            DataTable table = dic.Values.ToDataTable<FinanceDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 2, 4, 5 };
        }

        public override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            base.HandleDataChange(dataGridView1, row, c, oldValue);

            Dictionary<string, FinanceDataView> dic = GetData<FinanceDataView>(SessionConstants.FinanceData);
            double longTermLoan = dataGridView1.Rows[1].Cells[c.ColumnIndex].Value.ToDouble2();
            double shortTermLoan = dataGridView1.Rows[3].Cells[c.ColumnIndex].Value.ToDouble2();
            dic[round.RoundCategory.RoundName].LongTermLoan = longTermLoan;
            dic[round.RoundCategory.RoundName].ShortTermLoan = shortTermLoan;
            dic[round.RoundCategory.RoundName].Cash = (dic[round.RoundCategory.RoundName].OriganalCash + 
                longTermLoan + shortTermLoan);

            dataGridView1.Rows[5].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].Cash;
        }

        public override void Save(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }
    }
}
