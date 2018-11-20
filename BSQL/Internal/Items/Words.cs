using System;
using System.Collections;

namespace thePackage.BSQL.Internal.Items
{
	/// <summary>
	/// Summary description for Words.
	/// </summary>
	public class Words
	{
		ArrayList list=new ArrayList();

//		public Words(ICollection list)
//		{
//			this.list=new ArrayList (list);
//		}

		public Words(Words words)
		{
			this.list=new ArrayList (words.list);
		}

		public Words(params string[] words)
		{
			this.list=new ArrayList (words);
		}


		Words(ArrayList words)
		{
			this.list=new ArrayList (words);
		}


		public Words()
		{
			this.list=new ArrayList ();
		}

		public void Add(string word)
		{
			this.list.Add(word);
		}

		public void AddRange(string[] words)
		{
			this.list.AddRange(words);

		}

		public void AddRange(Words words)
		{
			this.list.AddRange(words.Items);

		}

		public Words GetRange(int pos)
		{
			return new Words(this.list.GetRange(pos,this.list.Count-pos));

		}

		public string this[int i]
		{
			get
			{
				return (this.list[i]==null)
					?
					null
					:
					this.list[i].ToString();
			}
			set{this.list[i]=value;}
		}


		public string[] Items
		{
			get{return (string[])this.list.ToArray("".GetType());}
			set{this.list=new ArrayList(value); }
		}

//		public IEnumerator GetEnumerator()
//		{
//			return list.GetEnumerator();
//		}

		public string ToString(string del)
		{
			return 
				string.Join
				(
				del,this.Items
				)
				;
		}

	}
}
