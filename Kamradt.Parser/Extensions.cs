using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kamradt.Parser.Delimiters;

namespace Kamradt.Parser
{
    internal class DelimResult
    {
        public KeyValuePair<string, Type> Delimiter;
        public int Index;
        public string LHS, RHS, Formula;

        public DelimResult(int index, string formula, KeyValuePair<string, Type> delim)
        {
            this.Index = index;
            this.Delimiter = delim;
            this.Formula = formula;
            this.LHS = formula.Substring(0, index);
            this.RHS = formula.Substring(index + delim.Key.Length);
        }
    }

    public static class Extensions
    {
        public static IComparable ConvertToCalcType(this object source, bool RemoveLiteralString)
        {
            if (source == null || source.ToString().Equals("null"))
                return null;

            string s = source.ToString();

            if (s.Equals("null"))
                return null;

            if (s.StartsWith("'") && s.EndsWith("'") && RemoveLiteralString)
                return s.Substring(1, s.Length - 2);

            if (s.Contains("e+"))
            {
                string[] sciNot = s.Split(new string[] { "e+" }, StringSplitOptions.RemoveEmptyEntries);
                if (sciNot.Length == 2)
                {
                    IComparable lhs = sciNot[0].ConvertToCalcType();
                    IComparable rhs = sciNot[1].ConvertToCalcType();

                    if(lhs is decimal && rhs is decimal)
                        return Convert.ToDecimal(Convert.ToDouble(lhs) * Math.Pow(10.0, Convert.ToDouble(rhs)));
                }
            }

            if (s.Contains("e-"))
            {
                string[] sciNot = s.Split(new string[] { "e-" }, StringSplitOptions.RemoveEmptyEntries);
                if (sciNot.Length == 2)
                {
                    IComparable lhs = sciNot[0].ConvertToCalcType();
                    IComparable rhs = sciNot[1].ConvertToCalcType();

                    if (lhs is decimal && rhs is decimal)
                        return Convert.ToDecimal(Convert.ToDouble(lhs) * Math.Pow(10.0, 0.0 - Convert.ToDouble(rhs)));
                }
            }

            decimal d;

            if (decimal.TryParse(s.ToString(), out d))
                return d;

            bool b;

            if (bool.TryParse(s.ToString(), out b))
                return b;

            return s.ToString(); ;
        }

        public static IComparable ConvertToCalcType(this object source)
        {
            return source.ConvertToCalcType(true);
        }

        internal static IEnumerable<DelimResult> IndexesWhere(this string source, IEnumerable<KeyValuePair<string, Type>> search, Func<DelimResult, bool> predicate, Func<DelimResult, DelimResult, DelimResult> conflictResolution)
        {
            DelimResult result = null;
            IEnumerable<DelimResult> delimResults;

            for (int index = 0; index < source.Length; index++)
            {
                result = null;
                delimResults = from s in search where index + s.Key.Length < source.Length select new DelimResult(index, source, s);
                foreach (DelimResult d in delimResults)
                {
                    if (predicate(d))
                    {
                        result = result == null ? d : conflictResolution(result, d);
                    }
                }
                if (result != null)
                {
                    yield return result;
                    index += result.Delimiter.Key.Length - 1;
                }
            }
        }

        internal static bool CharCountMatches(this string source, char Char1, char Char2)
        {
            return source.CharacterCount(Char1) == source.CharacterCount(Char2);
        }

        internal static int CharacterCount(this string source, char Char1)
        {
            return (from c in source where c == Char1 select c).Count();
        }

        internal static bool IsNull(this IComparable source)
        {
            return source == null;
        }
    }
}