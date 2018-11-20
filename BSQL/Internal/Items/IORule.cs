using System;
using System.Collections;

namespace thePackage.BSQL.Internal.Items
{
	/// <summary>
	/// Summary description for IORule.
	/// </summary>
	public class IORule
	{
		/// <summary>
		/// of items
		/// </summary>
		//public 
		ArrayList Inputs;

		/// <summary>
		/// of items
		/// </summary>
		//public
		ArrayList Outputs;

			
		public IORule
			(
			ArrayList inputs,

			ArrayList outputs
			)
		{
			if(inputs==null)
				this.Inputs=new ArrayList();
			else
				this.Inputs=new ArrayList (inputs);

			
			if(outputs==null)
				this.Outputs=new ArrayList();
			else
				this.Outputs=new ArrayList (outputs);

		}

		//			public string ToCode()
		//			{
		//				ArrayList inp=new ArrayList();
		//				foreach(Term term in this.Inputs)
		//				{
		//					inp.Add(term.ToCode());
		//				}
		//				string[] inputs=(string[])inp.ToArray("".GetType());
		//
		//				//-------------------------
		//
		//				ArrayList outp=new ArrayList();
		//				foreach(Term term in this.Outputs)
		//				{
		//					outp.Add(term.ToCode());
		//				}
		//				string[] outputs=(string[])outp.ToArray("".GetType());
		//			
		//				//-------------------------
		//
		//
		//				return 
		//					" ("+  string.Join(" , ",inputs)  +")"
		//					+" --> "
		//					+" ("+  string.Join(" , ",outputs)  +")"
		//					+"\r\n"
		//					+this.Operations.ToCode()
		//					;
		//			}


		public bool Match(Words words)
		{
			//if( !(t is LIST ))			return false;

			//if(words.Items.Length !=this.Inputs.Count) return false;
 
			//if(this.Inputs.Count==0) return true;

			for(int i=0; i< this.Inputs.Count ; i++)
				//if(  !((Item)this.Inputs[i]).Match( words[i] ))
				//return false;
				{
					
					Item item= ((Item)this.Inputs[i]);
					
					if(item is List )
					{
						((List)item).ListMatch(words.GetRange(i));
						//return true;
					}
					else
					{
						if( ! item.Match( words[i] ))
							return false;
					}


				}

			return true;
		}

		public Words ValuedOutput(Words words)
		{
			try
			{
				//if( !(t is LIST ))			return false;

				//if(words.Items.Count !=this.Inputs.Count) return false;
 
				//if(this.Inputs.Count==0) return new Words();

				for(int i=0; i< this.Inputs.Count ; i++)
				{
					Item item= ((Item)this.Inputs[i]);
					
					if(item is List )
					{
						((List)item).BindMatch(words.GetRange(i));
					}
					else
					{
						item.BindMatch( words[i] );
					}
				}

				return BuildOutput(this.Outputs);

			}
			catch //(DOSException exe)
			{
				throw new FailureValue();
			}

			
		}


		Words BuildOutput(ArrayList this_Outputs)
		{
			try
			{

				
				if(this_Outputs.Count==0) return new Words();
				
				//System.Windows.Forms.MessageBox.Show(this_Outputs[0].ToString());

				Words result=new Words();

				for(int i=0; i< this_Outputs.Count ; i++)
				{
					Item item= ((Item)this_Outputs[i]);
					

					if(item is Constant )
					{
						result.Add( item.Value);
					}
					else if(item is Variable)
					{
						Variable var=((Variable)item);
						
						if(var.Name.IndexOf("+")>0)
						{
							string[] parts=var.Name.Split('+');
							result.Add( 
								getVariableValue(parts[0])
								+
								"parts[1]"
								+
								getVariableValue(parts[2])
								);

						}

						else if(var.Value==null)
						{
							result.Add( getVariableValue(var.Name));
						}
						else
						{
							result.Add( item.Value);
						}
					}
					else if(item is List )
					{
						List list=((List)item);

						if(list.Items==null)
						{
							result.AddRange( getListValue(list.Name));
						}
						else
						{
							result.AddRange( list.Items);
						}
					}
				}
				
				return result;
			}
			catch //(DOSException exe)
			{
				throw new FailureValue();
			}
		
		}

		string getVariableValue(string varName)
		{
			foreach(Item item in this.Inputs)
			{
				if( item is Variable)
				{
					if(item.Name==varName)
						return item.Value;
				}
			}

			//return null;

			throw new FailureValue();
		}

		Words getListValue(string varName)
		{
			foreach(Item item in this.Inputs)
			{
				if( item is List)
				{
					if(item.Name==varName)
						return ((List)item).Items;
				}
			}

			//return null;

			throw new FailureValue();
		}




		public bool MatchInput(Words words)
		{
			//System.Console.WriteLine(words.ToString(""));

			if(words.Items.Length !=this.Inputs.Count) return false;
 
			if(this.Inputs.Count==0) return true;

			for(int i=0; i< this.Inputs.Count ; i++)
				if(  !((Item)this.Inputs[i]).Match( words[i] ))
				return false;
			

			return true;
		}


	}

}
