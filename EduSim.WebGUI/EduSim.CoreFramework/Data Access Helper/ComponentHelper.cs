using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Reflection;
using System.Data.Common;
using System.Globalization;
using System.Runtime.Serialization;
using EduSim.CoreUtilities.Utility;

namespace EduSim.CoreFramework.DataAccess
{
    public class ComponentHelper
    {
        private readonly Database db = DatabaseFactory.CreateDatabase();

        private static Dictionary<Type, DbType> dbTypeDictionary = new Dictionary<Type, DbType>();

        static ComponentHelper()
        {
            dbTypeDictionary[typeof(string)] = DbType.String;
            dbTypeDictionary[typeof(int)] = DbType.Int32;
            dbTypeDictionary[typeof(int?)] = DbType.Int32;
            dbTypeDictionary[typeof(Int16?)] = DbType.Int32;
            dbTypeDictionary[typeof(Int32)] = DbType.Int32;
            dbTypeDictionary[typeof(Int32?)] = DbType.Int32;
            dbTypeDictionary[typeof(bool)] = DbType.Boolean;
            dbTypeDictionary[typeof(bool?)] = DbType.Boolean;
            dbTypeDictionary[typeof(Boolean)] = DbType.Boolean;
            dbTypeDictionary[typeof(Boolean?)] = DbType.Boolean;
            dbTypeDictionary[typeof(double)] = DbType.Double;
            dbTypeDictionary[typeof(double?)] = DbType.Double;
            dbTypeDictionary[typeof(Decimal)] = DbType.Decimal;
            dbTypeDictionary[typeof(Decimal?)] = DbType.Decimal;
            dbTypeDictionary[typeof(DateTime)] = DbType.DateTime;
            dbTypeDictionary[typeof(DateTime?)] = DbType.DateTime;
            dbTypeDictionary[typeof(Int64)] = DbType.Int64;
            dbTypeDictionary[typeof(Int64?)] = DbType.Int64;
            dbTypeDictionary[typeof(Char)] = DbType.String;
            dbTypeDictionary[typeof(Char?)] = DbType.String;
        }

        public static ComponentHelper Instance = new ComponentHelper();

        object lockObj = new object();

        public Database Database
        {
            get
            {
                return db;
            }
        }

        public DataSet ExecuteDataSet(StoredProcedure sp, Dictionary<string, object> dic, params object[] parameters)
        {
            lock (lockObj)
            {
                DbCommand cmd = db.GetStoredProcCommand(sp.Name);

                string[] strs = SetInputOutParameters(sp, dic, parameters, cmd);

                DataSet ds = db.ExecuteDataSet(cmd);
                SetOutValues(dic, cmd, strs);
                return ds;
            }
        }

        public object ExecuteScalar(StoredProcedure sp, Dictionary<string, object> dic, params object[] parameters)
        {
            lock (lockObj)
            {
                DbCommand cmd = db.GetStoredProcCommand(sp.Name);

                string[] strs = SetInputOutParameters(sp, dic, parameters, cmd);

                object obj = db.ExecuteScalar(cmd);
                SetOutValues(dic, cmd, strs);
                return obj;
            }
        }

        public IDataReader ExecuteReader(StoredProcedure sp, Dictionary<string, object> dic, params object[] parameters)
        {
            lock (lockObj)
            {
                DbCommand cmd = db.GetStoredProcCommand(sp.Name);

                string[] strs = SetInputOutParameters(sp, dic, parameters, cmd);

                IDataReader dr = db.ExecuteReader(cmd);
                SetOutValues(dic, cmd, strs);
                return dr;
            }
        }

        public int ExecuteNonQuery<T>(StoredProcedure sp, Dictionary<string, object> dic, T dto) where T : class
        {
            lock (lockObj)
            {
                DbCommand cmd = db.GetStoredProcCommand(sp.Name);

                string[] strs = SetInputOutParameters<T>(sp, dic, dto, cmd);

                int retValue = db.ExecuteNonQuery(cmd);
                SetOutValues(dic, cmd, strs);
                return retValue;
            }
        }

        public int ExecuteNonQueryWithVariableParameters(StoredProcedure sp, Dictionary<string, object> dic, params object[] parameters)
        {
            lock (lockObj)
            {
                DbCommand cmd = db.GetStoredProcCommand(sp.Name);

                string[] strs = SetInputOutParameters(sp, dic, parameters, cmd);

                int retValue = db.ExecuteNonQuery(cmd);
                SetOutValues(dic, cmd, strs);
                return retValue;
            }
        }

        private string[] SetInputOutParameters<T>(StoredProcedure sp, Dictionary<string, object> dic,
            T dto, DbCommand cmd) where T : class
        {
            string[] strs = null;

            SetInputParametersFromDto<T>(dto, cmd, sp);
            strs = SetOutPatameters(cmd, sp, strs);

            if (dic != null && dic.Count != 0)
            {
                strs = SetInOutParameters(sp, dic, cmd, strs);
            }

            return strs;
        }

        private string[] SetInputOutParameters(StoredProcedure sp, Dictionary<string, object> dic,
            object[] parameters, DbCommand cmd)
        {
            string[] strs = null;
            if (parameters != null)
            {
                SetInputParameters(parameters, cmd, sp);
                strs = SetOutPatameters(cmd, sp, strs);
            }

            if (dic != null && dic.Count != 0)
            {
                strs = SetInOutParameters(sp, dic, cmd, strs);
            }

            return strs;
        }

