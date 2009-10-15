﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Data;
using System.Reflection;
using System.Xml;
using EduSim.CoreFramework.DataAccess;

namespace EduSim.CoreUtilities.Utility
{
    public static class BrixDatatypeHelper
    {
        public static string ToUpper2(this string str)
        {
            return str.ToUpperInvariant();
        }

        public static string ToLower2(this string str)
        {
            return str.ToLowerInvariant();
        }

        public static short ToInt16_2(this object str)
        {
            return Convert.ToInt16(str, CultureInfo.InvariantCulture);
        }

        public static int ToInt32_2(this object str)
        {
            return Convert.ToInt32(str, CultureInfo.InvariantCulture);
        }

        public static Int64 ToInt64_2(this object str)
        {
            return Convert.ToInt64(str, CultureInfo.InvariantCulture);
        }

        public static string Format2(this string str, params object[] objs)
        {
            return string.Format(CultureInfo.InvariantCulture, str, (object[])objs);
        }

        public static decimal ToDecimal2(this string str)
        {
            return Convert.ToDecimal(str, CultureInfo.InvariantCulture);
        }

        public static decimal ToDecimal2(this object str)
        {
            return Convert.ToDecimal(str, CultureInfo.InvariantCulture);
        }

        public static double ToDouble2(this string str)
        {
            return Convert.ToDouble(str, CultureInfo.InvariantCulture);
        }

        public static double ToDouble2(this int str)
        {
            return Convert.ToDouble(str, CultureInfo.InvariantCulture);
        }

        public static double ToDouble2(this object str)
        {
            return Convert.ToDouble(str, CultureInfo.InvariantCulture);
        }

        public static int Parse2(this string str)
        {
            return int.Parse(str, CultureInfo.InvariantCulture);
        }

        public static bool ToBoolean2(this string str)
        {
            return Convert.ToBoolean(str, CultureInfo.InvariantCulture);
        }

        public static bool ToBoolean2(this object str)
        {
            return Convert.ToBoolean(str, CultureInfo.InvariantCulture);
        }

        public static string ToString2(this object str)
        {
            return Convert.ToString(str, CultureInfo.InvariantCulture);
        }

        public static DateTime ToDateTime2(this object str)
        {
            return Convert.ToDateTime(str, CultureInfo.InvariantCulture);
        }

        public static string ToString2(this int intValue)
        {
            return intValue.ToString(CultureInfo.InvariantCulture);
        }

        public static string ToString2(this long intValue)
        {
            return intValue.ToString(CultureInfo.InvariantCulture);
        }

        public static string ToString2(this double intValue)
        {
            return intValue.ToString(CultureInfo.InvariantCulture);
        }

        public static string ToString2(this DateTime intValue)
        {
            return intValue.ToString(CultureInfo.InvariantCulture);
        }

        public static bool EndsWith2(this string intValue, string param)
        {
            return intValue.EndsWith(param, StringComparison.Ordinal );
        }

        public static bool StartsWith2(this string intValue, string param)
        {
            return intValue.StartsWith(param, StringComparison.Ordinal);
        }

        public static byte ToByte2(this object value)
        {
            return Convert.ToByte(value, CultureInfo.InvariantCulture);
        }
    }

    public static class LinqHelper
    {

        public static DataTable ToDataTable<T>(this IEnumerable<T> varlist, CreateRowDelegate<T> fn)
        {
            int count = 0;
            try { count = varlist.Count<T>(); }
            catch (Exception ex) { throw new Exception("The supplied IEnumerable object is empty and can not be converted to a DataTable; Error : \"" + ex.Message + "\"", ex); }

            DataTable dtReturn = new BrixDataTable();
            if (count > 0)
            {
                T TopDTO = varlist.ElementAt(0);
                if (TopDTO != null)
                {
                    PropertyInfo[] dTOProps = TopDTO.GetType().GetProperties();
                    foreach (PropertyInfo pi in dTOProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                            colType = colType.GetGenericArguments()[0];
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }

                    foreach (T dTO in varlist)
                    {
                        DataRow dr = dtReturn.NewRow();
                        foreach (PropertyInfo pi in dTOProps)
                            dr[pi.Name] = pi.GetValue(dTO, null) == null ? DBNull.Value : pi.GetValue(dTO, null);
                        dtReturn.Rows.Add(dr);
                    }
                }
            }
            return dtReturn;
        }

        public delegate object[] CreateRowDelegate<T>(T t);

        public static void CopyTo<T>(this T src, T trg)
        {
            PropertyInfo[] srcProps = ((Type)src.GetType()).GetProperties();
            PropertyInfo[] trgProps = ((Type)trg.GetType()).GetProperties();
            foreach (PropertyInfo srcPI in srcProps)
                foreach (PropertyInfo trgPI in trgProps)
                    if (srcPI.Name.Equals(trgPI.Name))
                        trgPI.SetValue(trg, srcPI.GetValue(src, null), null);
        }
    }

    public static class XmlNodeHelper
    {
        public static void CopyTo<T>(this XmlNode xNode, T target)
        {

            PropertyInfo[] trgProps = ((Type)target.GetType()).GetProperties();

            foreach (PropertyInfo trgPI in trgProps)
            {
                string data = xNode.Attributes[trgPI.Name.ToLower2()].InnerText;

                trgPI.SetValue(target, data, null);
            }
        }
    }
}
