using System;
using System.Collections.Generic;
using System.Numerics;

namespace libQCLISP
{
	public class LispParser
	{
		public class ParserState{
			public string data;
			public int position;
			public List<ILispValue> root;
		}

		public LispParser ()
		{
		}


		public ILispValue parse(string data,Dictionary<string,ILispNative> registry,Dictionary<string,ILispValue> bank)
		{
			ParserState state = new ParserState();
			state.position = 0;
			state.data = data + " ";
			state.root = new List<ILispValue>();

			//Console.WriteLine( n.ToString() +":" +data);

			//n++;

			for(;state.position<state.data.Length;state.position++)
			{
				switch (state.data [state.position]) {
				case '(':
					var n = resolve_parenthesis (ref state);
					string child = state.data.Substring (n.beg +1, n.end - n.beg-1);
					state.root.Add(parse(child,registry,bank));
					state.position--;
					break;
				case '0':
				case '1':
				case '2':
				case '3':
				case '4':
				case '5':
				case '6':
				case '7':
				case '8':
				case '9':
				case '.':
					ILispValue symn = resolve_numeric (ref state);
					state.root.Add (symn);
					state.position--;
					break;
				case '"':
					ILispValue symst = new LispString(resolve_string (ref state));
					state.root.Add (symst);
					break;
				case ' ':
				case '\t':
				case '\n':
					break;
				default:
					string syms = resolve_symbol (ref state);
					if (syms != "") {
						state.root.Add (registry [syms]);
						state.position--;
					}
					break;
				}
			}

			return new LispArray(state.root);
		}

		string resolve_symbol(ref ParserState state)
		{
			HashSet<char> lws = new HashSet<char>();
			lws.Add ('\t');
			lws.Add ('\n');
			lws.Add ('\0');
			lws.Add (' ');
			lws.Add ('(');
			lws.Add (')');

			string ret = "";

			while(!(lws.Contains(state.data[state.position])))
			{
				ret += state.data [state.position];
				state.position++;
			}

			return ret;
		}

		string resolve_string(ref ParserState state)
		{
			string ret = "";
			state.position++;
			while(!(state.data[state.position]=='"'))
			{
				if ((state.data [state.position] == '\\')) {
					state.position++;
					switch (state.data [state.position]) {
					case 'n':
						ret += '\n';
						break;
					case 'a':
						ret += '\a';
						break;
					case 't':
						ret += '\t';
						break;
					case '\\':
						ret += '\\';
						break;
					case '"':
						ret += '"';
						break;
					default:
						ret += state.data [state.position];
						break;
					}
				} else {
					ret += state.data [state.position];
				}
				state.position++;
			}

			return ret;
		}

		struct Range{
			public int beg,end;
		}
		Range resolve_parenthesis(ref ParserState state)
		{
			Range r;
			r.beg = state.position;
			int rec = 1;
			while (rec != 0) {
				state.position++;
				if (state.data [state.position] == '(')
					rec++;
				else if (state.data [state.position] == ')')
					rec--;
			}
			r.end = state.position;
			return r;
		}



		ILispValue resolve_numeric(ref ParserState state)
		{
			BigInteger ret = 0;
			int exp=0;
			bool isInt = true;
			bool end = false;
			while (!end) {
				if (Char.IsDigit (state.data [state.position])) {
					ret *= 10;
					switch (state.data [state.position]) {
					case '9':
						ret += 9;
						break;
					case '8':
						ret += 8;
						break;
					case '7':
						ret += 7;
						break;
					case '6':
						ret += 6;
						break;
					case '5':
						ret += 5;
						break;
					case '4':
						ret += 4;
						break;
					case '3':
						ret += 3;
						break;
					case '2':
						ret += 2;
						break;
					case '1':
						ret += 1;
						break;
					case '0':
						break;
					}
					if (!isInt)
						exp++;
				} else if (Char.IsLetter (state.data [state.position])) {
					switch (state.data [state.position]) {
					case 'f':
						exp +=  15;
						isInt = false;
						break;
					case 'p':
						exp +=  12;
						isInt = false;
						break;
					case 'n':
						exp +=  9;
						isInt = false;
						break;
					case 'u':
						exp +=  6;
						isInt = false;
						break;
					case 'm':
						exp +=  3;
						isInt = false;
						break;
					case 'c':
						exp += 2;
						isInt = false;
						break;
					case 'd':
						exp += 1;
						isInt = false;
						break;
					case 'h':
						ret *= 100;
						break;
					case 'k':
						ret *= 1000;
						break;
					case 'M':
						ret *= 1000000;
						break;
					case 'G':
						ret *= 1000000000;
						break;
					case 'T':
						ret *= 1000000000000;
						break;
					case 'P':
						ret *= 1000000000000000;
						break;
					}
					end = true;
				} else if (state.data [state.position]=='\'') {

				} else if (state.data [state.position]=='.') {
					isInt = false;
				} else {
					end = true;
				}
				state.position++;
			}
			if (isInt)
				return new LispInteger (ret);
			else
				return new LispFloating ((double)ret/Math.Pow(10,exp));
		}
	}
}

