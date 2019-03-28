using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public class Part
    {
        public int Id { get; private set; }
        public int CountryId { get; private set; }
        public int ManufacturerId { get; private set; }
        public string Name { get; private set; }
        public string TechnicalData { get; private set; }
        public int Lifetime { get; private set; }
        public int Count { get; private set; }

        public void TakeOne()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Count = 0, No Parts Left");
            }

            Count--;
            Database.UpdatePart(this);
        }

        public void PushOne()
        {
            Count++;
            Database.UpdatePart(this);
        }

        public void SetId(int id)
        {
            Id = id;
        }

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