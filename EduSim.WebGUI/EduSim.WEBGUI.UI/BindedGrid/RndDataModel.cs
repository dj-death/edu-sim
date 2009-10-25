using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;

namespace EduSim.WebGUI.UI.BindedGrid
{
    public class RnDDataModel : RoundDataModel
    {
        private List<string> A = new List<string>();
        private List<DateTime> C = new List<DateTime>();
        private List<DateTime> D = new List<DateTime>();
        private List<double> E = new List<double>();
        private List<double> F = new List<double>();
        private List<double> G = new List<double>();
        private List<double> H = new List<double>();
        private List<double> I = new List<double>();
        private List<double> J = new List<double>();
        private List<double> K = new List<double>();
        private List<double> L = new List<double>();
        private List<double> M = new List<double>();

        public override void GetList(DataGridView dataGridView1)
        {
            Edusim db = new Edusim();
            IQueryable<RnDDataView> rs = from r in db.RnDData
                   join rp in db.RoundProduct on r.RoundProduct equals rp
                   join rd in db.Round on rp.Round equals rd
                   join t in db.TeamGame on rd.TeamGame equals t
                   join tu in db.TeamUser on t.TeamId equals tu.Id
                   where rd.Id == round.Id && tu.UserDetails == user
                   select new RnDDataView()
                    {
                        ProductName = rp.ProductName,
                        ProductCategory = rp.SegmentType.Description,
                        PreviousRevisionDate = r.PreviousRevisionDate,
                        RevisionDate = r.PreviousRevisionDate,
                        PreviousAge = r.PreviousAge,
                        Age = r.PreviousAge,
                        PreviousReliability = r.PreviousReliability,
                        Reliability = r.PreviousReliability,
                        PreviousPerformance = r.PreviousPerformance,
                        Performance = r.PreviousPerformance,
                        PreviousSize = r.PreviousSize,
                        Size = r.PreviousSize,
                        RnDCost = 0.0
                    };

            rs.ToList<RnDDataView>().ForEach(o =>
                {
                    A.Add(o.ProductName);
                    C.Add(o.PreviousRevisionDate);
                    D.Add(o.RevisionDate);
                    E.Add(o.PreviousAge);
                    F.Add(o.Age);
                    G.Add(o.PreviousReliability);
                    H.Add(o.Reliability);
                    I.Add(o.PreviousPerformance);
                    J.Add(o.Performance);
                    K.Add(o.PreviousSize);
                    L.Add(o.Size);
                    M.Add(o.RnDCost);
                });

            dataGridView1.DataSource = rs;
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 3, 4, 5, 6, 8, 10, 12 };
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

            List<string> products = new List<string>();
            HttpContext.Current.Session["Products"] = products;

            Dictionary<string, double> rndCost = GetSessionData("RnDCost");

            int i = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                H[i] = (double)r.Cells[7].Value; //Reliability
                J[i] = (double)r.Cells[9].Value; //Performance
                L[i] = (double)r.Cells[11].Value; //Size

                //RnD Cost: (H2-G2)*$B$9+ (J2-I2)*$B$10 + (K2-L2)*$B$11
                M[i] = (H[i] - G[i]) * dic["ReliabilityCost"] + (J[i] - I[i]) * dic["PerformanceCost"] +
                    (K[i] - L[i]) * dic["SizeCost"];

                r.Cells[12].Value = M[i].ToString("###0.00");

                products.Add(A[i]);
                rndCost[A[i]] = M[i];

                //Age: =IF(M2=0, E2, (E2+((H2-G2)*$B$14+(J2-I2)*$B$13+(K2-L2)*$B$12)/365)/2)
                double val = (M[i] == 0.0) ? E[i] : (E[i] + ((H[i] - G[i]) * dic["ReliabilityFactor"] +
                    (J[i] - I[i]) * dic["PerformanceFactor"] + (K[i] - L[i]) * dic["SizeFactor"]) / 365) / 2;

                r.Cells[5].Value = val.ToString("###0.0");

                //RevisionDate: =C2+(H2-G2)*$B$14+(J2-I2)*$B$13+(K2-L2)*$B$12
                r.Cells[3].Value = C[i].AddDays((H[i] - G[i]) * dic["ReliabilityFactor"] +
                    (J[i] - I[i]) * dic["PerformanceFactor"] + (K[i] - L[i]) * dic["SizeFactor"]);

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
