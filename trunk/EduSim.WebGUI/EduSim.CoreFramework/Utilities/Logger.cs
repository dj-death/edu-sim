using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Reflection;
using Aurigo.AMP3.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Aurigo.Brix.Platform.CoreUtilities.Utility;

namespace Aurigo.AMP3.Logging
{
    public class Logger
    {
        private static Database db = CoreDatabaseHelper.GetDBObject();

        private static void LogInDB(string type, DateTime timestamp, string source, int eventid, string username,
                                    string message)
        {
            int category = 0;

            DbCommand cmd = db.GetStoredProcCommand("usp_APPMGMTWriteLog");

            db.AddInParameter(cmd, "TYPE", DbType.String, type);
            db.AddInParameter(cmd, "DATETIME", DbType.DateTime, timestamp);
            db.AddInParameter(cmd, "SOURCE", DbType.String, source);
            db.AddInParameter(cmd, "CATEGORY", DbType.Int32, category);
            db.AddInParameter(cmd, "EVENT", DbType.Int32, eventid);
            db.AddInParameter(cmd, "USERNAME", DbType.String, username);
            db.AddInParameter(cmd, "MESSAGE", DbType.String, message);
            db.AddOutParameter(cmd, "STATUS", DbType.Int32, 4);
            db.ExecuteScalar(cmd);
        }

        public static int Log(Enumerations.LogType type, string message, string source)
        {
            return -1;
        }

        private static void LogInEventViewer(string type, string source, string message)
        {
            if (!EventLog.SourceExists(source))
                EventLog.CreateEventSource(source, "Application");

            EventLog entry = new EventLog();

            entry.Source = source;

            entry.WriteEntry(message, type.Equals("Error")
                                          ? EventLogEntryType.Error
                                          : type.Equals("Warning")
                                                ? EventLogEntryType.Warning
                                                : EventLogEntryType.Information);
        }

        private static string GetMethodName()
        {
            string str = "";
            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(2);
            if (sf != null)
            {
                MethodBase mb = sf.GetMethod();
                if (mb != null)
                {
                    if (mb.ReflectedType != null && mb.ReflectedType.FullName != null && mb.Name != null)
                    {
                        str = mb.ReflectedType.FullName + "." + mb.Name.ToString2();
                    }
                }
            }
            return str;
        }
    }
    public class Enumerations
    {
        public enum MessageType
        {
            ErrorMessage = 0,
            WarningMessage = 1,
            InfoMessage = 2
        }

        public enum LogType
        {
            Error = 0,
            Warning = 1,
            Information = 2
        }
    }
}