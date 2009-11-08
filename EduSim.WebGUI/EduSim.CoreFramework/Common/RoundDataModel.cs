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
        protected static Dictionary<string, double> configurationInfo = new Dictionary<string, double>();

        static RoundDataModel()
        {
            Edusim db = new Edusim();

            (from c in db.ConfigurationData
             select c).ToList<ConfigurationData>().ForEach(o => configurationInfo[o.Name] = o.Value);
        }

        public abstract void GetList(DataGridView dataGridView1);

        public abstract int[] HiddenColumns();

        public bool Current
        {
            get { return round.TeamGame.Game.Active.HasValue ? round.TeamGame.Game.Active.Value : false; }
        }

        public virtual void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }

        public virtual void AddProduct(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, T> GetData<T>(string name)
        {
            Dictionary<string, T> dic = (Dictionary<string, T>)HttpContext.Current.Session[name];

            if (dic == null)
            {
                dic = new Dictionary<string, T>();
                HttpContext.Current.Session[name] = dic;
            }
            return dic;
        }
    }
}
