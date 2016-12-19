using System.Collections.Generic;
using FubuMVC.Core;
using FubuMVC.Core.Continuations;
using FubuMVC.Core.Validation;
using TODOApp.DataModel.Models;
using TODOApp.Endpoints.Home;

namespace TODOApp.Endpoints.Update
{

    public class UpdateEndpoint
    {
        private readonly ITaskContext _context;

        public UpdateEndpoint(ITaskContext context)
        {
            _context = context;
        }

        [UrlPattern("UpdateTask")] 
        public UpdateInputModel get_update(UpdateInputModel model)
        {
            return new UpdateInputModel
            {
                Task = model.Task,
                Id = model.Id
            };
        }

        [UrlPattern("EditTask")]
        public FubuContinuation post_edit_task(UpdateInputModel input)
        {
            string oldTask = _context.GetTask(input.Id).task1;

            _context.UpdateTask(input.Id, input.Task);

            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.get_index(new HomeViewModel()));
        }
    }

    public class UpdateInputModel : FubuValidation.Notification
    {
        [Required, MinimumStringLength(3), MaximumStringLength(300)]
        public string Task { get; set; }
        public int Id { get; set; }
    }
}