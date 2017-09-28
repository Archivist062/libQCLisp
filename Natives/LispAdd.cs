using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	/// <summary>
	/// Lisp add operand, add this with '+' in your interpreter to perform additions
	/// </summary>
	public class LispAdd : ILispNative
	{
		public LispAdd ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "+";
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
			return 'a';
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
					double a = 0;
					for (int idx = 0; idx < tmp.Count; idx++)
						a += tmp [idx].getFloating ();
					ret = new LispFloating (a);
				}else{
					BigInteger a=0;
					for (int idx = 0; idx < tmp.Count; idx++)
						a += tmp [idx].getInteger ();
					ret = new LispInteger (a);
				}
				return ret;
			}
			else
				return new LispString("ERROR : + require at least one operand");
		}

		public ILispValue eval()
		{
			return new LispCharacter ('+');
		}
	}
}

