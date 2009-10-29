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
        public override void GetList(DataGridView dataGridView1)
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
                           UnitPrice = m.Price.HasValue ? m.Price.Value : 0.0,
                           PreviousSalesExpense = m.PreviousSaleExpense,
                           SalesExpense = m.SalesExpense.HasValue ? m.SalesExpense.Value : 0.0,
                           PreviousMarketingExpense = m.PreviousMarketingExpense,
                           MarketingExpense = m.MarketingExpense.HasValue ? m.MarketingExpense.Value : 0.0,
                           PreviousForecastingQuantity = m.PreviousForecastingQuantity,
                           ForecastedQuantity = m.ForecastingQuantity.HasValue ? m.ForecastingQuantity.Value : 0.0,
                           ProjectedSales = 0.0
                       };


            //return r;
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

            int i = 0;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                double unitCost = (double)r.Cells[3].Value; 
                double forcastQty = (double)r.Cells[9].Value; 
                //M[i] = (double)r.Cells[12].Value;//RnDCost

                //(H2-G2)*$B$9+ (J2-I2)*$B$10 + (K2-L2)*$B$11
                r.Cells[10].Value = unitCost * forcastQty;

                i++;
            }
        }

        public override void Save(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }
    }
}
