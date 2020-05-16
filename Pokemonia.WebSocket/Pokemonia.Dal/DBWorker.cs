using Npgsql;
using Dapper;
using System;
using System.Data;

namespace Pokemonia.Dal
{
    public class DBWorker
    {
        private string _connectionString = "User ID=postgres;Password=xxxxxx;Host=localhost;Port=5432;Database=coresample;Pooling=true;";
        public DBWorker()
        {

        }
        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection();
            }
        }
    }
}
