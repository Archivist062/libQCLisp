using System;
using System.Collections.Generic;

namespace libQCLISP
{
	public class LispContext
	{
		public Dictionary<string,ILispNative> registry;
		public Dictionary<string,ILispValue> bank;

		LispParser parsr;

		public LispContext ()
		{
			parsr = new LispParser ();
			registry = new Dictionary<string, ILispNative>();
			bank = new Dictionary<string, ILispValue> ();
		}

		public ILispValue evaluate(string a)
		{
			return compile (a).eval ();
		}

		public ILispValue compile(string a)
		{
			return parsr.parse (a,registry,bank);
		}

		ILispValue execute(ILispValue a)
		{
			throw new NotImplementedException ();
		}

		public bool register(string cmd,ILispNative nat)
		{
			if (registry.ContainsKey (cmd)) {
				registry [cmd] = nat;
				return true;
			} else {
				registry.Add (cmd, nat);
				return false;
			}
		}
	}
}

