using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    class Logger
    {
        private static StringBuilder _logger = new StringBuilder();

        public static void AppendLine(string text)
        {
            _logger.AppendLine(text);
        }

        public static string GetLog()
        {
            return _logger.ToString();
        }

        public static void Clear()
        {
            _logger.Clear();
        }
    }
}