        private void SetInputParameters(object[] values, DbCommand cmd, StoredProcedure sp)
        {
            string[] inputs = sp.Input.Split(",".ToCharArray());
            int i = 0;
            foreach (string input in inputs)
            {
                if (values[i] != null)
                {
                    db.AddInParameter(cmd, input.Trim(), dbTypeDictionary[values[i].GetType()], values[i]);
                }
                i++;
            }
        }

        private void SetInputParametersFromDto<T>(T dto, DbCommand cmd, StoredProcedure sp) where T : class
        {
            if (dto != null)
            {
                if (sp.Input != null && !sp.Input.Equals(string.Empty))
                {
                    string[] inputs = sp.Input.Split(",".ToCharArray());
                    foreach (string input in inputs)
                    {
                        PropertyInfo prop = dto.GetType().GetProperty(input);
                        if (prop != null)
                        {
                            object value = prop.GetValue(dto, null);
                            if (value != null)
                            {
                                db.AddInParameter(cmd, prop.Name, dbTypeDictionary[prop.PropertyType], value);
                            }
                        }
                    }
                }
            }
        }

        private string[] SetOutPatameters(DbCommand cmd, StoredProcedure sp, string[] strs)
        {
            if (sp.Out != null && !sp.Out.Equals(string.Empty))
            {
                List<string> list = new List<string>();
                string[] outputs = sp.Out.Split(";".ToCharArray());
                foreach (string output in outputs)
                {
                    string[] outputValue = output.Split(",".ToCharArray());
                    int dbType = 0;
                    int.TryParse(outputValue[1].Trim(), out dbType);
                    int size = 0;
                    int.TryParse(outputValue[2].Trim(), out size);

                    db.AddOutParameter(cmd, outputValue[0].Trim(), (DbType)dbType, size);
                    list.Add(outputValue[0]);
                }
                strs = list.ToArray();
            }
            return strs;
        }

        private string[] SetInOutParameters(StoredProcedure sp, Dictionary<string, object> dic, DbCommand cmd, string[] strs)
        {
            if (sp.InOut != null && !sp.InOut.Equals(string.Empty))
            {
                List<string> list = new List<string>();
                string[] inouts = sp.InOut.Split(";".ToCharArray());
                foreach (string inout in inouts)
                {
                    string[] inoutValue = inout.Split(",".ToCharArray());
                    int dbType = 0;
                    int.TryParse(inoutValue[1].Trim(), out dbType);
                    db.AddParameter(cmd, inoutValue[0].Trim(), (DbType)dbType, ParameterDirection.InputOutput, null, DataRowVersion.Default, dic[inoutValue[0]]);
                    list.Add(inoutValue[0]);

                }
                if (strs != null)
                    list.AddRange(strs);
                strs = list.ToArray();
            }
            return strs;
        }

        private void SetOutValues(Dictionary<string, object> dic, DbCommand cmd, string[] strs)
        {
            if (dic != null && strs != null)
            {
                foreach (string str in strs)
                {
                    dic[str] = db.GetParameterValue(cmd, str);
                }
            }
        }

        public static void CopyDataReaderToDto<T>(IDataReader dr, T dto) where T : class
        {
            //NOTE: This will work for one level
            //PLEASE call dr.Read() before passing the reader
            DataTable table = dr.GetSchemaTable();
            foreach (DataRow row in table.Rows)
            {
                PropertyInfo prop = dto.GetType().GetProperty(row["ColumnName"].ToString2());
                if (prop != null)
                {
                    SetValue<T>(dr[prop.Name], dto, prop);
                }
            }
        }

        public static void CopyDataTableToDto<T>(DataRow row, DataColumnCollection columns, T dto) where T : class
        {
            //NOTE: This will work for one level
            foreach (DataColumn column in columns)
            {
                PropertyInfo prop = dto.GetType().GetProperty(column.Caption);
                if (prop != null)
                {
                    SetValue<T>(row[prop.Name], dto, prop);
                }
            }
        }

        private static void SetValue<T>(object obj, T dto, PropertyInfo prop) where T : class
        {
            if (prop.PropertyType == obj.GetType())
            {
                prop.SetValue(dto, obj, null);
            }
            else
            {
                if (prop.PropertyType == typeof(string))
                {
                    prop.SetValue(dto, obj.ToString2(), null);
                }
                else if (!prop.PropertyType.IsPrimitive)
                {
                    if ((prop.PropertyType).FullName.Contains("System.Int64"))
                    {
                        if (!obj.Equals(DBNull.Value))
                            prop.SetValue(dto, BrixDatatypeHelper.ToInt64_2(obj), null);
                    }
                    else
                        prop.SetValue(dto, obj.Equals(DBNull.Value) ? null : obj, null);

                }
            }
        }

    }

    [Serializable]
    public class BrixDataSet : DataSet, ISerializable
    {
        public BrixDataSet()
            : base()
        {
            base.Locale = CultureInfo.InvariantCulture;
        }

        public BrixDataSet(string tableName)
            : base(tableName)
        {
            base.Locale = CultureInfo.InvariantCulture;
        }

        protected BrixDataSet(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class BrixDataTable : DataTable, ISerializable
    {
        public BrixDataTable()
            : base()
        {
            base.Locale = CultureInfo.InvariantCulture;
        }

        public BrixDataTable(string tableName)
            : base(tableName)
        {
            base.Locale = CultureInfo.InvariantCulture;
        }

        protected BrixDataTable(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
