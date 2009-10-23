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
                                                   NewAutomation = p.AutomationForNextRound.HasValue ? p.AutomationForNextRound.Value : 0.0,
                                                   AutomationCost = 0.0,
                                                   Capacity = p.OldCapacity,
                                                   NewCapacity = p.NewCapacity.HasValue ? p.NewCapacity.Value : 0.0,
                                                   NewCapacityCost = 0,
                                                   NumberOfLabour = 0,
                                                   Utilization = 0,
                                               };

            rs.ToList<ProductionDataView>().ForEach(o =>
                {
                    C.Add(o.Inventory);
                    D.Add(o.ForecastedQuantity);
                    E.Add(o.TotalQuantity);
                    F.Add(o.ManufacturedQuantity);
                    G.Add(o.MaterialCost);
                    H.Add(o.LabourCost);
                    I.Add(o.ContributionMargin);
                    J.Add(o.SecondShift);
                    K.Add(o.OldAutomation);
                    L.Add(o.NewAutomation);
                    M.Add(o.AutomationCost );
                    N.Add(o.Capacity);
                    O.Add(o.NewCapacity);
                    P.Add(o.NewCapacityCost);
                    Q.Add(o.NumberOfLabour);
                    R.Add(o.Utilization);
                });

            return rs;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 1, 2, 4, 5, 6, 7, 8, 9, 10, 12, 14, 15, 16 };
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
                D[i] = (double)r.Cells[2].Value; //ManufacturedQuantity

                //Number of Labour: =D5/K5*$B$3
                Q[i] = D[i] / K[i] * dic["LabourFactor"];
                r.Cells[16].Value = Q[i].ToString("###0.00");
                workerRequired += N[i];
            }

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                L[i] = (double)r.Cells[8].Value; //NewAutomation
                O[i] = (double)r.Cells[11].Value; //NewCapacity

                //Utilization: =$Q$10/$S$5
                R[i] = workerRequired / ld.NumberOfLabour;
                r.Cells[17].Value = R[i].ToString("###0.00");

                //Automation Cost: J[i] =(L5-K5)*$B$1
                M[i] = (I[i] - H[i]) * dic["AutomationCost"];
                r.Cells[12].Value = M[i].ToString("###0.00");

                //Capacity Cost=L5*$B$2
                P[i] = O[i] * dic["CapacityCost"];
                r.Cells[15].Value = P[i].ToString("###0.00");
                
                //=IF(R5<=100%,HR!$B$1/K5, (100%*HR!$B$1/K5+((R5-100%)*1.5*HR!$B$1/K5)))
                H[i] = (R[i] <= 1) ? (ld.Rate / K[i]) : (ld.Rate / K[i] + ((R[i]-1)* 1.5 * ld.Rate/K[i]));
                r.Cells[4].Value = H[i].ToString("###0.00");

                i++;
            }

            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                //==$N$10/$P$5
                r.Cells[14].Value = workerRequired / ld.NumberOfLabour;
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
