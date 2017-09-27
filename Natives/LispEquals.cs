using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispEquals : ILispNative
	{
		public LispEquals ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "==";
		}
		public BigInteger getInteger()
		{
			return 0;
		}
		public double getFloating()
		{
			return 0.0;
		}
		public bool getBoolean()
		{
			return true;
		}
		public char getCharacter()
		{
			return 'm';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue execute(LispArray array)
		{
			int max_it = array.getSize ();
			List<ILispValue> tmp = new List<ILispValue> ();
			ILispValue ret= new LispBoolean(false);
			if(array.getSize()==3)
			{
				for (int idx = 1; idx < max_it; idx++)
					tmp.Add (array [idx].eval ());
			
				if (tmp [0].getString() == tmp[1].getString())
				{
					ret = new LispBoolean (true);
				}
				return ret;
			}
			else
				return new LispString("ERROR : == require exactly 2 operands");
		}

		public ILispValue eval()
		{
			return new LispString ("==");
		}
	}
}

