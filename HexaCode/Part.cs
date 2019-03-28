using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class Part
    {
        public int Id { get; }
        public int CountryId { get; }
        public int ManufacturerId { get; }
        public string Name { get; }
        public string TechnicalData { get; }
        public int Lifetime { get; }
        public int Count { get; }

        public Part()
        {
            Id = 0;
            CountryId = 0;
            ManufacturerId = 0;
            Name = "";
            TechnicalData = "";
            Lifetime = 0;
            Count = 0;
        }

        public Part(int id, int countryId, int manufacturerId, string name, string technicalData, int lifetime, int count)
        {
            Id = id;
            CountryId = countryId;
            ManufacturerId = manufacturerId;
            Name = name;
            TechnicalData = technicalData;
            Lifetime = lifetime;
            Count = count;
        }
    }
}