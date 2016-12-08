
using FubuMVC.Core;

namespace TODOApp.Endpoints.Home
{
    public class HomeEndpoint
    {
        [UrlPattern("")] //overides the default translation of the action to a url (in this case, the get_index() with a default url pattern of "/index" will now have a blank url pattern, effectively turning it into the home page)
        public HomeViewModel get_index()
        {
            return new HomeViewModel { Text = "Hello Fubu 3!!" };
        }

        [UrlPattern("AddTask")]
        public HomeViewModel AddTask()
        {
            return new HomeViewModel { 
                Text = "Added a task"
            };
        }
    }

    public class HomeViewModel
    {
        public string Text { get; set; }
    }
}