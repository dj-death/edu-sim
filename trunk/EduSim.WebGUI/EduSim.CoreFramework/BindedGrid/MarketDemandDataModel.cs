using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EduSim.CoreFramework.Common;
using Gizmox.WebGUI.Forms;
using EduSim.CoreFramework.DTO;

namespace EduSim.CoreFramework.DataControls
{
    public class RoundData
    {
        public string SegmentTypeDescription { get; set; }
        public double Performance { get; set; }
        public double Size { get; set; }
        public double MarketDemand { get; set; }
    }

    class MarketDemandDataModel : RoundDataModel
    {
        public override void GetList(DataGridView dataGridView1)
        {
            Edusim db = new Edusim(Constants.ConnectionString);

            List<RoundData> roundCriteria = (from r in db.RoundCriteria
                                                 where r.RoundCategoryId == round.RoundCategoryId
                                                 select new RoundData
                                                 {
                                                     SegmentTypeDescription = r.SegmentType.Description,
                                                     Performance = r.Performance,
                                                     Size = r.Size,
                                                     MarketDemand = r.MarketDemand.HasValue ? r.MarketDemand.Value : 0.0
                                                 }).ToList<RoundData>();

            dataGridView1.DataSource = roundCriteria;
        }

        public override int[] HiddenColumns()
        {
            return new int[] { 0, 1, 2, 3, 4 };
        }

        protected override void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            throw new NotImplementedException();
        }
    }
}
