using StudyCase.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Features.Commands.TaskAssignment
{
    public class TaskAssignmentCommandResponse
    {
        public List<Domain.Entities.Task> Tasks { get; set; }
    }
}
