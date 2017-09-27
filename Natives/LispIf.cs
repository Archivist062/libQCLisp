using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispIf : ILispNative
	{
		public LispIf ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "if";
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
			return '?';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue execute(LispArray array)
		{
			if(array.getSize()==4 || array.getSize()==3)
			{
				if (array [1].eval ().getBoolean ())
					return array [2].eval ();
				else
					return array [3].eval ();
					
			}
			else
				return new LispString("ERROR : (if cond then) or (if cond then else) enforced");
		}

		public ILispValue eval()
		{
			return new LispString ("if");
		}
	}
}

