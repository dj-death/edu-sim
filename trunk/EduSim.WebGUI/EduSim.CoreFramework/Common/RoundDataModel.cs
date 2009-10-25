using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Forms;
using System.Web;
using EduSim.CoreFramework.DTO;

namespace EduSim.CoreFramework.Common
{
    public abstract class RoundDataModel
    {
        protected UserDetails user = HttpContext.Current.Session[SessionConstants.CurrentUser] as UserDetails;
        protected Round round = HttpContext.Current.Session[SessionConstants.CurrentRound] as Round;

        public abstract object GetList();

        public abstract int[] HiddenColumns();

        public bool Current
        {
            get { return round.TeamGame.Game.Active.HasValue ? round.TeamGame.Game.Active.Value : false; }
        }

        public abstract void HandleDataChange(DataGridViewRow row, DataGridViewCell c);

        public abstract void ComputeAllCells(DataGridView dataGridView1);

        public abstract void Save(DataGridView dataGridView1);

        public virtual void AddProduct(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }

        protected static Dictionary<string, double> GetSessionData(string sessionId)
        {
            Dictionary<string, double> data = new Dictionary<string, double>();
            HttpContext.Current.Session[sessionId] = data;
            return data;
        }
    }
}
