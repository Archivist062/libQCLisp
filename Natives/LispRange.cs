using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispRange : ILispNative
	{
		public LispRange ()
		{
		}

		public ELispType getType()
		{
			return ELispType.Native;
		}
		public string getString()
		{
			return "range";
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
			List<ILispValue> rng = new List<ILispValue> ();

			if(array.getSize()==3)
			{
				for (int idx = 1; idx < max_it; idx++)
					tmp.Add (array [idx].eval ());

				if (tmp [0].getInteger () < tmp [1].getInteger ()) {
					for (BigInteger n = tmp [0].getInteger (); !n.Equals (tmp [1].getInteger ()); n++)
						rng.Add (new LispInteger(n));
					rng.Add (new LispInteger(tmp [1].getInteger ()));
				} else if (tmp [0].getInteger () > tmp [1].getInteger ()) {
					for(BigInteger n=tmp [0].getInteger (); !n.Equals(tmp [1].getInteger ());n-- )
						rng.Add (new LispInteger(n));
					rng.Add (new LispInteger(tmp [1].getInteger ()));
				}
				
				return new LispArray(rng);
			}
			else
				return new LispString("ERROR : range require exactly 2 operands");
		}

		public ILispValue eval()
		{
			return this;
		}
	}
}

