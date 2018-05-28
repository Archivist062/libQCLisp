using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispWhile : ILispNative
	{
		public LispWhile ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "while";
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
			return 'w';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue execute(LispArray array)
		{
			if(array.getSize()==3)
			{
				while (array [1].eval ().getBoolean ())
					array [2].eval ();
				return new LispBoolean (true);
			}
			else
				return new LispString("ERROR : (while cond block) enforced");
		}

		public ILispValue eval()
		{
			return this;
		}
	}
}

