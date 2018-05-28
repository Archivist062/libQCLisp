using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	/// <summary>
	/// Lisp add operand, add this with '+' in your interpreter to perform additions
	/// </summary>
	public class LispSubstract : ILispNative
	{
		public LispSubstract ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "-";
		}
		public BigInteger getInteger()
		{
			return 1;
		}
		public double getFloating()
		{
			return 1.0;
		}
		public bool getBoolean()
		{
			return true;
		}
		public char getCharacter()
		{
			return 's';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue execute(LispArray array)
		{
			int max_it = array.getSize ();
			List<ILispValue> tmp = new List<ILispValue> ();
			ILispValue ret;
			if(array.getSize()>1)
			{
				for (int idx = 1; idx < max_it; idx++)
					tmp.Add (array [idx].eval ());
				if (tmp [0].getType () == ELispType.Floating) {
					if (tmp.Count == 1)
						return new LispFloating (-tmp [0].getFloating ());
					double a = tmp [0].getFloating();
					for (int idx = 1; idx < tmp.Count; idx++)
						a -= tmp [idx].getFloating ();
					ret = new LispFloating (a);
				}else{
					if (tmp.Count == 1)
						return new LispInteger (-tmp [0].getInteger ());
					BigInteger a= tmp [0].getInteger();
					for (int idx = 1; idx < tmp.Count; idx++)
						a -= tmp [idx].getInteger ();
					ret = new LispInteger (a);
				}
				return ret;
			}
			else
				return new LispString("ERROR : - require at least one operand");
		}

		public ILispValue eval()
		{
			return this;
		}
	}
}

