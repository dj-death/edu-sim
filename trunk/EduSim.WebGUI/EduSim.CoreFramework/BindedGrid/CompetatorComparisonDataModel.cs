using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduSim.CoreFramework.Common;
using Gizmox.WebGUI.Forms;
using EduSim.CoreFramework.DTO;
using EduSim.CoreUtilities.Utility;
using System.Data;

namespace EduSim.CoreFramework.DataControls
{
    public class ComparisonInformation
    {
        public string ProductName { get; set; }
        public int SegmentTypeId { get; set; }
        public string SegmentTypeDescription { get; set; }
        public double PurchasedQuantity { get; set; }
        public double Price { get; set; }
    }

    class CompetatorComparisonDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            Edusim db = new Edusim(Constants.ConnectionString);

            List<ComparisonInformation> reportData = (from m in db.MarketingData
                                                      where m.RoundProduct.Round == round
                                                      select new ComparisonInformation
                                                                                  {
                                                                                      ProductName = m.RoundProduct.ProductName,
                                                                                      SegmentTypeId = m.RoundProduct.SegmentTypeId,
                                                                                      SegmentTypeDescription = m.RoundProduct.SegmentType.Description,
                                                                                      PurchasedQuantity = m.PurchasedQuantity.HasValue ? m.PurchasedQuantity.Value : 0.0,
                                                                                      Price = m.Price.HasValue ? m.Price.Value : 0.0
                                                                                  }).ToList<ComparisonInformation>();


            (from m in db.ComputerRoundDetails
             join rp in db.ComputerMarketingData on m.ComputerRoundProduct equals rp.ComputerRoundProduct
             where m.Round == round
             select new ComparisonInformation
             {
                 ProductName = m.ComputerRoundProduct.ProductName,
                 SegmentTypeId = m.ComputerRoundProduct.SegmentTypeId,
                 SegmentTypeDescription = m.ComputerRoundProduct.SegmentType.Description,
                 PurchasedQuantity = m.PurchasedQuantity,
                 Price = rp.Price.HasValue ? rp.Price.Value : 0.0
             }).ToList().ForEach(o =>
            {
                reportData.Add(o);
            });

            reportData = reportData.OrderBy(o => o.SegmentTypeId).OrderBy(o => o.ProductName).ToList();

            dataGridView1.DataSource = reportData;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 1, 2 };
        }

        protected override void HandleDataChange(Gizmox.WebGUI.Forms.DataGridView dataGridView1, Gizmox.WebGUI.Forms.DataGridViewRow row, Gizmox.WebGUI.Forms.DataGridViewCell c, double oldValue)
        {
            throw new NotImplementedException();
        }
    }
}
