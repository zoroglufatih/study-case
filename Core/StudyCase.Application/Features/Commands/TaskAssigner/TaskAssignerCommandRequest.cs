using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Features.Commands.TaskAssigner
{
    public class TaskAssignerCommandRequest : IRequest<TaskAssignerCommandResponse>
    {
        public List<Domain.Entities.Task> Tasks { get; set; }
    }
}
