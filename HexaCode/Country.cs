using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class Country
    {
        public int Id { get; }
        public string Name { get; }

        public Country()
        {
            Id = 0;
            Name = "";
        }

        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
