using System;
using System.Numerics;

namespace libQCLISP
{
	public class LispOr : ILispNative
	{

		public LispOr ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "||";
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
			return 'o';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue execute(LispArray array)
		{
			int max_it = array.getSize ();
			for (int idx = 1; idx < max_it; idx++)
				if(array [idx].eval ().getBoolean())
					return new LispBoolean (true);

			return new LispBoolean(false);
		}

		public ILispValue eval()
		{
			return this;
		}
	}
}

