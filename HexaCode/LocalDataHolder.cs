using System.Collections.Generic;
using System.Threading.Tasks;

namespace HexaCode
{
    class LocalDataHolder
    {
        private static List<Country> countries;
        private static List<Manufacturer> manufacturers;
        private static List<Part> parts;

        public static List<Country> Country_SelectAll()
        {
            return countries;
        }

        public static List<Manufacturer> Manufacturer_SelectAll()
        {
            return manufacturers;
        }

        public static List<Part> Part_SelectAll()
        {
            return parts;
        }

        public static Country Country_GetById(int id)
        {
            var index = countries.FindIndex(t => t.Id == id);
            if (index == -1)
            {
                return null;
            }

            return countries[index];
        }

        public static Manufacturer Manufacturer_GetById(int id)
        {
            var index = manufacturers.FindIndex(t => t.Id == id);
            if (index == -1)
            {
                return null;
            }

            return manufacturers[index];
        }

        public static Part Part_GetById(int id)
        {
            var index = parts.FindIndex(t => t.Id == id);
            if (index == -1)
            {
                return null;
            }

            return parts[index];
        }

        public static void Country_Insert(Country country)
        {
            Database.InsertCountry(country);
            countries.Add(country);
        }

        public static void Manufacturer_Insert(Manufacturer manufacturer)
        {
            Database.InsertManufacturer(manufacturer);
            manufacturers.Add(manufacturer);
        }

        public static void Part_Insert(Part part)
        {
            Database.InsertPart(part);
            parts.Add(part);
        }

        public static void Country_Update(Country country)
        {
            Database.UpdateCountry(country);
            RefreshCountries();
        }

        public static void Manufacturer_Update(Manufacturer manufacturer)
        {
            Database.UpdateManufacturer(manufacturer);
            RefreshManufacturers();
        }

        public static void Part_Update(Part part)
        {
            Database.UpdatePart(part);
            RefreshParts();
        }

        private static void RefreshCountries()
        {
            countries = Database.SelectAllCountries();
        }

        private static void RefreshManufacturers()
        {
            manufacturers = Database.SelectAllManufacturers();
        }

        private static void RefreshParts()
        {
            parts = Database.SelectAllParts();
        }

        public static void RefreshLocalData()
        {
            RefreshCountries();
            RefreshManufacturers();
            RefreshParts();
        }
    }
}