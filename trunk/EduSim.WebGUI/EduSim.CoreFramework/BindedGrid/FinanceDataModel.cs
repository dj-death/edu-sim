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
            Dictionary<string, FinanceDataView> dic = GetData <FinanceDataView>(SessionConstant.FinanceData, round.Id);
            Dictionary<string, ProductionDataView> dic1 = GetData <ProductionDataView>(SessionConstant.ProductionData, round.Id);

            double investmentsInPlantAndMachinary = 0;
            foreach (string product in dic1.Keys)
            {
                investmentsInPlantAndMachinary += dic1[product].NewCapacityCost;
                investmentsInPlantAndMachinary += dic1[product].AutomationCost;
            }

            dic[round.RoundCategory.RoundName].InvestmentsInPlantAndMachinary = investmentsInPlantAndMachinary;
            double longTermLoan = dic[round.RoundCategory.RoundName].LongTermLoan;
            double shortTermLoan = dic[round.RoundCategory.RoundName].ShortTermLoan;
            dic[round.RoundCategory.RoundName].Cash = dic[round.RoundCategory.RoundName].PreviousCash +
                longTermLoan + shortTermLoan - investmentsInPlantAndMachinary;

            DataTable table = dic.Values.ToDataTable<FinanceDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 1, 2, 4, 5, 7, 8 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            Dictionary<string, FinanceDataView> dic = GetData<FinanceDataView>(SessionConstant.FinanceData, round.Id);
            double longTermLoan = dataGridView1.Rows[3].Cells[c.ColumnIndex].Value.ToDouble2();
            double shortTermLoan = dataGridView1.Rows[6].Cells[c.ColumnIndex].Value.ToDouble2();
            dic[round.RoundCategory.RoundName].Cash = dic[round.RoundCategory.RoundName].PreviousCash +
                longTermLoan + shortTermLoan - dic[round.RoundCategory.RoundName].InvestmentsInPlantAndMachinary;

            dic[round.RoundCategory.RoundName].LongTermLoan = longTermLoan;
            dic[round.RoundCategory.RoundName].ShortTermLoan = shortTermLoan;
            dic[round.RoundCategory.RoundName].CurrentTotalLongTermLoan = dic[round.RoundCategory.RoundName].TotalLongTermLoan + longTermLoan;
            dic[round.RoundCategory.RoundName].CurrentTotalShortTermLoan = dic[round.RoundCategory.RoundName].TotalShortTermLoan + shortTermLoan;

            dataGridView1.Rows[1].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].CurrentTotalLongTermLoan;
            dataGridView1.Rows[4].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].CurrentTotalShortTermLoan;
            dataGridView1.Rows[7].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].Cash;
        }
    }
}
