
using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Validation;
using TODOApp.Models;

namespace TODOApp.Endpoints.Home
{

    public class HomeEndpoint
    {
        private readonly TaskHelper _helper = new TaskHelper();

        [UrlPattern("")] //overides the default translation of the action to a url (in this case, the get_index() with a default url pattern of "/index" will now have a blank url pattern, effectively turning it into the home page)
        public HomeViewModel get_index()
        {
            return new HomeViewModel { Tasks = _helper.Tasks() };
        }

        [UrlPattern("AddTask")]
        public FubuContinuation post_add_task(AddTaskPostInputModel input)
        {
            _helper.AddTask(input.AddTask);

            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.get_index());
        }
    }

    public class AddTaskPostInputModel
    {
        [MaximumStringLength(3)]
        public string AddTask { get; set; }
    }

    public class HomeViewModel
    {
        public List<Task> Tasks { get; set; }

        [MaximumStringLength(3)]
        public string AddTask { get; set; }
    }
}