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
    public class ProductionDataModel : RoundDataModel
    {
        private List<double> C = new List<double>();
        private List<double> D = new List<double>();
        private List<double> E = new List<double>();
        private List<double> F = new List<double>();
        private List<double> G = new List<double>();
        private List<double> H = new List<double>();
        private List<double> I = new List<double>();
        private List<double> J = new List<double>();
        private List<double> K = new List<double>();
        private List<double> L = new List<double>();
        private List<double> M = new List<double>();
        private List<double> N = new List<double>();
        private List<double> O = new List<double>();
        private List<double> P = new List<double>();
        private List<double> Q = new List<double>();
        private List<double> R = new List<double>();
        private List<double> S = new List<double>();
        private List<double> T = new List<double>();

        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, ProductionDataView> dic = RoundDataModel.GetData<ProductionDataView>(SessionConstant.ProductionData, round.Id);
            Dictionary<string, MarketingDataView> dic1 = RoundDataModel.GetData<MarketingDataView>(SessionConstant.MarketingData, round.Id);

            dic.Values.ToList<ProductionDataView>().ForEach(o =>
            {
                o.ForecastedQuantity = dic1[o.ProductName].ForecastedQuantity;
                T.Add(dic1[o.ProductName].UnitPrice);
            });
            SetMaterialCost(dic);


            dic.Values.ToList<ProductionDataView>().ForEach(o =>
            {
                
                C.Add(o.Inventory);
                D.Add(o.ForecastedQuantity);
                E.Add(o.TotalQuantity);
                F.Add(o.ManufacturedQuantity);
                G.Add(o.MaterialCost);
                H.Add(o.LabourRate);
                I.Add(o.ContributionMargin);
                J.Add(o.SecondShift);
                K.Add(o.OldAutomation);
                L.Add(o.NewAutomation);
                M.Add(o.AutomationCost);
                N.Add(o.Capacity);
                O.Add(o.NewCapacity);
                P.Add(o.NewCapacityCost);
                Q.Add(o.NumberOfLabour);
                R.Add(o.Utilization);
                S.Add(o.LabourCost);
            });

            SetAllRows(dic);
            DataTable table = dic.Values.ToDataTable<ProductionDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        private void SetMaterialCost(Dictionary<string, ProductionDataView> dic)
        {
            Dictionary<string, RnDDataView> dic1 = RoundDataModel.GetData<RnDDataView>(SessionConstant.RnDData, round.Id);

            foreach (string key in dic.Keys)
            {
                dic[key].MaterialCost = dic[key].ForecastedQuantity * (dic1[key].Reliability * configurationInfo["ReliabilityMaterialCostFactor"]
                    + (dic1[key].Performance + (17-dic1[key].Size))  *  configurationInfo["AgeMaterialCostFactor"]);
            }
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10, 12, 13, 15, 16, 17 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            Dictionary<string, ProductionDataView> dic = RoundDataModel.GetData<ProductionDataView>(SessionConstant.ProductionData, round.Id);
            SetAllRows(dic);

            int i = c.ColumnIndex - 1;

            dataGridView1.Rows[16].Cells[c.ColumnIndex].Value = Q[i].ToString("###0.00");

            dataGridView1.Rows[17].Cells[c.ColumnIndex].Value = R[i].ToString("###0.00");

            dataGridView1.Rows[12].Cells[c.ColumnIndex].Value = M[i].ToString("###0.00");

            dataGridView1.Rows[15].Cells[c.ColumnIndex].Value = P[i].ToString("###0.00");

            dataGridView1.Rows[6].Cells[c.ColumnIndex].Value = H[i].ToString("###0.00");

            dataGridView1.Rows[7].Cells[c.ColumnIndex].Value = S[i].ToString("###0.00");

            double contributionMargin = (G[i] + S[i]) / (T[i] * F[i]);
            dataGridView1.Rows[8].Cells[c.ColumnIndex].Value = (contributionMargin).ToString("###0.00");
        }

        internal void SetAllRows(Dictionary<string, ProductionDataView> dic)
        {
            Edusim db = new Edusim(Constants.ConnectionString);

            Dictionary<string, LabourDataView> dic1 = GetData<LabourDataView>(SessionConstant.LabourData, round.Id);
            LabourDataView ld = dic1.Values.FirstOrDefault<LabourDataView>();

            int i = 0;
            double workerRequired = 0;

            foreach (string key in dic.Keys)
            {
                //Number of Labour: =D5/K5*$B$3
                Q[i] = F[i] / K[i] * configurationInfo["LabourFactor"];

                //Automation Cost: J[i] =(L5-K5)*$B$1
                M[i] = GetCost(L[i], K[i], configurationInfo["AutomationCost"]);

                //with negative value like Capacity sold is at depreciated value
                //Capacity Cost=L5*$B$2
                P[i] = O[i] > 0 ? O[i] * configurationInfo["CapacityCost"] : O[i] * configurationInfo["CapacityCost"] / 2;

                double rate = ld.Rate;
                //Labour Cost =IF(R5<=100%,HR!$B$1/K5, (100%*HR!$B$1/K5+((R5-100%)*1.5*HR!$B$1/K5)))
                H[i] = (R[i] <= 1) ? (rate / K[i]) : (rate / K[i] + ((R[i] - 1) * 1.5 * rate / K[i]));

                S[i] = H[i] * F[i];

                double contributionMargin = (G[i] + S[i]) / (T[i] * F[i]);

                dic[key].ManufacturedQuantity = F[i];
                dic[key].NewAutomation = L[i];
                dic[key].NewCapacity = O[i];
                dic[key].Utilization = R[i];
                dic[key].AutomationCost = M[i];
                dic[key].NewCapacityCost = P[i];
                dic[key].LabourRate = H[i];
                dic[key].LabourCost = S[i];
                dic[key].NumberOfLabour = Q[i];
                dic[key].ContributionMargin = contributionMargin;

                workerRequired += Q[i];
                i++;
            }

            //Utilization: =$Q$10/$S$5
            double numberOfLabour = ld.NumberOfLabour;

            i = 0;
            foreach (string key in dic.Keys)
            {
                R[i] = workerRequired / numberOfLabour;
                i++;
            }
        }

        public override void AddProduct(DataGridView dataGridView1)
        {
            base.AddProduct(dataGridView1);
        }
    }
}
