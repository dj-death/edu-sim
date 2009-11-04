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

        public override void GetList(DataGridView dataGridView1)
        {
            Dictionary<string, ProductionDataView> dic = GetData<ProductionDataView>(SessionConstants.ProductionData);

            if (dic.Count == 0)
            {
                Edusim db = new Edusim();
                IQueryable<ProductionDataView> rs = from p in db.ProductionData
                                                    join rp in db.RoundProduct on p.RoundProduct equals rp
                                                    join rd in db.Round on rp.Round equals rd
                                                    join t in db.TeamGame on rd.TeamGame equals t
                                                    join tu in db.TeamUser on t.TeamId equals tu.Id
                                                    join m in db.MarketingData on p.RoundProduct equals m.RoundProduct
                                                    where rd.Id == round.Id && tu.UserDetails == user
                                                    select new ProductionDataView()
                                                   {
                                                       ProductName = rp.ProductName,
                                                       ProductCategory = rp.SegmentType.Description,
                                                       Inventory = p.Inventory,
                                                       ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0,
                                                       TotalQuantity = p.Inventory + (m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0),
                                                       ManufacturedQuantity = p.ManufacturedQuantity,
                                                       MaterialCost = 0,
                                                       LabourRate = 0,
                                                       ContributionMargin = p.Contribution.HasValue ? p.Contribution.Value : 0.0,
                                                       SecondShift = 0.0,
                                                       OldAutomation = p.CurrentAutomation,
                                                       NewAutomation = p.AutomationForNextRound.HasValue ? p.AutomationForNextRound.Value : p.CurrentAutomation,
                                                       AutomationCost = 0.0,
                                                       Capacity = p.OldCapacity,
                                                       NewCapacity = p.NewCapacity.HasValue ? p.NewCapacity.Value : 0.0,
                                                       NewCapacityCost = 0,
                                                       NumberOfLabour = 0,
                                                       Utilization = 0,
                                                       LabourCost = 0,
                                                   };

                rs.ToList<ProductionDataView>().ForEach(o =>
                    {
                        dic[o.ProductName] = o;
                    });
            }

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

            DataTable table = dic.Values.ToDataTable<ProductionDataView>(null).Transpose();

            dataGridView1.DataSource = table;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 1, 2, 3, 5, 6, 7, 8, 9, 10, 12, 13, 15, 16, 17 };
        }

        public override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c)
        {
            Edusim db = new Edusim();

            LabourData ld = (from l in db.LabourData
                             where l.Round == round
                             select l).FirstOrDefault<LabourData>();

            double workerRequired = 0;
            int i = c.ColumnIndex - 1;

            //ManufacturedQuantity
            F[i] = dataGridView1.Rows[4].Cells[c.ColumnIndex].Value.ToDouble2(); 

            //Number of Labour: =D5/K5*$B$3
            Q[i] = F[i] / K[i] * configurationInfo["LabourFactor"];
            dataGridView1.Rows[16].Cells[c.ColumnIndex].Value = Q[i].ToString("###0.00");
            for (int j = 0; j < row.Cells.Count-1; j++)
            {
                workerRequired += Q[j];
            }

            //NewAutomation
            L[i] = dataGridView1.Rows[11].Cells[c.ColumnIndex].Value.ToDouble2();
            //NewCapacity
            O[i] = dataGridView1.Rows[14].Cells[c.ColumnIndex].Value.ToDouble2(); 

            //Utilization: =$Q$10/$S$5
            //TODO: We need to get the labour list
            R[i] = workerRequired / ld.NumberOfLabour;
            dataGridView1.Rows[17].Cells[c.ColumnIndex].Value = R[i].ToString("###0.00");

            //Automation Cost: J[i] =(L5-K5)*$B$1
            M[i] = (L[i] - K[i]) * configurationInfo["AutomationCost"];
            dataGridView1.Rows[12].Cells[c.ColumnIndex].Value = M[i].ToString("###0.00");

            //Capacity Cost=L5*$B$2
            P[i] = O[i] * configurationInfo["CapacityCost"];
            dataGridView1.Rows[15].Cells[c.ColumnIndex].Value = P[i].ToString("###0.00");

            //Labour Cost =IF(R5<=100%,HR!$B$1/K5, (100%*HR!$B$1/K5+((R5-100%)*1.5*HR!$B$1/K5)))
            H[i] = (R[i] <= 1) ? (ld.Rate / K[i]) : (ld.Rate / K[i] + ((R[i] - 1) * 1.5 * ld.Rate / K[i]));
            dataGridView1.Rows[6].Cells[c.ColumnIndex].Value = H[i].ToString("###0.00");
            S[i] = H[i] * F[i];
            dataGridView1.Rows[7].Cells[c.ColumnIndex].Value = S[i].ToString("###0.00");

            Dictionary<string, ProductionDataView> dic = GetData<ProductionDataView>(SessionConstants.ProductionData);

            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].ManufacturedQuantity = F[i];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].NewAutomation = L[i];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].NewCapacity = O[i];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].Utilization = R[i];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].AutomationCost = M[i];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].NewCapacityCost = P[i];
            dic[dataGridView1.Columns[c.ColumnIndex].HeaderText].LabourCost = S[i];
        }

        public override void ComputeAllCells(DataGridView dataGridView1)
        {
            #region Configuration Info
            //ReliabilityCost
            //PerformanceCost
            //SizeCost
            //ReliabilityFactor
            //PerformanceFactor
            //SizeFactor
            //AutomationCost
            //CapacityCost
            //LabourFactor
            //TaxRate
            //LongTermInterestRate
            //ShortTermInterestRate
            #endregion 

        }

        public override void Save(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }

        public override void AddProduct(DataGridView dataGridView1)
        {
            base.AddProduct(dataGridView1);
        }
    }
}
