using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Features.Commands.TaskAssignment
{
    public class TaskAssignmentCommandRequest : IRequest<TaskAssignmentCommandResponse>
    {
        public List<string> Urls { get; set; }
        public List<string> UrlIds { get; set; }
    }
}
