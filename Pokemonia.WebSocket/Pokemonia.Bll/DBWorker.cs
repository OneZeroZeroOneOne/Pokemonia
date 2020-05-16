using Npgsql;
using System;
using System.Data;

namespace Pokemonia.Bll
{
    public class DBWorker
    {
        private string _connectionString;
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
