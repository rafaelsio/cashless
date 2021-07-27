using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cashless.Common.Extentions
{
    public static class StringExtentions
    {
        public static bool onlyNumbers(this string s)
        {
            if (s == null || s == "") return false;

            for (int i = 0; i < s.Length; i++)
                if ((s[i] ^ '0') > 9)
                    return false;

            return true;
        }

        public static int convertToInt(this string s)
        {
            int result;
            int.TryParse(s, out result);

            return result;
        }

        public static int[] convertToIntArray(this string s)
        {
            List<string> strArray = new List<string>();
            foreach(var c in s.ToCharArray())
            {
                strArray.Add(c.ToString());
            }
            int[] ints = Array.ConvertAll(strArray.ToArray(), int.Parse);
            return ints;
        }
    }
}
