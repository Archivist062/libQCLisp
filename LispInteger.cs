using System;
using System.Numerics;

namespace libQCLISP
{
	public class LispInteger : ILispValue
	{
		BigInteger value;

		public LispInteger (BigInteger value)
		{
			this.value = value;
		}

		public ELispType getType()
		{
			return ELispType.Integer;
		}

		public BigInteger getInteger()
		{
			return value;
		}

		public string getString()
		{
			return value.ToString();
		}

		public double getFloating()
		{
			return (double)value;
		}

		public bool getBoolean()
		{
			return (value.IsZero ? false : true);
		}

		public  char getCharacter()
		{
			return (char)value.ToByteArray()[0];
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

