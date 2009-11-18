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
    public class LabourDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, LabourDataView> dic = GetData<LabourDataView>(SessionConstant.LabourData);

            DataTable table = dic.Values.ToDataTable<LabourDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 2, 4, 6, 8 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            Dictionary<string, LabourDataView> dic = GetData<LabourDataView>(SessionConstant.LabourData);
            double numberOfLabour = dataGridView1.Rows[1].Cells[c.ColumnIndex].Value.ToDouble2();
            double annualRaise = dataGridView1.Rows[3].Cells[c.ColumnIndex].Value.ToDouble2();
            double rate = dataGridView1.Rows[5].Cells[c.ColumnIndex].Value.ToDouble2();
            double profitSharing = dataGridView1.Rows[7].Cells[c.ColumnIndex].Value.ToDouble2();
            double benefits = dataGridView1.Rows[9].Cells[c.ColumnIndex].Value.ToDouble2();
            dic[round.RoundCategory.RoundName].NumberOfLabour = numberOfLabour;
            dic[round.RoundCategory.RoundName].AnnualRaise = annualRaise;
            dic[round.RoundCategory.RoundName].Rate = rate;
            dic[round.RoundCategory.RoundName].ProfitSharing = profitSharing;
            dic[round.RoundCategory.RoundName].Benefits = benefits;
        }
    }
}
