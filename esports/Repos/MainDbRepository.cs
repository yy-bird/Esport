using System.Data;
using System.Data.SqlClient;
using Dapper.Contrib.Extensions;
using esports.Models;

namespace esports.Repos
{
    public class MainDbRepository
    {
        private string _Dbconnection;

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
    }
}