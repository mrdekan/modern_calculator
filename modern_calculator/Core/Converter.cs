using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modern_calculator.Core
{
	internal class Converter
	{
		private const int AsciiZero = 48;
		private const int AsciiCapitalA = 65;
		private const int AsciiTrivialA = 97;
		private const int LettersBegin = 10;
		private const int LettersCount = 6;
		private int getValueFromHexadecimalNumber(char num)
		{
			if ((int)num < AsciiZero + LettersBegin)
				return (int)num - AsciiZero;
			else if ((int)num < AsciiCapitalA + LettersCount)
				return (int)num - (AsciiCapitalA - LettersBegin);
			return (int)num - (AsciiTrivialA - LettersBegin);
		}
		private char getInHexadecimalSystem(int num)
		{
			if (num <= 9)
				return num.ToString()[0];
			return (char)(num + AsciiCapitalA - LettersBegin);
		}
		public string Convert(int from, int to, string input, int afterPoint)
		{
			if (from == to)
				return input;
			if (to == 10)
				return toDecimal(from, input);
			return fromDecimal(to, toDecimal(from, input), afterPoint);
		}
		private string fromDecimal(int resNumSystem, string input, int numsAfterPoint)
		{
			StringBuilder resStr = new StringBuilder();
			StringBuilder before = new StringBuilder();
			foreach (char c in input)
			{
				if (c == ',') break;
				before.Append(c);
			}
			int numBefore = int.Parse(before.ToString());
			while (numBefore >= resNumSystem)
			{
				resStr.Append(getInHexadecimalSystem(numBefore % resNumSystem));
				numBefore = (numBefore - numBefore % resNumSystem) / resNumSystem;
			}
			resStr.Append(getInHexadecimalSystem(numBefore));
			string temp = new string(resStr.ToString().Reverse().ToArray());
			resStr.Clear();
			resStr.Append(temp);
			if (before.ToString() != input)
			{
				resStr.Append(',');
				StringBuilder after = new StringBuilder();
				after.Append("0,");
				for (int i = before.Length + 1; i < input.Length; i++) after.Append(input[i]);
				double numAfter = double.Parse(after.ToString());
				for (int i = 0; i < numsAfterPoint; i++)
				{
					numAfter *= resNumSystem;
					while (numAfter >= resNumSystem) numAfter -= resNumSystem;
					resStr.Append(getInHexadecimalSystem((int)Math.Floor(numAfter)));
				}
			}
			return resStr.ToString();
		}
		private string toDecimal(int numSystem, string value)
		{
			double res = 0;
			int startPos = value.Contains(',') ? Array.IndexOf(value.ToCharArray(), ',') : value.Length;
			for (int i = 0, j = 0; i < value.Length; i++, j++)
			{
				if (value[i] == ',')
				{
					j--;
					continue;
				}
				res += Math.Pow(numSystem, startPos - 1 - j) * getValueFromHexadecimalNumber(value[i]);
			}
			return res.ToString();
		}
	}
}
