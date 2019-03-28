using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class Manufacturer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

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
