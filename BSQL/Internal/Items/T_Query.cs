using System;

namespace thePackage.BSQL.Internal.Items
{
	/// <summary>
	/// Summary description for T_Query.
	/// </summary>
	public interface T_Query
	{
		//string ToString();
	}

	//------------------------------------


	public interface T_Action: T_Query
	{}


	public class T_Select: T_Action
	{
		public override string ToString()
		{
			return "⁄—÷";
		}

	}
	public class T_Insert: T_Action
	{
		public override string ToString()
		{
			return "≈œŒ«·";
		}
	}
	public class T_Delete: T_Action
	{
		public override string ToString()
		{
			return "Õ–›";
		}
	}
	public class T_Update: T_Action
	{
		public override string ToString()
		{
			return " ⁄œÌ·";
		}
	}

	//---------------------------------

	public class T_Test: T_Query
	{
		A_Column column;
		string specificValue="";

		public T_Test(A_Column column ,string specificValue)
		{
			this.column=column;
			this.specificValue=specificValue;
		}
	
		public A_Column	Column
		{
			get
			{
				return this.column;
			}
		}

		public string	SpecificValue
		{
			get
			{
				return this.specificValue;
			}
		}

		public override string ToString()
		{
			return " ﬂÊ‰ "+this.column.ToString()+" ÂÌ "+this.specificValue ;
		}
	}

	//---------------------------------

	public class T_Comparison: T_Query
	{
		T_Argument first;
		T_Argument second;

		RelOP OP;

		public T_Comparison(RelOP OP,T_Argument first,	T_Argument second)
		{
			this.OP=OP;

			this.first=first;
			this.second=second;
		}

		public T_Argument First
		{
			get
			{
			return this.first;
			}
		}

		public T_Argument Second
		{
			get
			{
				return this.second;
			}
		}

		public RelOP RelOP
		{
			get
			{
				return this.OP;
			}
		}

		public override string ToString()
		{
			return " ﬂÊ‰ "
				+this.first.ToString() 
				+" "+ Enum_2_NL.Rel_OP(this.OP)+" "
				+this.second.ToString();
		}

	}

	public enum RelOP
	{
		/// <summary>
		/// >
		/// </summary>
		G,
		/// <summary>
		/// <
		/// </summary>
		L,
		/// <summary>
		/// ==
		/// </summary>
		E,
		/// <summary>
		/// >=
		/// </summary>
		GE,
		/// <summary>
		/// <=
		/// </summary>
		LE,
		/// <summary>
		/// <>
		/// </summary>
		NE,
		/// <summary>
		/// !>
		/// </summary>
		NG,
		/// <summary>
		/// !<
		/// </summary>
		NL,

		___________

	}

	//-------------------------------

	public interface T_Argument: T_Query
	{}

	public class A_Column: T_Argument
	{
		int columnNumber; 

		public A_Column(int columnNumber)
		{
			this.columnNumber=columnNumber;
		}

		public int	ColumnNumber
		{
			get
			{
				return this.columnNumber;
			}
		}

		public override string ToString()
		{
			return "ﬁÌ„… «·⁄„Êœ —ﬁ„ "+this.columnNumber.ToString();
		}

	}

	public class A_Value: T_Argument
	{
		string val; 

		public A_Value(string value)
		{
			this.val=value;
		}

		public string Value
		{
			get
			{
				return this.val;
			}
		}

		public override string ToString()
		{
			return this.val;
		}


	}

	public class Enum_2_NL
	{
		public static  string Rel_OP(RelOP op)
		{
			switch(op)
			{
				case  RelOP.GE:
					return "√ﬂ»— „‰ √Ê Ì”«ÊÌ";
				
				case  RelOP.LE:
					return "√’€— „‰ √Ê Ì”«ÊÌ";
				
				case RelOP.L:
					return "√’€— „‰";
				
				case  RelOP.G:
					return "√ﬂ»— „‰";
				
				case  RelOP.E:
					return "Ì”«ÊÌ";
				
				case RelOP.NE:
					return "·« Ì”«ÊÌ";
				
				case RelOP.NG:
					return "·« Ì“Ìœ ⁄‰";
				
				case RelOP.NL:
					return "·« Ìﬁ· ⁄‰";

				default:
				case RelOP.___________:
					return "·Ì” ·Â ⁄·«ﬁ… »«·ﬁÌ„…";

			}

		}


	}
}
