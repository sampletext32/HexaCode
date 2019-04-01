using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class BinaryHelper
    {
        public static string ToBinaryString(int value, int strLength)
        {
            return Convert.ToString(value, 2).PadLeft(strLength, '0');
        }

        public static List<string> DivideBy6(string content)
        {
            var list = new List<string>();
            while (content.Length >= 6)
            {
                var firstSixSymbols = content.Substring(0, 6);
                list.Add(firstSixSymbols);
                content = content.Remove(0, 6);
            }

            if (content.Length > 0)
            {
                list.Add(content.PadRight(6, '0'));
            }

            return list;
        }
    }
}
