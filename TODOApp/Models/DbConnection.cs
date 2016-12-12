using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;

namespace TODOApp.Models
{
    public static class DbConnection
    {
        private static readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["postgresdb"].ToString();

        public static void AddTask(string task)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("INSERT INTO task(task) VALUES (:Task)", con);
                command.Parameters.Add("@Task", NpgsqlDbType.Text, 300).Value = task;
                con.Open();
                command.ExecuteNonQuery();
            }
        }
        public static void DeleteTask(int taskId)
        {

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

        public static DataSet GetTask(int taskId)
        {
            DataSet data = new DataSet();
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM task Where id=:Task", con);
                command.Parameters.Add("@Task", NpgsqlDbType.Integer).Value = taskId;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(command);

                da.Fill(data);
            }

            return data;
        }

        public static void UpdateTask(int taskId, string updatedText)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("UPDATE task SET task=:UpdateText WHERE id=:Task", con);
                command.Parameters.Add("@Task", NpgsqlDbType.Integer).Value = taskId;
                command.Parameters.Add("@UpdateText", NpgsqlDbType.Text, 300).Value = updatedText;
                con.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}