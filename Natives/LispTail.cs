using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispTail : ILispNative
	{
		public LispTail ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "tail";
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
			return 't';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue execute(LispArray array)
		{
			if (array.getSize () == 2) {
				if (array [1].getType () == ELispType.LispValue) {
					if (((LispArray)array [1]).getSize () > 1) {
						var tmp = new List<ILispValue> ();
						var src = ((LispArray)array [1]).getInner ();
						for (int idx = 1; idx < src.Count; idx++)
							tmp.Add (src [idx]);
						return new LispArray (tmp);
					} else
						return new LispBoolean (false);
				} else {
					return new LispBoolean (false);
				}
			} else
				return new LispString ("tail require exactly one operand");
		}

		public ILispValue eval()
		{
			return this;
		}
	}
}

