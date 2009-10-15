using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Remoting;

namespace EduSim.CoreFramework.Common
{
    public class ListModel
    {
        public static Dictionary<string, string> contextDictionary = new Dictionary<string, string>();

        static ListModel()
        {
            contextDictionary["LIBACTI"] = "MyTestForm,MyTestForm.TestListModel";
        }

        public static ListModel GetInstance(string context)
        {
            string[] contextArray = contextDictionary[context].Split(",".ToCharArray());

            ObjectHandle oh = Activator.CreateInstance(contextArray[0], contextArray[1]);
            return oh.Unwrap() as ListModel;
        }

        public virtual DataSet GetList(int pageSize, string sortOrder, string filter, ref int CurrentPage, out int count)
        {
            if (!string.IsNullOrEmpty(sortOrder) && sortOrder.Contains("img_"))
                sortOrder = sortOrder.Replace("img_", string.Empty);

            count = 0;
            ListModelContextAttribute[] attribs = (ListModelContextAttribute[])
                        GetType().GetCustomAttributes(typeof(ListModelContextAttribute), true);

            DataSet dsReturn = null;

            if (attribs.Length > 0)
            {
                sortOrder = string.IsNullOrEmpty(sortOrder) ? attribs[0].DefaultSortColumn + " DESC" : sortOrder;
                dsReturn = CoreDatabaseHelper.GetODSData(attribs[0].Table, pageSize, sortOrder, filter, false, ref CurrentPage, out count, null);
            }

            return dsReturn;
        }
    }
}
