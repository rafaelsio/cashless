using System;
using System.Collections.Generic;
using System.Linq;

namespace Cashless.Common.Extentions
{
    public static class ArrayExtension
    {
        public static int[] RightCirculation(this int[] currentArray)
        {
            List<int> result = new List<int>();

            result.Add(currentArray.Last());
            for (int i =0; i<currentArray.Length-1; i++)
            {
                result.Add(currentArray[i]);
            }

            return result.ToArray();
        }

        public static int ConvertArrayToNumber(this int[] currentArray)
        {
            int result;

            string s = String.Join("",currentArray);

            int.TryParse(s, out result);

            return result;

        }
        
    }
}
