using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EduSim.CoreFramework.Common;
using EduSim.CoreFramework.DTO;
using Gizmox.WebGUI.Forms;

namespace EduSim.WebGUI.UI.BindedGrid
{
    public class MarketingDataModel : RoundDataModel
    {
        private List<string> A = new List<string>();
        private List<double> D = new List<double>();
        private List<double> F = new List<double>();
        private List<double> H = new List<double>();

        public override object GetList()
        {
            Edusim db = new Edusim();
            IQueryable < MarketingDataView> r = from m in db.MarketingData
                       join rp in db.RoundProduct on m.RoundProduct equals rp
                       join rd in db.Round on rp.Round equals rd
                       join t in db.TeamGame on rd.TeamGame equals t
                       join tu in db.TeamUser on t.TeamId equals tu.Id
                       where rd.Id == round.Id && tu.UserDetails == user
                       select new MarketingDataView()
                       {
                           ProductName = rp.ProductName,
                           ProductCategory = rp.SegmentType.Description,
                           PreviousUnitPrice = m.PreviousPrice,
                           UnitPrice = m.Price.HasValue ? m.Price.Value : m.PreviousPrice,
                           PreviousSalesExpense = m.PreviousSaleExpense,
                           SalesExpense = m.SalesExpense.HasValue ? m.SalesExpense.Value : m.PreviousSaleExpense,
                           PreviousMarketingExpense = m.PreviousMarketingExpense,
                           MarketingExpense = m.MarketingExpense.HasValue ? m.MarketingExpense.Value : m.PreviousMarketingExpense,
                           PreviousForecastingQuantity = m.PreviousForecastingQuantity,
                           ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : m.PreviousForecastingQuantity,
                           ProjectedSales = (m.Price.HasValue ? m.Price.Value : m.PreviousPrice) * (m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : m.PreviousForecastingQuantity)
                       };

            r.ToList<MarketingDataView>().ForEach(o =>
            {
                A.Add(o.ProductName);
            });

            return r;
        }

        public override int[] HiddenColumns()
        {
            return new int[]  { 0, 1, 2, 4, 6, 8, 10 };
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

            Dictionary<string, double> salesExpense = GetSessionData("SalesExpense");

            Dictionary<string, double> marketingExpense = GetSessionData("MarketingExpense");

            Dictionary<string, double> revenue = GetSessionData("Revenue");

            int i = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                double unitCost = (double)r.Cells[3].Value; 
                double forcastQty = (double)r.Cells[9].Value;

                salesExpense[A[i]] = (double)r.Cells[5].Value;
                marketingExpense[A[i]] = (double)r.Cells[7].Value;

                r.Cells[10].Value = unitCost * forcastQty;
                revenue[A[i]] = (double)r.Cells[10].Value;

                i++;
            }
        }

        public override void Save(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }
    }
}
