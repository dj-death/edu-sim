using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Xml;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.Linq;
using System.Runtime.Serialization;
using System.Globalization;
using Gizmox.WebGUI.Forms;
using EduSim.CoreFramework.DataAccess;

namespace EduSim.CoreFramework.Common
{
    public delegate void CreateAssociation(object obj, Control checkedListBox);

    public static class CoreDatabaseHelper
    {
        private const string IMGPATHCATALOG = "~/Images/IcnPage.gif";

        private static Object lockObj = new object();

        public static int GenericLibraryUpdate(string UpdateQuery, string WhereClause, string objectname)
        {
            try
            {
                lock (lockObj)
                {
                    return (int)(ComponentHelper.Instance.ExecuteScalar(StoredProcedure.usp_APPMGMTGenericUpdate, null, objectname, UpdateQuery, WhereClause));
                }
            }
            catch (SqlException)
            {
                return -1;
            }
            catch
            {
                throw;
            }
        }

        public static int GenericLibraryInsert(string values, string objectname)
        {
            try
            {
                lock (lockObj)
                {
                    ComponentHelper.Instance.ExecuteNonQueryWithVariableParameters(StoredProcedure.usp_APPMGMTGenericInsert, null, objectname, values);
                    return 1;
                }
            }
            catch (SqlException)
            {
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public static int GenericLibraryInsert(string columnNames, string values, string objectname)
        {
            try
            {
                lock (lockObj)
                {
                    ComponentHelper.Instance.ExecuteNonQueryWithVariableParameters(StoredProcedure.usp_LIBRARYGenericInsert, null, columnNames, values, objectname);
                    return 1;
                }
            }
            catch (SqlException)
            {
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public static int GenericLibraryDelete(string TableName, string PrimaryKeyName, string IDs)
        {
            try
            {
                lock (lockObj)
                {
                    ComponentHelper.Instance.ExecuteNonQueryWithVariableParameters(StoredProcedure.USP_APPMGMTGenericDelete, null, TableName, PrimaryKeyName, IDs);
                    return 1;
                }
            }
            catch (SqlException)
            {
                return 0;
            }
            catch
            {
                throw;
            }
        }

        public static DataTable GenericLibraryGetData(string objectname, string primaryColumnName, int primaryID)
        {
            try
            {
                lock (lockObj)
                {
                    return ComponentHelper.Instance.ExecuteDataSet(StoredProcedure.usp_APPMGMTGenericGetData, null, objectname, primaryColumnName, primaryID, 0).Tables[0];

                }
            }
            catch (SqlException)
            {
                return null;
            }
            catch
            {
                throw;
            }
        }

        public static DataSet GetODSData(string objectName, object maxRows, string sortOrder, string filterSearch, bool xml, ref int CurrentPage, out int count, string[] dataSourceFilters, int? RID, int? UID, string AXCompany)
        {
            Dictionary<string, string> dicDataSourceFilter = new Dictionary<string, string>();
            if (dataSourceFilters != null)
            {
                foreach (string key in dataSourceFilters)
                {
                    dicDataSourceFilter.Add(key,
                       string.IsNullOrEmpty(HttpContext.Current.Request[key]) ? null : HttpContext.Current.Request[key]);
                }
            }
            return GetODSData(objectName, maxRows, sortOrder, filterSearch, xml, ref CurrentPage, out count, dicDataSourceFilter, RID, UID, AXCompany);
        }

        public static DataSet GetODSData(string objectName, object maxRows, string sortOrder, string filterSearch, bool xml, ref int CurrentPage, out int count, string[] dataSourceFilters)
        {
            Dictionary<string, string> dicDataSourceFilter = new Dictionary<string, string>();
            if (dataSourceFilters != null)
            {
                foreach (string key in dataSourceFilters)
                {
                    dicDataSourceFilter.Add(key,
                       string.IsNullOrEmpty(HttpContext.Current.Request[key]) ? null : HttpContext.Current.Request[key]);
                }
            }
            return GetODSData(objectName, maxRows, sortOrder, filterSearch, xml, ref CurrentPage, out count, dicDataSourceFilter, null, null, null);
        }

        public static DataSet GetODSData(string objectName, object maxRows, string sortOrder, string filterSearch, bool xml, ref int CurrentPage, out int count, Dictionary<string, string> dataSourceFilters, int? RID, int? UID, string AXCompany)
        {
            try
            {
                lock (lockObj)
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    dic["CurrentPage"] = CurrentPage;
                    if (!string.IsNullOrEmpty(filterSearch) && xml)
                    {
                        filterSearch = FormatFilterText(filterSearch);
                    }
                    if (dataSourceFilters != null)
                    {
                        StringBuilder dbFilter = new StringBuilder();

                        foreach (string key in dataSourceFilters.Keys)
                        {
                            if (!(String.IsNullOrEmpty(dataSourceFilters[key]) &&
                                String.IsNullOrEmpty(HttpContext.Current.Request[key])))
                            {
                                dbFilter.AppendFormat("{0}={1} AND ", key,
                                    String.IsNullOrEmpty(HttpContext.Current.Request[key]) ? "'" + dataSourceFilters[key] + "'"
                                    : "'" + HttpContext.Current.Request[key] + "'");
                            }
                        }
                        filterSearch = filterSearch + (string.IsNullOrEmpty(filterSearch) ? dbFilter.ToString() : " AND " + dbFilter.ToString());
                        if (filterSearch.EndsWith("AND ",StringComparison.OrdinalIgnoreCase))
                            filterSearch = filterSearch.Remove(filterSearch.LastIndexOf("AND ",StringComparison.OrdinalIgnoreCase));
                    }

                    filterSearch = string.IsNullOrEmpty(filterSearch) ? null : filterSearch;

                    DataSet ds = ComponentHelper.Instance.ExecuteDataSet(StoredProcedure.usp_ODS, dic, filterSearch, maxRows, sortOrder, objectName, RID, UID, AXCompany);
                    Int32.TryParse(dic["PageCount"].ToString(), out count);
                    Int32.TryParse(dic["CurrentPage"].ToString(), out CurrentPage);
                    return ds;
                }
            }
            catch
            {
                throw;
            }
        }

        public static DataSet GetODSData(string objectName, object startRowIdx, object maxRows, string sortOrder, string filterSearch, ref int CurrentPage, out int count, string[] dataSourceFilters)
        {
            return GetODSData(objectName, maxRows, sortOrder, filterSearch, true, ref CurrentPage, out count, dataSourceFilters, null, null, null);
        }

        internal static string FormatFilterText(string filterSearch)
        {
            //<XMLRoot>
            //    <ID type='txt'>valueid</ID>
            //    <Name type='txt'>valuename</Name>
            //    <Contact type='txt'>valuecontact</Contact>
            //</XMLRoot>

            string strQuery;
            StringBuilder strBQuery = new StringBuilder();
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(filterSearch);
            XmlNode node;
            if ((node = xDoc.SelectSingleNode("XMLRoot")) != null)
            {
                IEnumerator en = node.ChildNodes.GetEnumerator();
                while (en.MoveNext())
                {
                    node = en.Current as XmlNode;

                    string itemName = node.Name;
                    if (node.InnerText != "")   //node.Attributes["type"].Value == "txt" && 
                    {
                        string temp = node.InnerText;
                        if (temp.Contains("%") || temp.Contains("_") || temp.Contains("[") || temp.Contains("'"))
                        {
                            // -- oracle
                            temp = temp.Replace("[", "[[]");
                            temp = temp.Replace("%", "[%]");
                            temp = temp.Replace("_", "[_]");
                            temp = temp.Replace("'", "''");

                            //temp = temp.Replace("&", "&amp;");
                            //temp = temp.Replace("<", "&lt;");
                            //temp = temp.Replace(">", "&gt;");
                            //temp = temp.Replace('"', "&quot;");
                            //temp = temp.Replace("'", "&apos;");

                            //temp = temp.Replace("\\", "\\\\");
                            //temp = temp.Replace("%", "\\%");
                            //temp = temp.Replace("_", "\\_");
                        }
                        if (node.Attributes["type"].Value != "dc")
                            strBQuery.AppendFormat("([{0}] LIKE '%{1}%') AND ", itemName, temp);
                        else
                            strBQuery.AppendFormat("(convert(varchar(10), [{0}], 101) = convert(varchar(10), cast('{1}' as datetime), 101)) AND ", itemName, temp);
                    }
                }
            }
            strQuery = strBQuery.ToString();
            strQuery = (String.IsNullOrEmpty(strQuery) || (strQuery.LastIndexOf("AND ",StringComparison.OrdinalIgnoreCase) < 0))
                ? "" : strQuery.Substring(0, strQuery.LastIndexOf("AND ",StringComparison.OrdinalIgnoreCase));
            return strQuery;
        }

        internal static string[] GetScriptDelimitors()
        {
            return new string[] { "\r\nGO", "\nGO", "\r\nGo", "\nGo" };
        }

        public static void Modify(List<Control> list, object obj, CreateAssociation CreateAssociation)
        {
            if (obj != null)
            {
                foreach (Control control in list)
                {
                    if (control is Label)
                    {
                        continue;
                    }
                    else if (control is CheckedListBox || control is ComboBox)
                    {
                        CreateAssociation(obj, control );
                        continue;
                    }
                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
                    {
                        if (control.Name.Equals(prop.Name))
                        {
                            if (control is TextBox)
                            {
                                prop.SetValue(obj, control.Text, null);
                                break;
                            }
                            else if (control is CheckBox)
                            {
                                prop.SetValue(obj, (control as CheckBox).Checked, null);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
