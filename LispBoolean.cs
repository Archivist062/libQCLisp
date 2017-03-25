using System;
using System.Numerics;

namespace libQCLISP
{
	public class LispBoolean : ILispValue
	{
		bool value;

		public LispBoolean (bool value)
		{
			this.value = value;
		}


		public ELispType getType()
		{
			return ELispType.Boolean;
		}

		public BigInteger getInteger()
		{
			return new BigInteger(value?1:0);
		}

		public string getString()
		{
			return value.ToString();
		}

		public double getFloating()
		{
			return (value?1.0:0.0);
		}

		public bool getBoolean()
		{
			return value;
		}

		public  char getCharacter()
		{
			return (value==true?'Y':'N');
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

