using System.Collections.Generic;
using System.Xml.Serialization;

using MySql.Data.MySqlClient;
using MuffinServer.Models;
using System.Data;
using Org.BouncyCastle.Bcpg;

namespace MuffinServer.Repositories
{
    public class MuffinRepository : IMuffins
    {
        private MySqlConnection con;

        public MuffinRepository()
        {
            string cs = @"server=localhost;userid=root;password=password;database=userprofiles";
            con = new MySqlConnection(cs);
            con.Open();
        }
        /*
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
        */
        public async Task<bool> AddProfile(Profile profile)
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Profiles (profileName, profileDescription) values  (\"" + profile.profileName + "\", \"" + profile.profileDescription + "\")";
            cmd.ExecuteNonQuery();
            return true;
        }

        public async Task<bool> AddUser(NewUser user)
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Users (firstName, lastName, email) values  (\"" + user.firstName + "\", \"" + user.lastName + "\", \"" + user.email + "\")";
            cmd.ExecuteNonQuery();

            string sql = "SELECT userId FROM users where email = \"" + user.email + "\"";
            var cmd2 = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd2.ExecuteReader();
            String userId = "";
            while (rdr.Read())
            {
                userId = rdr.GetInt32(0).ToString();
            }
            rdr.Close();
            

            foreach (var profileId in user.profiles)
            {
                Console.WriteLine("user id is : " + userId + " profile id is " + profileId.ToString());
                cmd.CommandText = "insert into UserProfiles (userId, profileId) values  (\"" + userId + "\", \"" + profileId.ToString() +"\")";
                cmd.ExecuteNonQuery();
            }
            return true;
        }
    }
}
