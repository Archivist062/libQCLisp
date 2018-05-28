using System;
using System.Numerics;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispArray : ILispValue
	{
		public List<ILispValue> value;
		public bool force_eval=true;

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
			if (force_eval) {
				if(value [0].getType()==ELispType.Native)
					return ((ILispNative)value [0]).execute (this);
				if (value [0].getType () == ELispType.LispValue) {
					var first = value [0].eval ();
					if (first.getType() != ELispType.Native) {
						LispArray ret = new LispArray (new List<ILispValue>(value.Count));
						ret.value.Add (first);
						for(int i=1;i<value.Count;i++)
							ret.value.Add(value [i].eval ());
						return ret;
					}else
						return ((ILispNative)first).execute (this);
				}
			}
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

