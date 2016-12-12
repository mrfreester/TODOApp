using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TODOApp.Models
{
    public class TaskHelper
    {
        public List<Task> GetTasks()
        {
            DataSet data = DbConnection.SelectAllTasks();

            List<Task> tasks =
                data.Tables[0].AsEnumerable()
                    .Select(
                        datarow => new Task {Id = datarow.Field<int>("id"), TaskItem = datarow.Field<string>("task")})
                    .ToList();
            return tasks;
        }

        public void AddTask(string task)
        {
            DbConnection.AddTask(task);
        }

        public void DeleteTask(int taskId)
        {
            DbConnection.DeleteTask(taskId);
        }

        public Task GetTask(int taskId)
        {
            DataSet data = DbConnection.GetTask(taskId);

            return
                data.Tables[0].AsEnumerable().Select(
                        datarow => new Task {Id = datarow.Field<int>("id"), TaskItem = datarow.Field<string>("task")})
                    .First();
        }

        public void UpdateTask(int taskId, string updatedText)
        {
            DbConnection.UpdateTask(taskId, updatedText);
        }
    }
}