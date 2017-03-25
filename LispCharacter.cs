using System;
using System.Numerics;

namespace libQCLISP
{
	public class LispCharacter : ILispValue
	{
		char value;

		public LispCharacter (char value)
		{
			this.value = value;
		}


		public ELispType getType()
		{
			return ELispType.Character;
		}

		public BigInteger getInteger()
		{
			return new BigInteger(Char.GetNumericValue(value));
		}

		public string getString()
		{
			return value.ToString();
		}

		public double getFloating()
		{
			return (double)Char.GetNumericValue(value);
		}

		public bool getBoolean()
		{
			return value.ToString().ToLower()=="y";
		}

		public  char getCharacter()
		{
			return value;
		}

		public T getN<T>()
		{
			throw new NotLispValueException();
		}

		public ILispValue eval()
		{
			return this;
		}
	}
}

