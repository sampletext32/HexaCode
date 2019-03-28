using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexaCode
{
    public static class Database
    {
        private static SQLiteConnection _connection;

        private static void EstablishConnection()
        {
            _connection = new SQLiteConnection(string.Format("Data Source={0}", "data.db"));
            _connection.Open();
        }

        public static List<Part> SelectAllParts()
        {
            List<Part> parts = new List<Part>();
            var reader = ExecuteReader("SELECT * FROM countries");
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"].ToString());
                int country_id = Convert.ToInt32(reader["country_id"].ToString());
                int manufacturer_id = Convert.ToInt32(reader["manufacturer_id"].ToString());
                string name = reader["name"].ToString();
                string technical_data = reader["technical_data"].ToString();
                int lifetime = Convert.ToInt32(reader["lifetime"].ToString());
                int count = Convert.ToInt32(reader["count"].ToString());
                var part = new Part(id, country_id, manufacturer_id, name, technical_data, lifetime, count);
                parts.Add(part);
            }

            reader.Close();
            return parts;
        }

        public static Part SelectByIdPart(int id)
        {
            Part part = null;
            var reader = ExecuteReader($"SELECT * FROM parts WHERE id = '{id}'");
            while (reader.Read())
            {
                int bd_id = Convert.ToInt32(reader["id"].ToString());
                int country_id = Convert.ToInt32(reader["country_id"].ToString());
                int manufacturer_id = Convert.ToInt32(reader["manufacturer_id"].ToString());
                string name = reader["name"].ToString();
                string technical_data = reader["technical_data"].ToString();
                int lifetime = Convert.ToInt32(reader["lifetime"].ToString());
                int count = Convert.ToInt32(reader["count"].ToString());
                part = new Part(bd_id, country_id, manufacturer_id, name, technical_data, lifetime, count);
                break;
            }

            reader.Close();

            return part;
        }

        public static void UpdatePart(Part part)
        {
            if (part.Id == 0)
            {
                throw new InvalidOperationException("Can't call update: Id = 0, Call Insert First");
            }
            ExecuteQuery(
                $"UPDATE parts SET " +
                $"country_id='{part.CountryId}', " +
                $"manufacturer_id='{part.ManufacturerId}', " +
                $"name='{part.Name}', " +
                $"technical_data='{part.TechnicalData}', " +
                $"lifetime='{part.Lifetime}', " +
                $"count='{part.Count}' " +
                $"WHERE id='{part.Id}'");
        }

        public static int InsertPart(Part part)
        {
            var id = ExecuteQuery(
                $"INSERT INTO parts " +
                $"('country_id','manufacturer_id','name','technical_data','lifetime','count') VALUES (" +
                $"'{part.CountryId}', " +
                $"'{part.ManufacturerId}', " +
                $"'{part.Name}', " +
                $"'{part.TechnicalData}', " +
                $"'{part.Lifetime}', " +
                $"'{part.Count}')");
            part.SetId(id);
            return id;
        }

        public static List<Country> SelectAllCountries()
        {
            List<Country> countries = new List<Country>();
            var reader = ExecuteReader("SELECT * FROM countries");
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"].ToString());
                string name = reader["name"].ToString();
                var country = new Country(id, name);
                countries.Add(country);
            }

            reader.Close();
            return countries;
        }

        public static Country SelectByIdCountry(int id)
        {
            Country country = null;
            var reader = ExecuteReader($"SELECT * FROM countries WHERE id = '{id}'");
            while (reader.Read())
            {
                int bd_id = Convert.ToInt32(reader["id"].ToString());
                string name = reader["string"].ToString();
                country = new Country(bd_id, name);
                break;
            }

            reader.Close();

            return country;
        }

        public static void UpdateCountry(Country country)
        {
            if (country.Id == 0)
            {
                throw new InvalidOperationException("Can't call update: Id = 0, Call Insert First");
            }
            ExecuteQuery($"UPDATE countries SET name='{country.Name}' WHERE id='{country.Id}'");
        }

        public static int InsertCountry(Country country)
        {
            var id = ExecuteQuery($"INSERT INTO countries ('name') VALUES ('{country.Name}')");
            country.SetId(id);
            return id;
        }

        public static List<Manufacturer> SelectAllManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            var reader = ExecuteReader("SELECT * FROM manufacturers");
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"].ToString());
                string name = reader["name"].ToString();
                var manufacturer = new Manufacturer(id, name);
                manufacturers.Add(manufacturer);
            }

            reader.Close();
            return manufacturers;
        }

        public static Manufacturer SelectByIdManufacturer(int id)
        {
            Manufacturer manufacturer = null;
            var reader = ExecuteReader($"SELECT * FROM manufacturer WHERE id = '{id}'");
            while (reader.Read())
            {
                int bd_id = Convert.ToInt32(reader["id"].ToString());
                string name = reader["string"].ToString();
                manufacturer = new Manufacturer(bd_id, name);
                break;
            }

            reader.Close();

            return manufacturer;
        }

        public static void UpdateManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer.Id == 0)
            {
                throw new InvalidOperationException("Can't call update: Id = 0, Call Insert First");
            }
            ExecuteQuery($"UPDATE manufacturers SET name='{manufacturer.Name}' WHERE id='{manufacturer.Id}'");
        }

        public static int InsertManufacturer(Manufacturer manufacturer)
        {
            var id = ExecuteQuery($"INSERT INTO manufacturers ('name') VALUES ('{manufacturer.Name}')");
            manufacturer.SetId(id);
            return id;
        }

        private static SQLiteDataReader ExecuteReader(string command)
        {
            var sqliteCommand = new SQLiteCommand(command, _connection);
            var reader = sqliteCommand.ExecuteReader();
            return reader;
        }

        private static int ExecuteQuery(string command)
        {
            var sqliteCommand = new SQLiteCommand(command, _connection);
            sqliteCommand.ExecuteNonQuery();
            var insertRowId = (int)_connection.LastInsertRowId;
            return insertRowId;
        }
    }
}