﻿using Npgsql;
using Dapper;
using System;
using System.Data;

namespace Pokemonia.Dal
{
    public class DBWorker
    {
        private string _connectionString = "Host=194.99.21.140;Database=postgres;Username=postgres;Password=werdwerd2012";
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
