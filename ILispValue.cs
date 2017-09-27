using System;
using System.Numerics;

namespace libQCLISP
{
	/// <summary>
	/// Interface for defining new Lisp Types (not necessarily parsable)
	/// </summary>
	public interface ILispValue
	{
		ELispType getType();
		string getString();
		BigInteger getInteger();
		double getFloating();
		bool getBoolean();
		char getCharacter();
		T getN<T> ();
		ILispValue eval();
	}

	/*




		public ELispType getType()
		{
			
		}
		public string getString()
		{
			return "";
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
			return 'a';
		}
		public T getN<T> ()
		{
			throw new NotLispValueException();
		}
		

	 */
}

