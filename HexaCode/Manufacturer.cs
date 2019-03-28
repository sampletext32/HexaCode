using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class Manufacturer
    {
        public int Id { get; }
        public string Name { get; }

        public Manufacturer()
        {
            Id = 0;
            Name = "";
        }

        public Manufacturer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
