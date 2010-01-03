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
        private double investmentsInPlantAndMachinary = 0;

        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, ProductionDataView> productionData = GetData<ProductionDataView>(SessionConstant.ProductionData, round.Id);

            foreach (string product in productionData.Keys)
            {
                investmentsInPlantAndMachinary += productionData[product].NewCapacityCost;
                investmentsInPlantAndMachinary += productionData[product].AutomationCost;
            }

            Dictionary<string, FinanceDataView> dic = GetData<FinanceDataView>(SessionConstant.FinanceData, round.Id);
            dic[round.RoundCategory.RoundName].InvestmentsInPlantAndMachinary = investmentsInPlantAndMachinary;
            SetCash(dic);

            DataTable table = dic.Values.ToDataTable<FinanceDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        private void SetCash(Dictionary<string, FinanceDataView> dic)
        {
            double longTermLoan = dic[round.RoundCategory.RoundName].LongTermLoan;
            double shortTermLoan = dic[round.RoundCategory.RoundName].ShortTermLoan;
            PnLDataModel model = new PnLDataModel();
            model.GetList(new DataGridView());

            //Cash is PreviousCash + LongTermLoan + ShorttermLoan + ForecastedSales + StockSell - StockRetire - DividantPaid
            dic[round.RoundCategory.RoundName].Cash = dic[round.RoundCategory.RoundName].PreviousCash +
                model.data[model.netProfitIndex] +
                longTermLoan + shortTermLoan - investmentsInPlantAndMachinary +
                dic[round.RoundCategory.RoundName].StockSell - dic[round.RoundCategory.RoundName].StockBuy - dic[round.RoundCategory.RoundName].DividandPaid;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 6, 7 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            Dictionary<string, FinanceDataView> dic = GetData<FinanceDataView>(SessionConstant.FinanceData, round.Id);
            double longTermLoan = dataGridView1.Rows[3].Cells[c.ColumnIndex].Value.ToDouble2();
            double shortTermLoan = dataGridView1.Rows[6].Cells[c.ColumnIndex].Value.ToDouble2();
            dic[round.RoundCategory.RoundName].LongTermLoan = longTermLoan;
            dic[round.RoundCategory.RoundName].ShortTermLoan = shortTermLoan;
            SetCash(dic);

            dataGridView1.Rows[8].Cells[c.ColumnIndex].Value = dic[round.RoundCategory.RoundName].Cash.ToString("$###0.00");
        }
    }
}
