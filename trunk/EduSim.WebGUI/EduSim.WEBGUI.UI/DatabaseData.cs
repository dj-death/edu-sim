using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Gizmox.WebGUI.Common;
using System.Runtime.Serialization;

namespace Gizmox.WebGUI.Forms.Catalog
{
	/// <summary>
	/// Summary description for DatabaseData.
	/// </summary>

    [Serializable()]
    public class DatabaseData : DataSet
	{
		private OleDbConnection mobjConnection;
		private OleDbDataAdapter mobjCustomerDataAdapter;
        

		public DatabaseData() 
		{


		}

        protected DatabaseData(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }

		public OleDbConnection Connection
		{
			get
			{
				if(mobjConnection==null)
				{
					// Create connection
					string strDatabase = Path.Combine(Global.Context.Config.GetDirectory("Data"),"Orders.mdb");
					string strUserID = "Admin";
					string strPassword = "";
					mobjConnection = new OleDbConnection(string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};User ID={1};Password={2}",strDatabase,strUserID,strPassword));
				}
				return mobjConnection;
			}
		}

		public void LoadCustomers()
		{
			mobjCustomerDataAdapter = new OleDbDataAdapter("select * from Customers",Connection);
			OleDbCommandBuilder objBuilder = new OleDbCommandBuilder(mobjCustomerDataAdapter);
			mobjCustomerDataAdapter.Fill(this,"Customers");
            
		}


        public void LoadTable(string TableName)
        {
            mobjCustomerDataAdapter = new OleDbDataAdapter("select * from " + TableName, Connection);
            OleDbCommandBuilder objBuilder = new OleDbCommandBuilder(mobjCustomerDataAdapter);
            mobjCustomerDataAdapter.Fill(this, "Customers");

        }

		public void CommitChanges()
		{
			
			if(mobjCustomerDataAdapter!=null)
			{
				
				
				DataTable objDataTable =  this.Tables["Customers"].GetChanges(DataRowState.Modified);
				if(objDataTable!=null)
				{

					mobjCustomerDataAdapter.Update(objDataTable);
				}

			}
		}
	}
}
