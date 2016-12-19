using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOApp.DataModel.Models
{
    public class TaskContext : ITaskContext
    {

        public void AddTask(task task)
        {
            using (var context = new tododbEntities())
            {
                context.tasks.Add(task);
                context.SaveChanges();
            }
        }

        public List<task> GetTasks()
        {
            using (var context = new tododbEntities())
            {
                List<task> tasks = context.tasks.ToList();

                foreach (var task in tasks)
                {
                    task.task1 = task.task1.Trim();
                }

                return tasks;
            }

        }

        public void DeleteTask(int id)
        {
            using (var context = new tododbEntities())
            {
                task item1 = context.tasks.First(item => item.id == id);
                context.tasks.Remove(item1);
                context.SaveChanges();
            }
        }

        public task GetTask(int id)
        {
            using (var context = new tododbEntities())
            {
                task item1 = context.tasks.First(item => item.id == id);
                item1.task1 = item1.task1.Trim();
                return item1;
            }
        }

        public void UpdateTask(int id, string task)
        {
            using (var context = new tododbEntities())
            {
                task taskToUpdate = context.tasks.First(item => item.id == id);

                taskToUpdate.task1 = task;
                context.SaveChanges();
            }
        }
    }
}
