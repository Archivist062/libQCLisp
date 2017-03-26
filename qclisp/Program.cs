using System;

namespace libQCLISP.qclisp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			LispContext ctx = new LispContext ();
			ctx.register ("+", new LispAdd ());
			ctx.register ("get", new LispGet (ref ctx));
			ctx.register ("set", new LispSet (ref ctx));
			ctx.register ("range", new LispRange ());
			ctx.register ("store", new LispBoundValue (new LispFloating (0.001)));

			while (true) {
				Console.Write ("> ");
				string n = Console.ReadLine ();
				Console.WriteLine (ctx.evaluate (n).eval ().getString());
			}
		}
	}
}
