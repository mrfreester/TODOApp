using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Validation;
using TODOApp.Endpoints.Home;
using TODOApp.Models;

namespace TODOApp.Endpoints.Update
{

    public class UpdateEndpoint
    {
        private readonly TaskHelper _helper = new TaskHelper();

        [UrlPattern("UpdateTask")] 
        public UpdateViewModel get_update(UpdateInputModel model)
        {
            return new UpdateViewModel
            {
                Task = model.Task,
                Id = model.Id
            };
        }

        [UrlPattern("EditTask")]
        public FubuContinuation post_edit_task(UpdateInputModel input)
        {
            string oldTask = _helper.GetTask(input.Id).TaskItem;

            _helper.UpdateTask(input.Id, input.Task);

            return FubuContinuation.TransferTo<HomeEndpoint>(x => x.get_index(new HomeViewModel()
            {
                Informative = "Update task: -" + oldTask + "- to: " + input.Task,
                Tasks = _helper.GetTasks()
            }));
        }
    }

    public class UpdateInputModel : FubuValidation.Notification
    {
        [Required, MinimumStringLength(3), MaximumStringLength(300)]
        public string Task { get; set; }
        public int Id { get; set; }
    }

    public class UpdateViewModel : FubuValidation.Notification
    {
        [Required, MinimumStringLength(3), MaximumStringLength(300)]
        public string Task { get; set; }
        public int Id { get; set; }
    }
}