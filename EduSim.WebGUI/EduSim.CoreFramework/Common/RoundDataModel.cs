using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gizmox.WebGUI.Forms;
using System.Web;
using EduSim.CoreFramework.DTO;
using System.Drawing;
using System.Reflection;
using EduSim.CoreUtilities.Utility;

namespace EduSim.CoreFramework.Common
{
    public abstract class RoundDataModel
    {
        protected UserDetails user = HttpContext.Current.Session[SessionConstants.CurrentUser] as UserDetails;
        protected Round round = HttpContext.Current.Session[SessionConstants.CurrentRound] as Round;
        protected static Dictionary<string, double> configurationInfo = new Dictionary<string, double>();

        static RoundDataModel()
        {
            Edusim db = new Edusim(Constants.ConnectionString);

            (from c in db.ConfigurationData
             select c).ToList<ConfigurationData>().ForEach(o => configurationInfo[o.Name] = o.Value);
        }

        public abstract void GetList(DataGridView dataGridView1);

        public abstract int[] HiddenColumns();

        public bool Current
        {
            get { return round.Current; }
        }

        protected abstract void HandleDataChange(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue);

        public virtual void HandleDataChangeBase(DataGridView dataGridView1, DataGridViewRow row, DataGridViewCell c, double oldValue)
        {
            try
            {
                double.Parse(c.Value.ToString());
            }
            catch (Exception e)
            {
                c.Value = oldValue;
                throw e;
            }

            HandleDataChange(dataGridView1, row, c, oldValue);
        }

        public virtual void AddProduct(DataGridView dataGridView1)
        {
            throw new NotImplementedException();
        }

        public static Dictionary<string, T> GetData<T>(SessionConstant name, int roundId)
        {
            Dictionary<string, T> dic = (Dictionary<string, T>)HttpContext.Current.Session[name.ToString() + "|" + roundId];

            if (dic == null)
            {
                dic = new Dictionary<string, T>();
                HttpContext.Current.Session[name.ToString() + "|" + roundId] = dic;
            }
            return dic;
        }

        public static Dictionary<SessionConstant, Dictionary<string, object>> GetData(int roundId)
        {
            Dictionary<SessionConstant, Dictionary<string, object>> dic = (Dictionary<SessionConstant, Dictionary<string, object>>)HttpContext.Current.Session[roundId.ToString()];

            if (dic == null)
            {
                dic = new Dictionary<SessionConstant, Dictionary<string, object>>();
                HttpContext.Current.Session[roundId.ToString()] = dic;
            }
            return dic;
        }

        public static double GetCost(double currentValue, double previousValue, double coeffecient)
        {
            return GetCost(currentValue, previousValue, coeffecient, true);
        }

        public static double GetCost(double currentValue, double previousValue, double coeffecient, bool positive)
        {
            double val = 0;
            double diff = currentValue - previousValue;
            if (positive)
            {
                val = (currentValue > previousValue) ? (diff) * coeffecient
                    : (diff) * -1 * coeffecient / 2;
            }
            else
            {
                val = (previousValue > currentValue) ? (diff) * -1 * coeffecient
                    : (diff) * coeffecient / 2;
            }
            return val;
        }

        public virtual bool EnableAddProduct
        {
            get { return false; }
        }

        protected void AddRowForHeader(DataGridView dataGridView1, string header)
        {
            AddRowForColumn(dataGridView1, header, Color.Gray, false);
        }

        protected void AddRowForColumnDefault(DataGridView dataGridView1, string p)
        {
            AddRowForColumn(dataGridView1, p, Color.LightGray, true);
        }

        private void AddRowForColumn(DataGridView dataGridView1, string header, Color backColor, bool defaultColor)
        {
            DataGridViewRow r = new DataGridViewRow();

            DataGridViewCell t = new DataGridViewTextBoxCell();
            t.Value = header;
            t.Style = new DataGridViewCellStyle();

            if (!defaultColor)
            {
                t.Style.BackColor = backColor;
            }
            r.Cells.Add(t);

            dataGridView1.Rows.Add(r);
        }


        protected static void AddHeader(DataGridViewRow r, string header)
        {
            DataGridViewCell t = new DataGridViewTextBoxCell();
            t.Value = header;
            r.Cells.Add(t);
        }

        protected static void AddSingleColumnData(DataGridView dataGridView1, List<double> data, DataGridViewRow r, double netProfit)
        {
            data.Add(netProfit);
            DataGridViewCell t1 = new DataGridViewTextBoxCell();
            t1.Value = netProfit.ToString("$###0.00");
            r.Cells.Add(t1);
            dataGridView1.Rows.Add(r);
        }

        protected static void AddMultipleColumnData(double val, Dictionary<string, List<double>> data, DataGridViewRow r, string str)
        {
            DataGridViewCell t1 = new DataGridViewTextBoxCell();

            t1.Value = val.ToString("$###0.00");

            data[str].Add(val);
            r.Cells.Add(t1);
        }

        protected void AddRow<T>(Dictionary<string, T> data, IEnumerable<string> products,
            DataGridView dataGridView1, string p, Dictionary<string, List<double>> gridData)
        {
            DataGridViewRow r = new DataGridViewRow();

            AddHeader(r, p);

            foreach (string str in products)
            {
                DataGridViewCell t1 = new DataGridViewTextBoxCell();
                if (data != null && data.Count > 0)
                {
                    T dat = data[str];
                    PropertyInfo prop = dat.GetType().GetProperty(p);

                    double val = prop.GetValue(dat, null).ToDouble2();
                    gridData[str].Add(val);

                    t1.Value = val.ToString("$###0.00");
                }
                else
                {
                    gridData[str].Add(0.0);

                    t1.Value = (0.0).ToString("$###0.00");
                }
                r.Cells.Add(t1);
            }
            dataGridView1.Rows.Add(r);
        }
    }
}
