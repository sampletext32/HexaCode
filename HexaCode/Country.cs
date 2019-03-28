using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class Country
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }

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
