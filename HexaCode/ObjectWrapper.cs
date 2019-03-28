using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class ObjectWrapper
    {
        public object O { get; set; }

        public ObjectWrapper(object data = null)
        {
            O = data;
        }
    }
}
