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
                                                   SecondShift = 0,
                                                   OldAutomation = p.CurrentAutomation,
                                                   NewAutomation = p.AutomationForNextRound.HasValue ? p.AutomationForNextRound.Value : 0.0,
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
                    M.Add(o.Capacity);
                    N.Add(o.NewCapacity);
                    O.Add(o.NewCapacityCost);
                    P.Add(o.NumberOfLabour);
                    Q.Add(o.Utilization);
                });

            return rs;
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 3, 4, 5, 6, 7, 9, 10, 12, 13, 14, 15};
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

            (from c in db.ConfigurationData
             select c).ToList<ConfigurationData>().ForEach(o => dic[o.Name] = o.Value);

            int i = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                C[i] = (double)r.Cells[2].Value; //ManufacturedQuantity
                I[i] = (double)r.Cells[8].Value; //NewAutomation
                K[i] = (double)r.Cells[11].Value; //NewCapacity
                //M[i] = (double)r.Cells[12].Value;//RnDCost

                ////(H2-G2)*$B$9+ (J2-I2)*$B$10 + (K2-L2)*$B$11
                //r.Cells[12].Value = M[i] = (H[i] - G[i]) * dic["ReliabilityCost"] + (J[i] - I[i]) * dic["PerformanceCost"] + 
                //    (K[i] - L[i]) * dic["SizeCost"];

                ////Age=IF(M2=0, E2, (E2+((H2-G2)*$B$14+(J2-I2)*$B$13+(K2-L2)*$B$12)/365)/2)
                //r.Cells[5].Value = M[i] == 0.0 ? E[i] : (E[i] + ((H[i] - G[i]) * dic["ReliabilityFactor"] +
                //    (J[i] - I[i]) * dic["PerformanceFactor"] + (K[i] - L[i]) * dic["SizeFactor"]) / 365) / 2;

                ////RevisionDate=C2+(H2-G2)*$B$14+(J2-I2)*$B$13+(K2-L2)*$B$12
                //r.Cells[3].Value = C[i].AddDays((H[i] - G[i]) * dic["ReliabilityFactor"] +
                //    (J[i] - I[i]) * dic["PerformanceFactor"] + (K[i] - L[i]) * dic["SizeFactor"]);

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
