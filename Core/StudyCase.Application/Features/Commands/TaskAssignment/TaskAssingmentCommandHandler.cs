using AutoMapper;
using MediatR;
using StudyCase.Application.Dto;
using StudyCase.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Features.Commands.TaskAssignment
{
    public class TaskAssingmentCommandHandler : IRequestHandler<TaskAssignmentCommandRequest, TaskAssignmentCommandResponse>
    {
        private readonly IHttpRequestService _httpRequestService;
        private readonly IParserService _parserService;
        private readonly ITaskAssignerService _taskAssignerService;
        private readonly IMapper _mapper;
        public TaskAssingmentCommandHandler(IHttpRequestService httpRequestService, IParserService parserService, ITaskAssignerService taskAssignerService, IMapper mapper)
        {
            _httpRequestService = httpRequestService;
            _parserService = parserService;
            _taskAssignerService = taskAssignerService;
            _mapper = mapper;
        }

        public async Task<TaskAssignmentCommandResponse> Handle(TaskAssignmentCommandRequest request, CancellationToken cancellationToken)
        {
            List<ApiResponseDto> responses = new List<ApiResponseDto>();
            foreach (var item in request.Urls)
            {
                responses.Add(await _httpRequestService.GetAsync(item));
            }
            List<Project> projects = new();
            List<Tasks> tasks = new();

            //foreach (var response in responses)
            for (int i = 0; i < responses.Count; i++)
            {
                if (responses[i].ContentType == "application/json")
                {
                    var task = new Tasks();
                    task = _parserService.JsonParser(responses[i].ResponseValue);
                    task.UrlId = request.UrlIds[i];
                    tasks.Add(task);
                }
                else if (responses[i].ContentType == "application/xml")
                {
                    var project = new Project();
                    project = _parserService.XmlParser(responses[i].ResponseValue);
                    project.Tasks.UrlId = request.UrlIds[i];
                    projects.Add(project);
                }
            }

            foreach (var item in projects)
            {
                tasks.Add(item.Tasks);
            }

            List<Domain.Entities.Task> tasksModel = new();

            foreach (var item in tasks)
            {
                List<Domain.Entities.Task> model = new();
                model = _mapper.Map<List<Domain.Entities.Task>>(item.tasks);
                for (int i = 0; i < model.Count; i++)
                {
                    model[i].ApiId = item.UrlId;
                    model[i].Id = Guid.NewGuid();
                    model[i].CreatedDate = DateTime.Now;
                }

                tasksModel.AddRange(model);
            }

            return new()
            {
                Tasks = tasksModel
            };
        }
    }
}
