using StudyCase.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCase.Application.Features.Commands.TaskAssigner
{
    public class TaskAssignerCommandResponse
    {
        public List<AssignmentViewModel> Response { get; set; }
    }
}
