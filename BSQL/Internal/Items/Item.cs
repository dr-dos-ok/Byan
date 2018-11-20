using System;
using System.Collections;
using System.Windows.Forms;

namespace thePackage.BSQL.Internal.Items
{
	/// <summary>
	/// Summary description for Item.
	/// </summary>
	public interface Item
	{
		//bool Match(Term t);
		
		//Term Dup();

		bool Match(string word);

		void BindMatch(string word);

		string Value
		{
			get;
		}

		string Name
		{
			get;
		}
	}


	public class Constant : Item
	{
		public Constant (string s){this.val =s;}
		
		string val;

		public string Value
		{
			get{return this.val;}
		}

		public string Name
		{
			get
			{
				//return this.val ;
				
				return null;
			}

		}
//		public bool Match(Item t)
//		{
//			return (( t is Constant ) && ( ((Constant)t).val == this.val ) ) ;
//		}

		public bool Match(string word)
		{
			//System.Console.WriteLine(word.Trim() +"=="+ this.val.Trim() );

			//return (word == this.val )  ;

			return (word.Trim() == this.val.Trim() )  ;
		}

		public void BindMatch(string word)
		{
			this.val =word;
		}
	}

	public class Variable : Item
	{
		public Variable (string sName,string sVal)
		{
			this.Name =sName;
			this.val=sVal;
		}

		public Variable (string sName)
		{
			this.Name =sName;
			this.val=null;
		}

		string nam;
		string val;

		public string Name
		{
			get{return this.nam ;}
			set
			{
				this.nam =value;
			}
		}
		public string Value
		{
			get{return this.val ;}
			set
			{
				this.val =value;
			}
		}

//		public bool Match(Item other)
//		{
//			return (( other is Variable ) && ( ((Variable)other).nam == this.nam ) ) ;
//		}
	
		public bool Match(string word)
		{
			return true;
		}

		public void BindMatch(string word)
		{
			this.val =word;
		}

	}



	public class List : Item
	{
		public List (string sName,Words sVal)
		{
			this.Name =sName;
			this.val=new Words (sVal);
		}

		public List (string sName)
		{
			this.Name =sName;
			this.val=null;
		}


		string nam;
		
		Words val;

		public string Name
		{
			get{return this.nam ;}
			set
			{
				this.nam =value;
			}
		}
		public Words Items
		{
			get{return this.val ;}
			set
			{
				this.val =new  Words( value);
			}
		}

//		public bool Match(Item other)
//		{
//			return (( other is List ) && ( ((List)other).nam == this.nam ) ) ;
//		}

		public bool Match(string word)
		{
			return true;
		}

		public bool ListMatch(Words words)
		{
			return true;
		}

		public void BindMatch(string word)
		{
			//this.val =new ArrayList (new string[]{word});
		}

		public void BindMatch(Words words)
		{
			this.val =new Words (words);
		}


		public string Value
		{
			get
			{
				return null;
			}
		}

	}
}
