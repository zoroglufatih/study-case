using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudyCase.Application.Features.Commands.TaskAssigner;
using StudyCase.Application.Features.Commands.TaskAssignment;
using StudyCase.Application.ViewModels;

namespace StudyCase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AssignController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AssignController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TaskAssignment()
        {
            List<string> urls = new();
            List<string> urlIds = new();
            List<UrlViewModel> urlViewModels = new List<UrlViewModel>()
            {
                new(){ Id = "0f7a9194-a5d8-4050-91a6-ab087c8a196b", Delay = 0},
                new(){ Id = "dcefd558-2d11-4035-9e94-2d6ce27675e0", Delay = 5},
                new(){ Id = "a7775176-a4c6-4c54-be06-caa440df6985", Delay = 15},
            };

            foreach (var item in urlViewModels)
            {
                urls.Add(BaseUrl.ChangedUrl(item));
                urlIds.Add(item.Id);
            }
            TaskAssignmentCommandRequest request = new()
            {
                Urls = urls,
                UrlIds = urlIds,
            };
            TaskAssignmentCommandResponse response = new();
            response = await _mediator.Send(request);
            TaskAssignerCommandRequest taskAssignerCommandRequest = new() { Tasks = response.Tasks };
            TaskAssignerCommandResponse taskAssignerCommandResponse = new();
            taskAssignerCommandResponse = await _mediator.Send(taskAssignerCommandRequest);
            return Ok(taskAssignerCommandResponse.Response);
        }
    }
}
