using MediatR;
using StudyCase.Application.Repositories.DeveloperRepository;
using StudyCase.Application.Repositories.TaskRepository;
using StudyCase.Application.Services;
using StudyCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Features.Commands.TaskAssigner
{
    public class TaskAssignerCommandHandler : IRequestHandler<TaskAssignerCommandRequest, TaskAssignerCommandResponse>
    {
        private readonly ITaskAssignerService _taskAssignerService;
        private readonly ITaskWriteRepository _taskWriteRepository;
        private readonly ITaskReadRepository _taskReadRepository;
        public TaskAssignerCommandHandler(ITaskAssignerService taskAssignerService, ITaskWriteRepository taskWriteRepository, ITaskReadRepository taskReadRepository)
        {
            _taskAssignerService = taskAssignerService;
            _taskWriteRepository = taskWriteRepository;
            _taskReadRepository = taskReadRepository;
        }

        public async Task<TaskAssignerCommandResponse> Handle(TaskAssignerCommandRequest request, CancellationToken cancellationToken)
        {
            List<Developer> devs = new List<Developer>()
            {
                new Developer() { Id = 1, Name = "Developer 1", Difficulty = 1, Duration = 1, TotalWorkDone = 0 },
                new Developer() { Id = 2, Name = "Developer 2", Difficulty = 2, Duration = 1, TotalWorkDone = 0 },
                new Developer() { Id = 3, Name = "Developer 3", Difficulty = 3, Duration = 1, TotalWorkDone = 0 },
                new Developer() { Id = 4, Name = "Developer 4", Difficulty = 4, Duration = 1, TotalWorkDone = 0 },
                new Developer() { Id = 5, Name = "Developer 5", Difficulty = 5, Duration = 1, TotalWorkDone = 0 }
            };

            var result = _taskAssignerService.AssignTasks(request.Tasks, devs);
            foreach (var item in result)
            {
                foreach (var task in item.Tasks)
                {
                    if (_taskReadRepository.GetWhere(x => x.ApiId == task.ApiId).ToList().Count < 1)
                    {
                        task.DeveloperID = item.Developer.Id;
                        await _taskWriteRepository.AddAsync(task);
                    }
                }
            }

            await _taskWriteRepository.SaveAsync();
            
            return new()
            {
                Response = result
            };
        }
    }
}
