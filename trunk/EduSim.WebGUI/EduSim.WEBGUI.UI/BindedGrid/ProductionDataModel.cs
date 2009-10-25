using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;

namespace EduSim.WebGUI.UI.BindedGrid
{
    public class ProductionDataModel : RoundDataModel
    {
        private List<string> A = new List<string>();
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

        public override object GetList()
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
                                                   LabourCost = 0,
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
                                               };

            rs.ToList<ProductionDataView>().ForEach(o =>
                {
                    A.Add(o.ProductName);
                    C.Add(o.Inventory);
                    D.Add(o.ForecastedQuantity);
                    E.Add(o.TotalQuantity);
                    F.Add(o.ManufacturedQuantity);
                    G.Add(o.MaterialCost);
                    H.Add(o.LabourRate);
                    I.Add(o.LabourCost);
                    J.Add(o.ContributionMargin);
                    K.Add(o.SecondShift);
                    L.Add(o.OldAutomation);
                    M.Add(o.NewAutomation);
                    N.Add(o.AutomationCost );
                    O.Add(o.Capacity);
                    P.Add(o.NewCapacity);
                    Q.Add(o.NewCapacityCost);
                    R.Add(o.NumberOfLabour);
                    S.Add(o.Utilization);
                });

            return rs;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 1, 2, 3, 4, 6, 7, 8, 9, 10, 11, 13, 14, 16, 17, 18 };
        }

        public override void HandleDataChange(DataGridViewRow row, DataGridViewCell c)
        {
            throw new NotImplementedException();
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

            Edusim db = new Edusim();
            Dictionary<string, double> dic = new Dictionary<string, double>();

            LabourData ld = (from l in db.LabourData
                           where l.Round == round
                           select l).FirstOrDefault<LabourData>();

            (from c in db.ConfigurationData
             select c).ToList<ConfigurationData>().ForEach(o => dic[o.Name] = o.Value);

            int i = 0;
            double workerRequired = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                F[i] = (double)r.Cells[5].Value; //ManufacturedQuantity

                //Number of Labour: =D5/K5*$B$3
                R[i] = F[i] / L[i] * dic["LabourFactor"];
                r.Cells[17].Value = R[i].ToString("###0.00");
                workerRequired += R[i];

                i++;
            }

            Dictionary<string, double> automationCost = GetSessionData("AutomationCost");

            Dictionary<string, double> newCapacityCost = GetSessionData("NewCapacityCost");

            Dictionary<string, double> labourCost = GetSessionData("LabourCost");

            i = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                M[i] = (double)r.Cells[12].Value; //NewAutomation
                P[i] = (double)r.Cells[15].Value; //NewCapacity

                //Utilization: =$Q$10/$S$5
                S[i] = workerRequired / ld.NumberOfLabour;
                r.Cells[18].Value = S[i].ToString("###0.00");

                //Automation Cost: J[i] =(L5-K5)*$B$1
                N[i] = (M[i] - L[i]) * dic["AutomationCost"];
                r.Cells[13].Value = N[i].ToString("###0.00");
                automationCost[A[i]] = N[i];

                //Capacity Cost=L5*$B$2
                Q[i] = P[i] * dic["CapacityCost"];
                r.Cells[16].Value = Q[i].ToString("###0.00");
                newCapacityCost[A[i]] = Q[i];

                //Labour Cost=IF(R5<=100%,HR!$B$1/K5, (100%*HR!$B$1/K5+((R5-100%)*1.5*HR!$B$1/K5)))
                H[i] = (S[i] <= 1) ? (ld.Rate / L[i]) : (ld.Rate / L[i] + ((S[i]-1)* 1.5 * ld.Rate/L[i]));
                r.Cells[7].Value = H[i].ToString("###0.00");

                I[i] = F[i] * H[i];
                r.Cells[8].Value = I[i].ToString("###0.00");
                labourCost[A[i]] = I[i];

                i++;
            }
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
