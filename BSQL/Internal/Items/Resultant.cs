using System;
using System.Data;

namespace thePackage.BSQL.Internal.Items
{
	/// <summary>
	/// Summary description for Resultant.
	/// </summary>
	public class Resultant
	{

		DataTable result;
		string message;

		public Resultant(string message, DataTable result)
		{
			this.message=message;
			this.result=result;

		}

		public Resultant(string message)
		{
			this.message=message;
			this.result=null;

		}

		public Resultant(DataTable result)
		{
			this.message=null;
			this.result=result;

		}

		public DataTable Table
		{
			get{return this.result;}
		}
		
		public string Message
		{
			get{return this.message;}
		}

	}
}
