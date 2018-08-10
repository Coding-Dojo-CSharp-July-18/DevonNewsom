using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using Dapper;
using System.Collections.Generic;
using DapperFun.Models;
using System.Linq;

namespace DapperFun
{

    public class UserFactory
    {
        static string server = "localhost";
        static string db = "mydb"; //Change to your schema name
        static string port = "3306"; //Potentially 8889
        static string user = "root";
        static string pass = "root";
        internal static IDbConnection Connection {
            get {
                return new MySqlConnection($"Server={server};Port={port};Database={db};UserID={user};Password={pass};SslMode=None");
            }
        }

        // A subset of users where we the most recent 5
        public List<User> MostRecentFive()
        {
            using(IDbConnection dbConnection = Connection)
            {
                return dbConnection.Query<User>("SELECT * FROM users ORDER BY created_at DESC LIMIT 5").ToList();
            }
        }

        // A single user by id
        public User GetUserById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = $"SELECT * FROM users WHERE user_id = @USERID";
                object myParam = new { USERID = id };
                return dbConnection.Query<User>(query, myParam).First();
            }
        }

        public void CreateUser(User user)
        {

            using(IDbConnection dbConnection = Connection)
            {
                string query = @"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                    VALUES (@first_name, @last_name, @email, @password, @created_at, @updated_at)";

                dbConnection.Execute(query, user);
            }
            
        }

        public bool EmailIsUnique(string email)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sql = "SELECT user_id FROM users WHERE email = @EMAIL";
                object param = new { EMAIL = email };

                IEnumerable<User> result = dbConnection.Query<User>(sql, param);

                return result.Count() == 0;
                
            }
        }
        
    }
}