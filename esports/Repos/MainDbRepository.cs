using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using esports.Models;
using Microsoft.AspNetCore.Authentication;

namespace esports.Repos
{
    public class MainDbRepository
    {
        private readonly string _Dbconnection;

        public MainDbRepository(string dbconnection)
        {
            _Dbconnection = dbconnection;
        }
        public void AddNewUser(User user)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Insert(user);
            }
        }
        public IDbConnection Connection => new SqlConnection(_Dbconnection);

        public User GetUser(string username)
        {
            User result;
            using (IDbConnection conn = Connection)
            {
                result=conn.Query<User>("select * from Users where username =@username",new{username}).First();
            }
            return result;
        }

        public string GetJson()
        {
            using (IDbConnection conn = Connection)
            {
                return string.Join("",
                    conn.Query<string>("[dbo].[GetMatchesByDate]", param: new {datetime = DateTime.Today.AddDays(-1)},
                        commandType: CommandType.StoredProcedure));
            }
        }

        public List<T> Get<T>(string query)
        {
            using (IDbConnection conn = Connection)
            {
                return conn.Query<T>(query).ToList();
            }
        }
    }
}