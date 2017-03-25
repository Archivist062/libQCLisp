using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispHead : ILispNative
	{
		public LispHead ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "head";
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
			return 'h';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue execute(LispArray array)
		{
			if (array [1].getType() == ELispType.LispValue) {
				if (((LispArray)array [1]).getSize () != 0)
					return ((LispArray)array [1]) [0];
				else
					return new LispBoolean (false);
			} else
				return new LispBoolean (false);
		}

		public ILispValue eval()
		{
					return new LispString ("head");
		}
	}
}

