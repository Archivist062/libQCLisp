using System;
using System.Numerics;

namespace libQCLISP
{
	public class LispBoundValue : ILispNative
	{
		ILispValue value;

		public LispBoundValue (ILispValue val)
		{
			value = val;
		}


		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return value.getString();
		}
		public BigInteger getInteger()
		{
			return value.getInteger();
		}
		public double getFloating()
		{
			return value.getFloating();
		}
		public bool getBoolean()
		{
			return value.getBoolean();
		}
		public char getCharacter()
		{
			return value.getCharacter();
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue eval()
		{
			return value;
		}


		public ILispValue execute(LispArray array)
		{
			if (array.getSize()==2) {
				value = array [1];
				return value;
			} else
				return value;
		}
	}
}

