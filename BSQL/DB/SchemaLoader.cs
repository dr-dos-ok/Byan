using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;

namespace thePackage.BSQL.DB
{
	public class SchemaLoader
	{
		public string TableName="";

		public string Path="";

		public DataTable Table;

		public SchemaLoader(string TableName, string Path)
		{
			this.TableName=TableName;
			
			this.Path=Path;
			
			Initialize(TableName,Path);
			
		}

		


		#region DataBase
		private void Initialize(string TABLE_NAME, string PATH)
		{
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();

			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			//			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();

			this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();

			
			this.dataSet11=new  System.Data.DataSet();
			//this.dataSet11 = new thePackage.SQL.DB.DataSet1();
			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
			
			//   oleDbSelectCommand1
			this.oleDbSelectCommand1.CommandText = "SELECT * FROM "+TABLE_NAME;
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;


			//   oleDbConnection1
			this.oleDbConnection1.ConnectionString = 
				@"Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;"
				+@"Jet OLEDB:Database Locking Mode=1;"
				
				+@"Data Source="""				+PATH				+@""";"

				+@"Jet OLEDB:Engine Type=5;Provider=""Microsoft.Jet.OLEDB.4.0"";"
				+@"Jet OLEDB:System database=;Jet OLEDB:SFP=False;"
				+@"persist security info=False;Extended Properties=;"
				+@"Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;"
				+@"Jet OLEDB:Create System Database=False;"
				+@"Jet OLEDB:Don't Copy Locale on Compact=False;"
				+@"Jet OLEDB:Compact Without Replica Repair=False;"

				//				+@"User ID="				+@"Admin"			+@";"
				+@"User ID="				+""					+@";"
				
				+@"Jet OLEDB:Global Bulk Transactions=1";


 
			// oleDbDataAdapter1
			this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
			//this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
			
			//			this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] 
			//			{
			//				new System.Data.Common.DataTableMapping("Table", TABLE_NAME, new System.Data.Common.DataColumnMapping[] 
			//					{
			//						new System.Data.Common.DataColumnMapping("id", "id"),
			//						new System.Data.Common.DataColumnMapping("name", "name"),
			//						new System.Data.Common.DataColumnMapping("price", "price")
			//					})
			//			});
			
 
			// dataSet11
			this.dataSet11.DataSetName = "DataSet1";
			this.dataSet11.Locale = new System.Globalization.CultureInfo("en-US");
			

			((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
			
		}
		

		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		
		//private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		
		
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
		
		
		
		private System.Data.DataSet dataSet11;
		//private thePackage.SQL.DB.DataSet1 dataSet11;

		#endregion

		public DataTable GetAllData()
		{
			this.oleDbDataAdapter1.Fill(this.dataSet11);

			return this.dataSet11.Tables[0];

		}

		public DataTable DataTable
		{
			get
			{
				try
				{
					this.oleDbDataAdapter1.Fill(this.dataSet11);

					return this.dataSet11.Tables[0];
				}
				catch
				{
					return null;
				}
			}

		}



	}
}
