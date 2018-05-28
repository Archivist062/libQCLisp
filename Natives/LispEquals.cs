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
			ILispValue ret= new LispBoolean(true);
			if(array.getSize()>=2)
			{
				for (int idx = 1; idx < max_it; idx++)
					tmp.Add (array [idx].eval ());

				for (int idx = 0; idx < max_it - 2; idx++) {
					if (tmp [idx].getString () != tmp [idx + 1].getString ()) {
						ret = new LispBoolean (false);
						break;
					}
				}
				return ret;
			}
			else
				return new LispString("ERROR : == require at least 2 operands");
		}

		public ILispValue eval()
		{
			return this;
		}
	}
}

