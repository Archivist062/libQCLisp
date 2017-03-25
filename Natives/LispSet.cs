using System;
using System.Numerics;


namespace libQCLISP
{
	public class LispSet : ILispNative
	{
		LispContext ctx;
		public LispSet (ref LispContext ctx)
		{
			this.ctx = ctx;
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "set";
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
			return '=';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}

		public ILispValue execute(LispArray array)
		{
			if (array [1].getType() == ELispType.String && array.getSize()==3) {
				return  ctx.bank [array [1].eval ().getString ()] = array [2].eval ();
			} else
				return new LispBoolean (false);
		}

		public ILispValue eval()
		{
			return new LispString ("head");
		}
	}
}


