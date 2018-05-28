using System;
using System.Numerics;

namespace libQCLISP
{
	public class LispString : ILispValue
	{
		string value;

		public LispString (string value)
		{
			this.value = value;
		}


		public ELispType getType()
		{
			return ELispType.String;
		}

		public BigInteger getInteger()
		{
			try
			{
				return BigInteger.Parse(value);
			}
			catch
			{
				return 0;
			}
		}

		public string getString()
		{
			return '"'+value.Replace("\"","\\\"").Replace("\n","\\n")+'"';
		}

		public string getNativeString()
		{
			return value;
		}

		public double getFloating()
		{
			try
			{
				return Double.Parse(value);
		
			}
			catch 
			{
				return 0.0;
			}
		}

		public bool getBoolean()
		{
			return value.Length!=0;
		}

		public  char getCharacter()
		{
			if(value.Length==0) return 'N';
			return 'O';
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

