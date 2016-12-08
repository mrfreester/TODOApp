using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;

namespace TODOApp.Models
{
    public static class DbConnection
    {
        private static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["postgresdb"].ToString();

        public static void AddTask(string task)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {

            }
        }

        public static DataSet SelectAllTasks()
        {
            DataSet data = new DataSet();
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM task", con);
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);

                da.Fill(data);
            }

            return data;
        }
    }
}