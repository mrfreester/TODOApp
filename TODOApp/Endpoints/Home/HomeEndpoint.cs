
using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Validation;
using TODOApp.Endpoints.Update;
using TODOApp.Models;

namespace TODOApp.Endpoints.Home
{

    public class HomeEndpoint
    {
        private readonly TaskHelper _helper = new TaskHelper();

        [UrlPattern("")] //overides the default translation of the action to a url (in this case, the get_index() with a default url pattern of "/index" will now have a blank url pattern, effectively turning it into the home page)
        public HomeViewModel get_index(HomeViewModel model)
        {
            model.Tasks = _helper.GetTasks();
            return model;
        }

        [UrlPattern("AddTask")]
        public HomeViewModel post_add_task(AddTaskPostInputModel input)
        {
            _helper.AddTask(input.AddTask);

            return new HomeViewModel
            {
                Informative = "Added task: " + input.AddTask ,
                Tasks = _helper.GetTasks()
               
            };

            //return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.get_index(new HomeViewModel {Informative = "Added task " + input.AddTask}));
        }

        [UrlPattern("DeleteTask")]
        public HomeViewModel post_delete_task(TaskPostInputModel input)
        {
            _helper.DeleteTask(input.Id);

            return new HomeViewModel
            {
                Informative = "Deleted task: " + input.Task,
                Tasks = _helper.GetTasks()
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

    public class AddTaskPostInputModel
    {
        [MaximumStringLength(300)]
        public string AddTask { get; set; }
    }
    public class TaskPostInputModel
    {
        public string Task { get; set; }
        public int Id { get; set; }
    }

    public class HomeViewModel
    {
        public string Informative { get; set; }
        public List<Task> Tasks { get; set; }
    }
}