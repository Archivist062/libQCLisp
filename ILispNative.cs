using System;
using System.Numerics;

namespace libQCLISP
{
	public interface ILispNative : ILispValue
	{
		ILispValue execute(LispArray parameters);
	}
}

