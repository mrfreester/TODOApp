
using System.Collections.Generic;
using FubuMVC.Core;
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
        public HomeViewModel AddTask()
        {
            return new HomeViewModel {
                Tasks = _helper.Tasks()
            };
        }
    }

    public class HomeViewModel
    {
        public List<Task> Tasks { get; set; }
    }
}