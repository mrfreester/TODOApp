
using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Validation;
using TODOApp.DataModel.Models;
using TODOApp.Endpoints.Update;

namespace TODOApp.Endpoints.Home
{

    public class HomeEndpoint
    {
        //private readonly TaskHelper _helper = new TaskHelper();
        private readonly ITaskContext _context;

        public HomeEndpoint(ITaskContext context)
        {
            _context = context;
        }

        [UrlPattern("")] //overides the default translation of the action to a url (in this case, the get_index() with a default url pattern of "/index" will now have a blank url pattern, effectively turning it into the home page)
        public HomeViewModel get_index(HomeViewModel model)
        {
            model.Tasks = _context.GetTasks();
            return model;
        }

        [UrlPattern("AddTask")]
        public HomeViewModel post_add_task(TaskPostInputModel input)
        {
            task item = new task();
            item.task1 = input.Task;
            _context.AddTask(item);

            return new HomeViewModel
            {
                Informative = "Added task: " + input.Task ,
                Tasks = _context.GetTasks()
               
            };

            //return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.get_index(new HomeViewModel {Informative = "Added task " + input.AddTask}));
        }

        [UrlPattern("DeleteTask")]
        public HomeViewModel post_delete_task(TaskPostInputModel input)
        {
            _context.DeleteTask(input.Id);

            return new HomeViewModel
            {
                Informative = "Deleted task: " + input.Task,
                Tasks = _context.GetTasks()
            };
            //return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.get_index(new HomeViewModel
            //{
            //    Informative = "Deleted Task: " + input.Task,
            //    Tasks = _helper.GetTasks()
            //}));
        }

        [UrlPattern("UpdateTask")]
        public FubuContinuation post_edit_task(TaskPostInputModel input)
        {
            return FubuContinuation.TransferTo<UpdateEndpoint>(x => x.get_update(new UpdateInputModel()));
        }
    }

    public class TaskPostInputModel
    {
        [MaximumStringLength(300)]
        public string Task { get; set; }
        public int Id { get; set; }
    }

    public class HomeViewModel
    {
        public string Informative { get; set; }
        public List<task> Tasks { get; set; }
    }
}