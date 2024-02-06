using System.Collections.Generic;
using System.Xml.Serialization;

using MySql.Data.MySqlClient;
using ProfileServer.Models;
using System.Data;
using Org.BouncyCastle.Bcpg;
using Microsoft.VisualBasic;

namespace ProfileServer.Repositories
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

        public async Task<bool> AddProfile(Profile profile)
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Profiles (profileName, profileDescription) values  (\"" + profile.profileName + "\", \"" + profile.profileDescription + "\")";
            cmd.ExecuteNonQuery();
            return true;
        }

        public async Task<bool> AddUser(CreateNewUserRequest user)
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

        public async Task<bool> UpdateProfile(UpdateProfileRequest profile)
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "update profiles set profileName = \"" + profile.profileName + "\", profileDescription = \"" + profile.profileDescription + "\" where profileId = " + profile.profileId;
            cmd.ExecuteNonQuery();
            return true;
        }

        public async Task<bool> UpdateUserProfiles(UpdateUserProfileRequest payload)
        {
            string sql = "SELECT userId FROM users where email = \"" + payload.email + "\"";
            var cmd2 = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd2.ExecuteReader();
            String userId = "";
            while (rdr.Read())
            {
                userId = rdr.GetInt32(0).ToString();
            }
            rdr.Close();

            using var cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "delete from UserProfiles where userId = " + userId;
            cmd.ExecuteNonQuery();

            foreach (var profileId in payload.profiles)
            {
                cmd.CommandText = "insert into UserProfiles (userId, profileId) values  (\"" + userId + "\", \"" + profileId.ToString() + "\")";
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public async Task<bool> DeleteProfile(String profileId)
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "delete from UserProfiles where profileId = " + profileId;
            cmd.ExecuteNonQuery();
            cmd.CommandText = "delete from profiles where profileId = " + profileId;
            var result = cmd.ExecuteNonQuery();
            return result == 0;
        }

        public async Task<UserManagement> GetUser(String email)
        {
            string sql = "SELECT * FROM users where email = \"" + email + "\"";
            var cmd = new MySqlCommand(sql, con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            String userId = null;
            User requestedUser = null;
            while (rdr.Read())
            {
                userId = rdr.GetInt32(0).ToString();

                requestedUser = new()
                {
                    firstName = rdr.GetString(1),
                    lastName = rdr.GetString(2),
                    email = rdr.GetString(3)
                };
            }
            rdr.Close();

            
            if (requestedUser != null || userId != null)
            {

                string sql2 = "select p.profileName, p.profileDescription as name from profiles as p join (select profileId from UserProfiles where userId = " + userId + ") as u where p.profileId = u.profileId";
                using var cmd2 = new MySqlCommand(sql2, con);
                using MySqlDataReader rdr2 = cmd2.ExecuteReader();


                List<Profile> profiles = new List<Profile>();
                while (rdr2.Read())
                {
                    profiles.Add(new Profile() { profileName = rdr2.GetString(0), profileDescription = rdr2.GetString(1) });
                }
                rdr2.Close();

                return new UserManagement() { user = requestedUser, profiles = profiles.ToArray() };
            }
            
            return new UserManagement() { user = requestedUser, profiles = null };
        }
    }
}
