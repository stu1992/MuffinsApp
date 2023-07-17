using System.Collections.Generic;
using System.Xml.Serialization;

using MySql.Data.MySqlClient;
using MuffinServer.Models;

namespace MuffinServer.Repositories
{
    public class MuffinRepository : IMuffins
    {
        private MySqlConnection con;

        public MuffinRepository()
        {
            string cs = @"server=localhost;userid=root;password=password;database=muffins";
            con = new MySqlConnection(cs);
            con.Open();
        }

        public async Task<IEnumerable<Muffin>> GetMuffins()
        {
            string sql = "SELECT * FROM types";
            using var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();


            List<Muffin> muffins = new List<Muffin>();
            while (rdr.Read())
            {
                muffins.Add(new Muffin() { type = rdr.GetString(0) });
            }

            return muffins;
        }

        public async Task<bool> UpdateMuffins(IEnumerable<Muffin> muffins)
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from types;";
            cmd.ExecuteNonQuery();

            foreach (Muffin muffin in muffins)
            {
                cmd.CommandText = "insert into types (type) values (\"" + muffin.type + "\")";
                cmd.ExecuteNonQuery();
                Console.WriteLine("adding " + muffin.type);
            }
            return true;
        }
    }
}
