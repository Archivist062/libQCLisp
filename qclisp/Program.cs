using System;

namespace libQCLISP.qclisp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			LispContext ctx = new LispContext ();
			ctx.register ("+", new LispAdd ());
			ctx.register ("range", new LispRange ());

			while (true) {
				Console.Write ("> ");
				string n = Console.ReadLine ();
				Console.WriteLine (ctx.evaluate (n).eval ().getString());
			}
		}
	}
}
