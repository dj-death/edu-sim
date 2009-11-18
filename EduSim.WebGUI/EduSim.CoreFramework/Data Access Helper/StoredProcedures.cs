using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EduSim.CoreFramework.DataAccess
{
    public class StoredProcedure
    {
        public string Name { get; protected set; }
        public string Input { get; protected set; }
        public string Out { get; protected set; }
        public string InOut { get; protected set; }

        protected StoredProcedure() { }

        internal static StoredProcedure USP_APPMGMTGenericDelete =
            new StoredProcedure() { Name = "USP_APPMGMTGenericDelete", Input = "TableName,PrimaryKeyName,IDs" };

        internal static StoredProcedure usp_LIBRARYGenericInsert =
            new StoredProcedure() { Name = "usp_LIBRARYGenericInsert", Input = "ColumnName,Values,ObjectName" };

        public static StoredProcedure usp_ODS =
            new StoredProcedure() { Name = "usp_ODS", Input = "filterText,maxRowsInPage,sortOrder,ObjectName,RID,UID,ERPCOMPANY", Out = "PageCount,11,4", InOut = "CurrentPage,11" };

        public static StoredProcedure usp_APPMGMTGenericGetData =
            new StoredProcedure() { Name = "usp_APPMGMTGenericGetData", Input = "ObjectName,PrimaryColumnName,PrimaryID,ContractID" };

        public static StoredProcedure usp_APPMGMTGenericUpdate =
            new StoredProcedure() { Name = "usp_APPMGMTGenericUpdate", Input = "ObjectName,UpdateQuery,WhereClause" };

        public static StoredProcedure usp_APPMGMTGenericInsert =
            new StoredProcedure() { Name = "usp_APPMGMTGenericInsert", Input = "ObjectName,Values" };

    }
}
