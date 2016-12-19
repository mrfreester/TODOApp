using System.Collections.Generic;

namespace TODOApp.DataModel.Models
{
    public interface ITaskContext
    {
        void AddTask(task task);
        List<task> GetTasks();
        void DeleteTask(int id);
        task GetTask(int id);
        void UpdateTask(int id, string task);
    }
}
