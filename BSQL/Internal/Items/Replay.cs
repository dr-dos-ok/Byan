using System;

namespace thePackage.DOS.Internal.Items
{
	/// <summary>
	/// Summary description for Replay.
	/// </summary>
	public class Replay //:Exception
	{
		string message;


		public Replay(string message)
		{
			this.message=message;
		}

		public Replay(Replay other)
		{
			this.message=other.message;	
		}

		public string Message
		{
			get
			{
				return this.message;
			}
		}


	}
}
