using System;
using System.Collections;

namespace thePackage.BSQL.Internal.Items
{
	/// <summary>
	/// Summary description for Queryz.
	/// </summary>
	public class Queryz
	{
		ArrayList list=new ArrayList();

		public Queryz(Queryz words)
		{
			this.list=new ArrayList (words.list);
		}

		public Queryz(params T_Query[] queries)
		{
			this.list=new ArrayList (queries);
		}


		Queryz(ArrayList words)
		{
			this.list=new ArrayList (words);
		}


		public Queryz()
		{
			this.list=new ArrayList ();
		}

		public void Add(T_Query query)
		{
			this.list.Add(query);
		}

		public void AddRange(T_Query[] queryz)
		{
			this.list.AddRange(queryz);

		}

		public void AddRange(Queryz words)
		{
			this.list.AddRange(words.Items);

		}

		public Queryz GetRange(int pos)
		{
			return new Queryz(this.list.GetRange(pos,this.list.Count-pos));

		}

		public T_Query this[int i]
		{
			get
			{
				return (this.list[i]==null)
					?
					null
					:
					(T_Query)this.list[i];
			}

			set{this.list[i]=value;}
		}


		public T_Query[] Items
		{
			get{return (T_Query[])this.list.ToArray(typeof(T_Query));}
			set{this.list=new ArrayList(value); }
		}

		public string ToString(string del)
		{
			ArrayList arr=new ArrayList();

			foreach(T_Query q in this.Items)
			{
				arr.Add(q.ToString());
			}

			return 
				string.Join
				(
				del,
				(string[])arr.ToArray("".GetType())
				)
				;
		}


		public Queryz Sort()
		{
			Queryz actions=new Queryz();
			Queryz test_or_copmarison=new Queryz();

			foreach(T_Query q in this.Items)
			{
				if( q is T_Action)
					actions.Add(q);
				else
					test_or_copmarison.Add(q);
			}

			Queryz result=new Queryz();
			result.AddRange(test_or_copmarison);
			result.AddRange(actions);
			return result;

		}

	}
}
