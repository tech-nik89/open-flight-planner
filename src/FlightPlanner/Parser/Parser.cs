using System;
using System.Globalization;
using System.IO;

namespace FlightPlanner.Parser {
	public abstract class Parser {

		private static readonly IFormatProvider _ParserFormatProvider = CultureInfo.CreateSpecificCulture("en-US");

		protected static IFormatProvider ParserFormatProvider {
			get {
				return _ParserFormatProvider;
			}
		}

		private readonly String[] _Lines;
		private readonly String _FileContent;

		protected String[] Lines {
			get {
				return _Lines;
			}
		}

		protected String FileContent {
			get {
				return _FileContent;
			}
		}

		public Parser(FileInfo file)
			: this(File.ReadAllText(file.FullName)){
		}

		public Parser(String input) {
			_FileContent = input;

			if (_FileContent.Contains("\r\n")) {
				_Lines = _FileContent.Split(new String[] { "\r\n" }, StringSplitOptions.None);
			}
			else {
				_Lines = _FileContent.Split(new String[] { "\n" }, StringSplitOptions.None);
			}
		}
	}
}
