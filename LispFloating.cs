using System;
using System.Numerics;

namespace libQCLISP
{
	public class LispFloating : ILispValue
	{
		double value;

		public LispFloating (double value)
		{
			this.value = value;
		}

		public ELispType getType()
		{
			return ELispType.Floating;
		}

		public BigInteger getInteger()
		{
			return new BigInteger(value);
		}

		public string getString()
		{
			return value.ToString();
		}

		public double getFloating()
		{
			return value;
		}

		public bool getBoolean()
		{
			return (value==0 ? false : true);
		}

		public  char getCharacter()
		{
			return value.ToString()[0];
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

