using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispArray : ILispValue
	{
		public List<ILispValue> value;
		public bool force_eval=false;

		public LispArray (List<ILispValue> value)
		{
			this.value = value;
		}


		public ELispType getType()
		{
			return ELispType.LispValue;
		}

		public BigInteger getInteger()
		{
			if (value.Count == 0)
				return 0;
			return value[0].getInteger();
		}

		public string getString()
		{
			string print = "";
			print += force_eval ? "(" : "'(";
			for (int idx = 0; idx < value.Count; idx++) {
				print += value [idx].getString ();
				if (idx != value.Count - 1)
					print += " ";
			}
			print+=')';
			return print;
		}

		public double getFloating()
		{
			if (value.Count == 0)
				return 0.0;
			return value[0].getFloating();
		}

		public bool getBoolean()
		{
			if (value.Count == 0)
				return false;
			return value[0].getBoolean();
		}

		public  char getCharacter()
		{
			if (value.Count == 0)
				return '\0';
			return value[0].getCharacter();
		}

		public T getN<T>()
		{
			throw new NotLispValueException();
		}

		public ILispValue eval()
		{

			if (value.Count == 0)
				return new LispArray(new List<ILispValue>());
			if (!force_eval)
				return ((ILispNative)value[0]).execute(this);
			return this;
		}

		public ILispValue this[int idx]
		{
			get{return value [idx];}
			set{throw new Exception ("Trying to alter immutable data"); }
		}
		 
		public int getSize()
		{
			return value.Count;
		}

		public List<ILispValue> getInner()
		{
			return value;
		}



	}
}

